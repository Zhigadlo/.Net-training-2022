using Xunit;
using ServerLibrary;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SolvingSOLE;

namespace UnitTests
{
    public class TCPServerTests
    {
        private IPAddress _ip = IPAddress.Parse("127.0.0.2");
        private int _port = 8005;

        [Fact]
        public void ServerTest()
        {
            double[] answers = { 1, 1, 1 };
            TcpServer tcpServer = new TcpServer(_ip, _port);
            Gauss gauss = new Gauss();
            tcpServer.StartAsync();
            tcpServer.OperationEvent += gauss.Solve;
            
            double[] actualAnswers = ClientRequest();
            
            for (int i = 0; i < actualAnswers.Length; i++)
                Assert.Equal(answers[i], actualAnswers[i]);

            tcpServer.Dispose();
        }

        private double[] ClientRequest()
        {
            double[,] matrix = new double[,] { { 3, -3, 2, 2 }, { 4, -5, 2, 1 }, { 5, -6, 4, 3 } };
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(_ip, _port);
            NetworkStream stream = tcpClient.GetStream();
            string message = Parsing.MultidemensionalDoubleArrayToString(matrix);
            stream.Write(Encoding.Unicode.GetBytes(message));
            byte[] bytes = new byte[10000];
            stream.Read(bytes, 0, bytes.Length);

            message = Encoding.Unicode.GetString(bytes);
            return Parsing.StringToDoubleArray(message);
        }
    }
}