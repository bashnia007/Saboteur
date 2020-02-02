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
        static Server server; // сервер
        static Thread listenThread; // потока для прослушивания

        static void Main(string[] args)
        {
            Logger.InitLogger();
            Logger.Log.Info("Server started");
            try
            {
                server = new Server();
                listenThread = new Thread(server.Listen);
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Server stopped due to exception: " + ex.Message);
                server.DisconnectAllClients();
                listenThread.Interrupt();
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
