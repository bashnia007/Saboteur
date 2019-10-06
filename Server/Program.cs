using CommonLibrary.Tcp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CommonLibrary;

namespace Server
{
    class Program
    {
        static ServerObject server; // сервер
        static Thread listenThread; // потока для прослушивания

        static void Main(string[] args)
        {
            Logger.Write("Server started");
            try
            {
                server = new ServerObject();
                listenThread = new Thread(server.Listen);
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                Logger.Write("Server stopped due to exception: " + ex.Message, LogLevel.Error);
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
