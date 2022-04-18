using System.Net;
using System.Net.Http.Headers;

namespace ServerLibrary
{
    public class HttpServer : TcpServer
    {
        public HttpServer(IPAddress ip, int port) : base(ip, port)
        {
            
        }

        public override string Read()
        {
            return base.Read();
        }

        public override void Write(string messege)
        {
            base.Write(messege);
        }

        public override string DoOperation(double[,] matrix)
        {
            return base.DoOperation(matrix);
        }
    }
}
