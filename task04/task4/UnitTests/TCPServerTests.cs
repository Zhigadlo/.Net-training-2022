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
        private IPAddress _ip = IPAddress.Parse("127.0.0.1");
        private int _port = 8005;

        [Fact]
        public void ServerReadTest()
        {
            TcpServer server = new TcpServer(_ip, _port);
            TcpClient client = new TcpClient();
            client.Connect(_ip, 8005);
            NetworkStream stream = client.GetStream();
            double[] values = new double[] { 3, 5, 6, 1 };
            string message = Parsing.ArrayToString(values);
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

            string actual = server.Read();
            double[] actualArray = Parsing.StringToDoubleArray(actual);

            for (int i = 0; i < actualArray.Length; i++)
                Assert.Equal(values[i], actualArray[i]);

            server.Dispose();
        }

        [Fact]
        public void ServerWriteTest()
        {
            TcpServer server = new TcpServer(_ip, _port);
            TcpClient client = new TcpClient();
            client.Connect(_ip, _port);
            string myMessege = "Hello World";
            server.Write(myMessege);
            NetworkStream stream = client.GetStream();
            byte[] data = new byte[64];

            StringBuilder builder = new StringBuilder();
            int bytes;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            string message = builder.ToString();

            server.Dispose();

            Assert.Equal(message, myMessege);
        }

        [Fact]
        public void ServerDoOperationTest()
        {
            TcpServer server = new TcpServer(_ip, _port);
            Gauss gauss = new Gauss();
            double[,] matrix = new double[,] { { 3, -3, 2, 2 }, { 4, -5, 2, 1 }, { 5, -6, 4, 3 } };
            server.OperationEvent += gauss.Solve;
            string answer = server.DoOperation(matrix);
            double[] actualAnswers = Parsing.StringToDoubleArray(answer);

            double[] expectedAnswers = { 1, 1, 1 };

            for(int i = 0; i < actualAnswers.Length; i++)
                Assert.Equal(expectedAnswers[i], actualAnswers[i]);
            server.Dispose();
        }
    }
}