using System;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;

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
                    return new InitializeMessage
                    {
                        Id = _client.Id,
                        IsBroadcast = false
                    };
                case GameMessageType.TextMessage:
                    return new TextMessage
                    {
                        Text = ((TextMessage)message).Text,
                        SenderId = _client.Id
                    };
                case GameMessageType.ReadyToPlay:
                    _client.IsReady = true;
                    _client.Server.LaunchGame();
                    return new GameMessage
                    {
                        MessageType = GameMessageType.ReadyToPlay,
                        SenderId = _client.Id
                    };
                default: throw new NotImplementedException();
            }
        }
    }
}
