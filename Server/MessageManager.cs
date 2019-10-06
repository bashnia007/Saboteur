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
        }

        public static List<Message> HandleMessage(Message message, ClientObject client)
        {
            var type = message.MessageType;
            switch (type)
            {
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

                default: throw new NotImplementedException();
            }
        }

        #region Private methods

        private static List<Message> HandleInitializeMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();
            result.Add(new InitializeMessage
            {
                Id = client.Id,
                IsBroadcast = false
            });

            return result;
        }

        private static List<Message> HandleTextMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();
            result.Add(new TextMessage
            {
                Text = ((TextMessage) message).Text,
                SenderId = client.Id
            });

            return result;
        }

        private static List<Message> HandleReadyToPlayMessage(Message message, ClientObject client)
        {
            var result = new List<Message>();
            client.IsReady = true;
            client.Server.LaunchGame();
            result.Add(new GameMessage
            {
                MessageType = GameMessageType.ReadyToPlay,
                SenderId = client.Id
            });

            return result;
        }

        private static List<Message> HandleBuildMessage(Message message, ClientObject client)
        {
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

                var directMessage = SetNextPlayer();
                result.Add(directMessage);
                result.Add(PrepareGoldMessage());

                if (CheckGameEnd()) result.Add(CreateEndGameMessage());


                Table.AddCard(buildMessage.RouteCard);

                var goldCardsToOpen = Table.GoldCards
                    .Where(goldCard => 
                        goldCard.Coordinates.IsNeighbour(buildMessage.RouteCard.Coordinates) && 
                        !goldCard.IsOpen 
                        && !Table.OpenedCards.Contains(goldCard))
                    .ToList();

                foreach (var goldCard in goldCardsToOpen)
                {
                    if (!Validator.CheckForGold(goldCard, Table.OpenedCards, buildMessage.RoleType))
                        goldCard.Rotate();
                    goldCard.IsOpen = true;
                    Table.OpenedCards.Add(goldCard);
                    var exploreMessage = new ExploreMessage();
                    exploreMessage.IsBroadcast = true;
                    exploreMessage.Card = goldCard;
                    exploreMessage.Coordinates = goldCard.Coordinates;

                    result.Add(exploreMessage);
                }

                Table.UpdateAllConnections(buildMessage.RoleType);
            }
            else
            {
                buildMessage.IsSuccessfulBuild = false;
                buildMessage.IsBroadcast = false;
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

        private static UpdateTableMessage ProvidePlayerNewCards(string clientId, List<int> cardsToRemove)
        {
            var client = AbstractPlayers.First(pl => pl.Id == clientId);

            if (cardsToRemove.Count >= 0)
            {
                foreach (var i in cardsToRemove)
                {
                    client.Hand.RemoveAll(c => c.Id == i);
                }
            }

            for (int i = 0; i < cardsToRemove.Count; i++)
            {
                if (HandCards.Count <= 0) break;
                client.Hand.Add(HandCards.Dequeue() as HandCard);
            }

            var updateMessage = new UpdateTableMessage();
            updateMessage.Hand = client.Hand;
            updateMessage.IsBroadcast = false;
            updateMessage.IsMyTurn = false;
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

            return directMessage;
        }

        private static EndGameMessage CreateEndGameMessage()
        {
            var endGameMessage = new EndGameMessage();
            endGameMessage.BlueScore = Table.Tokens.Where(t => t.Role == RoleType.Blue).Sum(t => t.Card.Gold);
            endGameMessage.GreenScore = Table.Tokens.Where(t => t.Role == RoleType.Green).Sum(t => t.Card.Gold);

            return endGameMessage;
        }

        private static bool CheckGameEnd()
        {
            return Table.Tokens.Count >= 8 || Table.GoldCards.All(gc => gc.IsTaken) ||
                   (HandCards.Count == 0 && AbstractPlayers.All(pl => pl.Hand.Count == 0));
        }

        private static FindGoldMessage PrepareGoldMessage()
        {
            var findGoldMessage = new FindGoldMessage();

            findGoldMessage.BlueGold = Table.Tokens.Where(t => t.Role == RoleType.Blue).Sum(t => t.Card.Gold);
            findGoldMessage.GreenGold = Table.Tokens.Where(t => t.Role == RoleType.Green).Sum(t => t.Card.Gold);

            return findGoldMessage;
        }

        #endregion
    }
}
