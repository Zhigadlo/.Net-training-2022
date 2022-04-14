using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerLibrary
{
    public class TCPServer : IServer, IDisposable
    {
        private static TcpListener _server;
        private static TcpClient _client;
        public TCPServer(IPAddress ip, int port)
        {
            _server = new TcpListener(ip, port);
            _server.Start();
        }

        public string Read()
        {
            while (true)
            {
                TcpClient client = _server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    return message;
                }
            }
        }


        public void Dispose()
        {
            _server.Stop();
        }
    }
}