using CommonLibraryStandard.TCP;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace XamarinApp.TCP
{
    public class Client
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _listenThread;

        /// <summary>
        /// Установка соединения с сервером и запуска отдельного потока для прослушивания новых сообщений от сервера
        /// </summary>
        public void EstablishConnection()
        {
            _client = new TcpClient(TcpConfig.Ip, TcpConfig.Port);
            _stream = _client.GetStream();

            _listenThread = new Thread(Listen);
            _listenThread.Start();
        }

        private void Listen()
        {

        }

        private void Disconnect()
        {
            _listenThread.Abort();
            _client.Close();
        }
    }
}
