﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Message;

namespace Server
{
    public class ClientObject
    {
        public string Id { get; }
        public NetworkStream Stream { get; set; }
        private TcpClient client;
        private ServerObject server; // объект сервера

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message = GetMessage();
                Console.WriteLine(message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    message = GetMessage();
                    Console.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }
        
        private string GetMessage()
        {
            IFormatter formatter = new BinaryFormatter();
            Message p = (Message)formatter.Deserialize(Stream);

            return String.Empty;
        }

        // закрытие подключения
        protected internal void Close()
        {
            Stream?.Close();
            client?.Close();
        }
    }
}
