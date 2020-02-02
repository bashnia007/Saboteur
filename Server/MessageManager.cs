using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public static class MessageManager
    {
        public static Queue<ClientObject> Players;
        public static Queue<Card> HandCards;
        public static List<AbstractPlayer> AbstractPlayers { get; set; }

        static MessageManager()
        {
            Players = new Queue<ClientObject>();
            AbstractPlayers = new List<AbstractPlayer>();
        }

        public static List<Message> HandleMessage(Message message, ClientObject client)
        {
            var type = message.MessageType;
            //Logger.Write($"Received {type.ToString()} message from client {client.Id}");

            switch (type)
            {
                #region Lobby messages
                case GameMessageType.ClientConnectedMessage:
                    return HandleClientConnectedMessage(message, client.Id);

                case GameMessageType.RetrieveAllGamesMessage:
                    return HandleRetrieveAllGamesMessage(message);

                case GameMessageType.CreateGameMessage:
                    return HandleCreateGameMessage(message, client.Id);

                case GameMessageType.JoinMessage:
                    return HandleJoinGameMessage(message as JoinGameMessage, client.Id);

                #endregion

                case GameMessageType.StartGameMessage:
                    return HandleStartGameMessage(message);




                case GameMessageType.InitializeMessage:
                    return HandleInitializeMessage(message, client);

                case GameMessageType.TextMessage:
                    return HandleTextMessage(message, client);

                case GameMessageType.ReadyToPlay:
                    return HandleReadyToPlayMessage(message, client);

                case GameMessageType.BuildMessage:
                    return HandleBuildMessage(message, client);

                case GameMessageType.ActionMessage:
                    return HandleActionMessage(message, client);

                case GameMessageType.DestroyConnectionMessage:
                    return HandleDestroyConnectionMessage(message, client);

                case GameMessageType.ExploreMessage:
                    return HandleExploreMessage(message, client);

                case GameMessageType.FoldMessage:
                    return HandleFoldMessage(message, client);

                case GameMessageType.FoldForFixMessage:
                    return HandleFoldForFixMessage(message, client);

                case GameMessageType.RotateGoldCardMessage:
                    return HandleRotateGoldCardMessage(message);

                case GameMessageType.KeyMessage:
                    return HandleKeyMessage(message, client);

                default: throw new NotImplementedException();
            }
        }

        #region Private methods

        private static List<Message> HandleClientConnectedMessage(Message message, string userId)
        {
            var result = new List<Message>();
            var clientConnectedMessage = message as ClientConnectedMessage;

            if (!AbstractPlayers.Select(p => p.Id).Contains(userId))
            {
                AbstractPlayers.Add(new Player
                {
                    Id = userId,
                    Name = message.Login
                });

            }

            clientConnectedMessage.Games = GameManager.RecieveAllGames();

            result.Add(clientConnectedMessage);
            return result;
        }

        private static List<Message> HandleRetrieveAllGamesMessage(Message message)
        {
            var result = new List<Message>();
            var clientConnectedMessage = message as ClientConnectedMessage;
            
            clientConnectedMessage.Games = GameManager.RecieveAllGames();
            result.Add(clientConnectedMessage);

            return result;
        }

        // todo rewrite HandleCreateGameMessage and HandleJoinGameMessage. They are almost the same
        private static List<Message> HandleCreateGameMessage(Message message, string userId)
        {
            var result = new List<Message>();

            var createGameMessage = message as CreateGameMessage;

            Player player = (Player)AbstractPlayers.FirstOrDefault(p => p.Id == userId);

            if (player == null)
            {
                //Logger.Write($"Cannot find player with id {userId} in connected players", LogLevel.Error);
            }
            else
            {
                var game = GameManager.CreateGame(createGameMessage.GameType, player);
                createGameMessage.GameId = game.GameId;
                createGameMessage.IsBroadcast = false;

                result.Add(createGameMessage);
            }

            return result;
        }

        private static List<Message> HandleJoinGameMessage(JoinGameMessage joinGameMessage, string userId)
        {
            var result = new List<Message>();
            
            Player player = (Player)AbstractPlayers.FirstOrDefault(p => p.Id == userId);
            if (player == null)
            {
                //Logger.Write($"Cannot find player with id {userId} in connected players", LogLevel.Error);
            }
            else
            {
                GameManager.JoinGame(joinGameMessage.GameId, player);
                var message = new JoinGameMessage(joinGameMessage.GameId, player.Name,
                    GameManager.RecieveGame(joinGameMessage.GameId).Players.Select(p => p.Id).ToList());
                result.Add(message);
            }

            return result;
        }

        private static List<Message> HandleStartGameMessage(Message message)
        {
            var result = new List<Message>();

            var startGameMessage = message as StartGameMessage;
            var game = GameManager.RecieveGame(startGameMessage.GameId);
            GameManager.CloseGame(startGameMessage.GameId);
            game.Start();

            SendUpdatedGamesList(result);
            SendHandInfo(game, result);

            return result;
        }



        private static List<Message> HandleInitializeMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();
            result.Add(new InitializeMessage
            {
                Id = client.Id,
                IsBroadcast = false
            });

            //Logger.Write($"Initialize message was sent for client {client.Id}");

            return result;
        }

        private static List<Message> HandleTextMessage(Message message, ClientObject client)
        {
            //Logger.Write($"Text message was received from client {client.Id}");
            var result = new List<Message>();
            result.Add(new TextMessage
            {
                Text = ((TextMessage) message).Text,
                SenderId = client.Id
            });

            //Logger.Write($"Text message was sent from client {client.Id}");
            return result;
        }

        private static List<Message> HandleReadyToPlayMessage(Message message, ClientObject client)
        {
            //Logger.Write($"Ready to play message was received from client {client.Id}");
            var result = new List<Message>();
            client.IsReady = true;
            client.Server.LaunchGame();
            result.Add(new GameMessage
            {
                MessageType = GameMessageType.ReadyToPlay,
                SenderId = client.Id
            });

            //Logger.Write($"Ready to play message was sent from client {client.Id}");
            return result;
        }

        private static List<Message> HandleBuildMessage(Message message, ClientObject client)
        {
            //Logger.Write($"Build message was received from client {client.Id}");

            var result = new List<Message>();

            var buildMessage = (BuildMessage) message;
            result.Add(buildMessage);

            // check if user can build card
            if (Validator.ValidateBuildingTunnelAction(buildMessage.RouteCard, Table.OpenedCards, buildMessage.RoleType))
            {
                buildMessage.IsSuccessfulBuild = true;
                buildMessage.IsBroadcast = true;

                var updateMessage = ProvidePlayerNewCards(client.Id, new List<int> {buildMessage.CardId});
                result.Add(updateMessage);
                
                Table.AddCard(buildMessage.RouteCard, buildMessage.RoleType);

                var goldCardsToOpen = Table.GoldCards
                    .Where(goldCard => 
                        goldCard.Coordinates.IsNeighbour(buildMessage.RouteCard.Coordinates) && 
                        (!goldCard.IsOpen || !Table.OpenedCards.Contains(goldCard)))
                    .ToList();

                var rotateMessage = new RotateGoldCardMessage();
                foreach (var goldCard in goldCardsToOpen)
                {
                    if (Validator.CheckForGold(goldCard, Table.OpenedCards, buildMessage.RoleType) &&
                        Validator.CheckForGold((GoldCard)goldCard.Rotate(), Table.OpenedCards, buildMessage.RoleType))
                    {
                        rotateMessage.CardsToRotate.Add(goldCard);
                    
                    }
                    else
                    {
                        if (!Validator.CheckForGold(goldCard, Table.OpenedCards, buildMessage.RoleType))
                            goldCard.Rotate();
                    }
                    
                    goldCard.IsOpen = true;
                    Table.OpenedCards.Add(goldCard);
                    var exploreMessage = new ExploreMessage();
                    exploreMessage.IsBroadcast = true;
                    exploreMessage.Card = goldCard;
                    exploreMessage.Coordinates = goldCard.Coordinates;

                    result.Add(exploreMessage);
                }

                if (rotateMessage.CardsToRotate.Count > 0)
                {
                    result.Add(rotateMessage);
                }
                else
                {
                    var directMessage = SetNextPlayer();
                    result.Add(directMessage);
                }

                if (CheckGameEnd()) result.Add(CreateEndGameMessage());

                Table.UpdateAllConnections(buildMessage.RoleType);
                result.Add(PrepareGoldMessage());
                result.Add(new UpdateTokensMessage(Table.Tokens));

                //Logger.Write($"Build message was sent from client {client.Id}");
            }
            else
            {
                buildMessage.IsSuccessfulBuild = false;
                buildMessage.IsBroadcast = false;

                //Logger.Write($"Can't build message was sent for client {client.Id}");
            }


            return result;
        }

        private static List<Message> HandleActionMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();
            var actionMessage = (ActionMessage) message;

            var resultMessage = new ActionMessage
            {
                IsSuccessful = false,
                RecepientId = actionMessage.RecepientId,
                SenderId = actionMessage.SenderId,
            };

            var player = Table.Players.FirstOrDefault(pl => pl.Id == actionMessage.RecepientId);

            switch (actionMessage.ActionType)
            {
                case ActionType.BreakLamp:
                    if (!player.BrokenEquipments.Contains(Equipment.Lamp))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Add(Equipment.Lamp);
                    }

                    break;
                case ActionType.BreakPick:
                    if (!player.BrokenEquipments.Contains(Equipment.Pick))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Add(Equipment.Pick);
                    }

                    break;
                case ActionType.BreakTrolley:
                    if (!player.BrokenEquipments.Contains(Equipment.Trolley))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Add(Equipment.Trolley);
                    }

                    break;
                case ActionType.FixLamp:
                    if (player.BrokenEquipments.Contains(Equipment.Lamp))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Lamp);
                    }

                    break;
                case ActionType.FixPick:
                    if (player.BrokenEquipments.Contains(Equipment.Pick))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Pick);
                    }

                    break;
                case ActionType.FixTrolly:
                    if (player.BrokenEquipments.Contains(Equipment.Trolley))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Trolley);
                    }

                    break;
            }

            resultMessage.Players = Table.Players;
            resultMessage.IsBroadcast = true;
            result.Add(resultMessage);

            if (resultMessage.IsSuccessful)
            {
                var updateMessage = ProvidePlayerNewCards(client.Id, new List<int> {actionMessage.CardId});
                result.Add(updateMessage);

                var directMessage = SetNextPlayer();
                result.Add(directMessage);
                result.Add(PrepareGoldMessage());
                if (CheckGameEnd()) result.Add(CreateEndGameMessage());
            }

            return result;
        }

        private static List<Message> HandleDestroyConnectionMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();

            var destroyMessage = (DestroyMessage) message;
            destroyMessage.IsBroadcast = false;
            destroyMessage.IsSuccessful = false;

            result.Add(destroyMessage);

            var cardToDestroy = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == destroyMessage.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == destroyMessage.Coordinates.Coordinate_Y);

            if (cardToDestroy == null || cardToDestroy is StairsCard || cardToDestroy is GoldCard || cardToDestroy.Gold > 0 || cardToDestroy.IsTroll)
            {
                return result;
            }

            if (cardToDestroy != null)
            {
                destroyMessage.IsBroadcast = true;
                destroyMessage.IsSuccessful = true;
                Table.OpenedCards.Remove(cardToDestroy);

                var updateMessage = ProvidePlayerNewCards(client.Id, new List<int> {destroyMessage.CardId});
                result.Add(updateMessage);

                var directMessage = SetNextPlayer();
                result.Add(directMessage);
                result.Add(PrepareGoldMessage());
                if (CheckGameEnd()) result.Add(CreateEndGameMessage());
            }

            Table.UpdateAllConnections();
            return result;
        }

        private static List<Message> HandleExploreMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();

            var exploreMessage = (ExploreMessage) message;
            exploreMessage.IsBroadcast = false;
            exploreMessage.Card = Table.GoldCards.First(c =>
                c.Coordinates.Coordinate_X == exploreMessage.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == exploreMessage.Coordinates.Coordinate_Y);
            exploreMessage.Card.IsOpen = true;

            result.Add(exploreMessage);

            result.Add(ProvidePlayerNewCards(client.Id, new List<int> {exploreMessage.CardId}));
            result.Add(SetNextPlayer());
            result.Add(PrepareGoldMessage());
            if (CheckGameEnd()) result.Add(CreateEndGameMessage());

            return result;
        }

        private static List<Message> HandleFoldMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();

            var foldMessage = (FoldMessage) message;

            if (foldMessage.Cards.Count > 0 && foldMessage.Cards.Count < 3)
            {
                result.Add(ProvidePlayerNewCards(client.Id, foldMessage.Cards.Select(c => c.Id).ToList()));
                result.Add(SetNextPlayer());
                result.Add(PrepareGoldMessage());
                if (CheckGameEnd()) result.Add(CreateEndGameMessage());
            }

            return result;
        }

        private static List<Message> HandleFoldForFixMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();

            var foldMessage = (FoldForFixEquipmentMessage)message;

            if (foldMessage.Cards.Count > 0 && foldMessage.Cards.Count < 3)
            {
                result.Add(ProvidePlayerNewCards(client.Id, foldMessage.Cards.Select(c => c.Id).ToList(), true));
                result.Add(SetNextPlayer());
                result.Add(PrepareGoldMessage());
                if (CheckGameEnd()) result.Add(CreateEndGameMessage());
            }
            var player = Table.Players.FirstOrDefault(pl => pl.Id == foldMessage.SenderId);
            var resultMessage = new ActionMessage
            {
                IsSuccessful = false,
                RecepientId = foldMessage.SenderId,
                SenderId = foldMessage.SenderId,
            };

            switch (foldMessage.ActionType)
            {
                case ActionType.FixLamp:
                    if (player.BrokenEquipments.Contains(Equipment.Lamp))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Lamp);
                    }

                    break;
                case ActionType.FixPick:
                    if (player.BrokenEquipments.Contains(Equipment.Pick))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Pick);
                    }

                    break;
                case ActionType.FixTrolly:
                    if (player.BrokenEquipments.Contains(Equipment.Trolley))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Trolley);
                    }

                    break;
            }

            result.Add(resultMessage);

            return result;
        }

        private static List<Message> HandleKeyMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();

            KeyMessage keyMessage = message as KeyMessage;
            keyMessage.IsBroadcast = true;
            keyMessage.Card = Table.OpenedCards.First(c =>
                c.Coordinates.Coordinate_X == keyMessage.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == keyMessage.Coordinates.Coordinate_Y);
            Table.SetKey(keyMessage.Card);
            keyMessage.Card.SetKey();

            result.Add(keyMessage);

            result.Add(ProvidePlayerNewCards(client.Id, new List<int> { keyMessage.CardId }));
            result.Add(SetNextPlayer());

            if (CheckGameEnd()) result.Add(CreateEndGameMessage());
            Table.UpdateAllConnections(keyMessage.RoleType);

            return result;
        }

        private static UpdateTableMessage ProvidePlayerNewCards(string clientId, List<int> cardsToRemove, bool dicrease = false)
        {
            var client = AbstractPlayers.First(pl => pl.Id == clientId);

            if (cardsToRemove.Count >= 0)
            {
                foreach (var i in cardsToRemove)
                {
                    client.Hand.RemoveAll(c => c.Id == i);
                }
            }

            int additionalCardsCount = dicrease ? cardsToRemove.Count - 1 : cardsToRemove.Count;

            for (int i = 0; i < additionalCardsCount; i++)
            {
                if (HandCards.Count <= 0) break;
                client.Hand.Add(HandCards.Dequeue() as HandCard);
            }

            var updateMessage = new UpdateTableMessage();
            updateMessage.Hand = client.Hand;
            updateMessage.IsBroadcast = false;
            updateMessage.IsMyTurn = false;
            updateMessage.CardsLeftInDeck = HandCards.Count;
            return updateMessage;
        }

        private static SetTurnMessage SetNextPlayer()
        {
            var nextPlayer = Players.Dequeue();
            Players.Enqueue(nextPlayer);

            if (AbstractPlayers.First(pl => pl.Id == nextPlayer.Id).Hand.Count == 0)
            {
                nextPlayer = Players.Dequeue();
                Players.Enqueue(nextPlayer);
            }

            var directMessage = new SetTurnMessage();
            directMessage.IsBroadcast = false;
            directMessage.RecepientId = nextPlayer.Id;
            directMessage.CardsLeftInDeck = HandCards.Count;

            return directMessage;
        }

        private static EndGameMessage CreateEndGameMessage()
        {
            var endGameMessage = new EndGameMessage();
            endGameMessage.BlueScore = CalculatePoints(RoleType.Blue);
            endGameMessage.GreenScore = CalculatePoints(RoleType.Green);

            return endGameMessage;
        }

        private static int CalculatePoints(RoleType roleType)
        {
            var goldCards = Table.Tokens
                .Where(t => t.Role == roleType && t.Card.Gold > 0)
                .OrderBy(t => t.Card.Gold)
                .ToList();
            var trollsCount = Table.Tokens.Where(t => t.Role == roleType && t.Card.IsTroll).Count();
            
            int result = 0;
            
            foreach(var goldCard in goldCards)
            {
                if (trollsCount > 0)
                {
                    trollsCount--;
                    continue;
                }
                result += goldCard.Card.Gold;
            }

            return result;
        }

        private static bool CheckGameEnd()
        {
            return Table.Tokens.Count >= 12 || Table.GoldCards.All(gc => gc.IsTaken) ||
                   (HandCards.Count == 0 && AbstractPlayers.All(pl => pl.Hand.Count == 0));
        }

        private static FindGoldMessage PrepareGoldMessage()
        {
            var findGoldMessage = new FindGoldMessage();

            findGoldMessage.BlueGold = Table.Tokens.Where(t => t.Role == RoleType.Blue).Sum(t => t.Card.Gold);
            findGoldMessage.GreenGold = Table.Tokens.Where(t => t.Role == RoleType.Green).Sum(t => t.Card.Gold);

            return findGoldMessage;
        }

        private static List<Message> HandleRotateGoldCardMessage(Message message)
        {
            var rotateGoldCardMessage = (RotateGoldCardMessage) message;
            var result = new List<Message>();
            Table.UpdateAllConnections(rotateGoldCardMessage.RoleType);
            var nextPlayerMessage = SetNextPlayer();
            result.Add(nextPlayerMessage);

            return result;
        }

        #endregion

        #region Helpers

        private static void SendUpdatedGamesList(List<Message> result)
        {
            var clientConnectedMessage = new ClientConnectedMessage();

            clientConnectedMessage.Games = GameManager.RecieveAllGames();
            result.Add(clientConnectedMessage);
        }

        private static void SendHandInfo(Game game, List<Message> result)
        {
            foreach(var player in game.Players)
            {
                var handInfo = new HandInfoMessage(player.Role, player.Hand, player.Id);
                result.Add(handInfo);
            }
        }

        #endregion
    }
}
