﻿using CommonLibraryStandard.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private static TcpListener _tcpListener; // сервер для прослушивания
        readonly List<Client> _clients = new List<Client>(); // все подключения

        public void Listen()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(TcpConfig.Ip), TcpConfig.Port);
                _tcpListener.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    Client client = new Client(tcpClient, this);
                    Thread clientThread = new Thread(client.Process);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Server stopped due to exception: " + ex.Message);
                DisconnectAllClients();
            }
        }

        public void AddConnection(Client client)
        {
            Logger.Log.Info($"Client {client.Id} connected");
            _clients.Add(client);
        }

        public void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            Client client = _clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
            {
                Logger.Log.Info($"Client {client.Id} disconnected");
                _clients.Remove(client);
                MessageManager.AbstractPlayers.RemoveAll(p => p.Id == id);
            }
        }

        public void DisconnectAllClients()
        {
            Logger.Log.Info("All clients disconnected");
            _tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < _clients.Count; i++)
            {
                _clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}