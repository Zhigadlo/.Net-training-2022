using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerLibrary
{
    public class TcpServer : IServer, IDisposable
    {
        private static TcpListener _server;
        public delegate double[] Operation(double[,] matrix);
        public event Operation OperationEvent;
        public TcpServer(IPAddress ip, int port)
        {
            _server = new TcpListener(ip, port);
            _server.Start();
        }

        public string Read()
        {
            TcpClient client = _server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            byte[] data = new byte[64]; // буфер для получаемых данных
            
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
        public string DoOperation(double[,] matrix)
        {
            if (OperationEvent != null)
            {
                double[] data = OperationEvent.Invoke(matrix);
                return Parsing.ArrayToString(data);
            }
            else
                throw new Exception("Operation is null");
        }
        public void Write(string messege)
        {
            TcpClient client = _server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            byte[] bytes = Encoding.Unicode.GetBytes(messege);
            stream.Write(bytes);
        }

        public void Dispose()
        {
            _server.Stop();
        }
    }
}