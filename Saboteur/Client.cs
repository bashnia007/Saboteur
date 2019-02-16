using CommonLibrary.Message;
using CommonLibrary.Tcp;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows;

namespace Saboteur
{
    public class Client
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public Queue<Message> ReceivedMessages;

        public Client()
        {
            ReceivedMessages = new Queue<Message>();
        }

        /// <summary>
        /// Установка соединения с сервером и запуска отдельного потока для прослушивания новых сообщений от сервера
        /// </summary>
        public void EstablishConnection()
        {
            _client = new TcpClient(TcpConfig.Ip, TcpConfig.Port);
            _stream = _client.GetStream();

            Thread listenThread = new Thread(Listen);
            listenThread.Start();
        }

        /// <summary>
        /// Метод, отправляющий сообщение на сервер
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(Message message)
        {
            // тут происходит сериализация сообщения в массив байтов, и отправка его в поток, который слушает сервер
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_stream, message);
        }

        private void Listen()
        {
            // в бесконечном цикле
            while (true)
            {
                // получаем сообщения от сервера и сохраняем их в очереди
                var message = GetMessage();
				MessageBox.Show(((TextMessage)message).Text);
				ReceivedMessages.Enqueue(message);
            }
        }

        private Message GetMessage()
        {
            // десериализация сообщения - преобразования массива байтов, полученных от сервера, в объект типа Message
            IFormatter formatter = new BinaryFormatter();
            Message message = (Message)formatter.Deserialize(_stream);

            return message;
        }
    }
}
