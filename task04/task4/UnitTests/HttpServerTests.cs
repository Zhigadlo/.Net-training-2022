using Xunit;
using ServerLibrary;
using System.Net;
using System.Net.Http;
using SolvingSOLE;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace UnitTests
{
    public class HttpServerTests
    {
        private IPAddress _ip = IPAddress.Parse("127.0.1.1");
        private int _port = 8008;
        
        [Fact]
        public async void HttpServerWriteTest()
        {
            double[] answers = { 1, 1, 1 };
            HttpServer httpServer = new HttpServer(_ip, _port);
            Gauss gauss = new Gauss();
            httpServer.OperationEvent += gauss.Solve;
            httpServer.StartAsync();

            double[] actualAnswers = ClientRequest();

            for (int i = 0; i < actualAnswers.Length; i++)
                Assert.Equal(answers[i], actualAnswers[i]);

            httpServer.Dispose();
        }
        private double[] ClientRequest()
        {
            double[,] matrix = new double[,] { { 3, -3, 2, 2 }, { 4, -5, 2, 1 }, { 5, -6, 4, 3 } };
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(_ip, _port);
            NetworkStream stream = tcpClient.GetStream();
            string message = Parsing.MultidemensionalDoubleArrayToString(matrix);

            message = "HTTP/1.1 200 OK\n" +
                      "Content-type: text/html\n" +
                      "Content-Length: " + message.Length +
                      "\r\n\r\n" + message;
            stream.Write(Encoding.Unicode.GetBytes(message));
            byte[] bytes = new byte[10000];
            stream.Read(bytes, 0, bytes.Length);

            message = Encoding.Unicode.GetString(bytes);
            message = message.Split("\r\n\r\n")[1];
            return Parsing.StringToDoubleArray(message);
        }
    }
}
