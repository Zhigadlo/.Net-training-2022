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

        //public override string StartListen()
        //{
        //    return base.StartListen();
        //}

        //public override async void Write(string message)
        //{
        //    message = "HTTP/1.1 200 OK\nContent-Type: text\nContent-Length: " + message.Length + "\n\n" + message;
        //    base.Write(message);
        //}

        //public override string DoOperation(double[,] matrix)
        //{
        //    return base.DoOperation(matrix);
        //}
    }
}
