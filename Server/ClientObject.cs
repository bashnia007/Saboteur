using System;
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
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    var message = GetMessage();
                    Console.WriteLine(message);
                    server.BroadcastMessage(message, this.Id);
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
        
        private Message GetMessage()
        {
            IFormatter formatter = new BinaryFormatter();
            Message message = (Message)formatter.Deserialize(Stream);

            return message;
        }

        // закрытие подключения
        protected internal void Close()
        {
            Stream?.Close();
            client?.Close();
        }
    }
}
