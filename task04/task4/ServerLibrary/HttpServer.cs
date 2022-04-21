using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

namespace ServerLibrary
{
    public class HttpServer : TcpServer
    {
        private string _ipAddress;
        public HttpServer(IPAddress ip, int port) : base(ip, port)
        {
            _ipAddress = ip.ToString() + ":" + port.ToString();
        }

        public override void StartAsync()
        {
            base.StartAsync();
        }

        public override void ListenAsync()
        {
            base.ListenAsync();
        }

        protected override void Write(NetworkStream stream, byte[] bytes, string message)
        {
            message = "HTTP/1.1 200 OK\n" +
                      "Content-type: text/html\n" +
                      "Content-Length: " + message.Length +
                      "\r\n\r\n" + message;
            base.Write(stream, bytes, message);
        }

        protected override string Read(NetworkStream stream, byte[] bytes)
        {
            string str = base.Read(stream, bytes);
            return str.Split("\r\n\r\n")[1];
        }
        protected override string DoOperation(double[,] matrix)
        {
            return base.DoOperation(matrix);
        }
    }
}
