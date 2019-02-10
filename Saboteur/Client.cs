using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary.Message;
using CommonLibrary.Tcp;

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

        public void EstablishConnection()
        {
            _client = new TcpClient(TcpConfig.Ip, TcpConfig.Port);
            _stream = _client.GetStream();

            //Thread listenThread = new Thread(Listen);
            //listenThread.Start();
        }

        public void SendMessage(Message message)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            /*using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, message);
                var array = ms.ToArray();
                _stream.Write(array, 0, array.Length);
            }*/
            formatter.Serialize(_stream, message);
        }

        public void Listen()
        {
            var data = new byte[1024 * 1000]; // буфер для получаемых данных
            Queue<byte[]> receivedBytes = new Queue<byte[]>();
            BinaryFormatter formatter = new BinaryFormatter();
            while (true)
            {
                int bytes = 0;
                do
                {
                    bytes = _stream.Read(data, 0, data.Length);
                    receivedBytes.Enqueue(data);
                }
                while (_stream.DataAvailable);


                using (MemoryStream ms = new MemoryStream(data))
                {
                    Message receivedMessage = (Message)formatter.Deserialize(ms);
                    ReceivedMessages.Enqueue(receivedMessage);
                }
            }
        }
    }
}
