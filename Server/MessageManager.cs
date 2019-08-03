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
                Text = ((TextMessage)message).Text,
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

            var buildMessage = (BuildMessage)message;
            result.Add(buildMessage);

            // check if user can build card
            if (Validator.ValidateBuildingTunnelAction(buildMessage.RouteCard, Table.OpenedCards))
            //if (true)
            {
                buildMessage.IsSuccessfulBuild = true;
                buildMessage.IsBroadcast = true;

                var updateMessage = ProvidePlayerNewCards(client.Id, 1, buildMessage.CardId);
                result.Add(updateMessage);

                var directMessage = SetNextPlayer();
                result.Add(directMessage);

                Table.OpenedCards.Add(buildMessage.RouteCard);
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
            var actionMessage = (ActionMessage)message;

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
                    if (!player.BrokenEquipments.Contains(Equipment.Pick))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Pick);
                    }
                    break;
                case ActionType.FixTrolly:
                    if (!player.BrokenEquipments.Contains(Equipment.Trolley))
                    {
                        resultMessage.IsSuccessful = true;
                        player.BrokenEquipments.Remove(Equipment.Trolley);
                    }
                    break;
            }

            resultMessage.Players = Table.Players;
            result.Add(resultMessage);

            return result;
        }

        private static UpdateTableMessage ProvidePlayerNewCards(string clientId, int count, int cardToRemove = -1)
        {
            var client = AbstractPlayers.First(pl => pl.Id == clientId);

            if (cardToRemove >= 0)
            {
                client.Hand.RemoveAll(c => c.Id == cardToRemove);
            }

            for (int i = 0; i < count; i++)
            {
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

            var directMessage = new SetTurnMessage();
            directMessage.IsBroadcast = false;
            directMessage.RecepientId = nextPlayer.Id;

            return directMessage;
        }

        #endregion
    }
}
