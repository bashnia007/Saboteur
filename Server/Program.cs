using CommonLibrary.Tcp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static ServerObject server; // сервер
        static Thread listenThread; // поток для прослушивания
        static void Main(string[] args)
        {
            /*try
            {
                server = new ServerObject();
                listenThread = new Thread(server.Listen);
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }*/
			Launcher launcher = new Launcher();
			var temp = launcher.Players.Count;
        }
    }
}
