using Xunit;
using ServerLibrary;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UnitTests
{
    public class TCPServerTests
    {
        [Fact]
        public void Test1()
        {
            TCPServer server = new TCPServer(IPAddress.Parse("127.0.0.1"), 8005);
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 8005);
            NetworkStream stream = client.GetStream();
            double[] values = new double[] { 3, 5, 6, 1 };
            string message = values.ToString();
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

            string actual = server.Read();

            Assert.Equal(message, actual);
        }
    }
}