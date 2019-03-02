using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using System;

namespace Server
{
    public class MessageManager
    {
        private readonly ClientObject _client;

        public MessageManager(ClientObject client)
        {
            _client = client;
        }

        public Message HandleMessage(Message message)
        {
            var type = message.MessageType;
            switch (type)
            {
                case GameMessageType.InitializeMessage:
                    return HandleInitializeMessage(message);

                case GameMessageType.TextMessage:
                    return HandleTextMessage(message);

                case GameMessageType.ReadyToPlay:
                    return HandleReadyToPlayMessage(message);

                case GameMessageType.BuildMessage:
                    return HandleBuildMessage(message);

                default: throw new NotImplementedException();
            }
        }

        #region Private methods

        private InitializeMessage HandleInitializeMessage(Message message)
        {
            return new InitializeMessage
            {
                Id = _client.Id,
                IsBroadcast = false
            };
        }

        private TextMessage HandleTextMessage(Message message)
        {
            return new TextMessage
            {
                Text = ((TextMessage)message).Text,
                SenderId = _client.Id
            };
        }

        private GameMessage HandleReadyToPlayMessage(Message message)
        {
            _client.IsReady = true;
            _client.Server.LaunchGame();
            return new GameMessage
            {
                MessageType = GameMessageType.ReadyToPlay,
                SenderId = _client.Id
            };
        }

        private BuildMessage HandleBuildMessage(Message message)
        {
            var receivedMessage = (BuildMessage)message;
            receivedMessage.IsBroadcast = true;
            return receivedMessage;
        }

        #endregion
    }
}
