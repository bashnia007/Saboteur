using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        public string Id { get; set; }

        private TcpClient _client;
        private Server _server;
        private NetworkStream _stream;

        public Client(TcpClient tcpClient, Server server)
        {
            Id = Guid.NewGuid().ToString();
            _client = tcpClient;
            _server = server;
            _server.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                _stream = _client.GetStream();
                while(true)
                {

                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error($"Client {Id} process stopped due exception: " + ex.Message);
            }
            finally
            {
                _server.RemoveConnection(this.Id);
                Close();
            }
        }

        // закрытие подключения
        protected internal void Close()
        {
            Logger.Log.Info("Close connection for client " + Id);
            _stream?.Close();
            _client?.Close();
        }
    }
}
