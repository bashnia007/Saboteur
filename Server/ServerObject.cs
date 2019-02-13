using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary.Message;
using CommonLibrary.Tcp;

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
                _clients.Remove(client);
        }
        // прослушивание входящих подключений
        protected internal void Listen()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(TcpConfig.Ip), TcpConfig.Port);
                _tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(clientObject.Process);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        // трансляция сообщения подключенным клиентам
        protected internal void BroadcastMessage(Message message, string id)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i].Id != id) // если id клиента не равно id отправляющего
                {
                    formatter.Serialize(_clients[i].Stream, message);
                    //_clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
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
