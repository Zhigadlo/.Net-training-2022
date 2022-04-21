using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

namespace ServerLibrary
{
    /// <summary>
    /// Before starting the server, you need to sign the event to OperationEvent.
    /// After starting, the server waits for requests, the request contains a matrix,
    /// after recieving the request, the server sends the solved SOLE.
    /// At the and of the server operation, you must call the Dispose method.
    /// </summary>
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
        protected override void ListenAsync()
        {
            base.ListenAsync();
        }
        /// <summary>
        /// Adds header to tcp request and send it to network stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytes"></param>
        /// <param name="message"></param>
        protected override void Write(NetworkStream stream, byte[] bytes, string message)
        {
            message = "HTTP/1.1 200 OK\n" +
                      "Content-type: text/html\n" +
                      "Content-Length: " + message.Length +
                      "\r\n\r\n" + message;
            base.Write(stream, bytes, message);
        }
        /// <summary>
        /// Removes header from http request and return message
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
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
