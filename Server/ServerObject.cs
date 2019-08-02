using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using CommonLibrary.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Server
{
    public class ServerObject
    {
        static TcpListener _tcpListener; // сервер для прослушивания
        readonly List<ClientObject> _clients = new List<ClientObject>(); // все подключения

        protected internal void AddConnection(ClientObject clientObject)
        {
            _clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            ClientObject client = _clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
            {
                Console.WriteLine("Client disconnected");
                _clients.Remove(client);
            }
        }
        // прослушивание входящих подключений
        protected internal void Listen()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(TcpConfig.Ip), TcpConfig.Port);
                _tcpListener.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(clientObject.Process);
                    clientThread.Start();
                    Console.WriteLine("Client connected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        // трансляция сообщения подключенным клиентам
        protected internal void SendMessage(Message message, string id)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (message.IsBroadcast)
            {
                foreach (var client in _clients)
                {
                    formatter.Serialize(client.Stream, message);
                }
            }
            else
            {
                if (message.IsTurnMessage)
                {
                    var directMessage = message as SetTurnMessage;
                    formatter.Serialize(_clients.First(c => c.Id == directMessage.RecepientId).Stream, message);
                }
                else
                {
                    formatter.Serialize(_clients.First(c => c.Id == id).Stream, message);
                }
            }
        }

        protected internal void LaunchGame()
        {
            if(!_clients.All(c => c.IsReady) || _clients.Count != 2) return;
            Console.WriteLine("All players are ready, let's start!");
            var launcher = new Launcher(_clients.Select(c => c.Id).ToList());
            launcher.ProvideRolesForPlayers();
            launcher.ProvideHandCardsForPlayers();
            foreach (var client in _clients)
            {
                var player = launcher.Players.First(pl => pl.Id == client.Id);
                var gameMessage = new UpdateTableMessage();
                gameMessage.IsBroadcast = false;
                gameMessage.RoleCard = player.Role;
                gameMessage.Hand = player.Hand;
                gameMessage.IsMyTurn = player.Role.Role == RoleType.Green;
                SendMessage(gameMessage, client.Id);

                var initializeTableMessage = new InitializeTableMessage();
                initializeTableMessage.GoldCards = launcher.GoldCardsForGame;
                initializeTableMessage.StartCards = launcher.StartCards;
                SendMessage(initializeTableMessage, client.Id);
            }

            MessageManager.Players.Enqueue(_clients.First(c => c.Id != launcher.Players.First(pl => pl.Role.Role == RoleType.Green).Id));
            MessageManager.Players.Enqueue(_clients.First(c => c.Id == launcher.Players.First(pl => pl.Role.Role == RoleType.Green).Id));
            
            
            MessageManager.AbstractPlayers = launcher.Players;
            MessageManager.HandCards = launcher.ShuffledHandCards;
        }

        // отключение всех клиентов
        protected internal void Disconnect()
        {
            _tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < _clients.Count; i++)
            {
                _clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}
