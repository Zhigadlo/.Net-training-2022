using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerLibrary
{
    public class TcpServer : IServer, IDisposable
    {
        protected static TcpListener _server;
        public delegate double[] Operation(double[,] matrix);
        public event Operation OperationEvent;
        private bool _isNotDisposed;
        public TcpServer(IPAddress ip, int port)
        {
            _server = new TcpListener(ip, port);
        }
        public void StartAsync()
        {
            _server.Start();
            _isNotDisposed = true;
            ListenAsync();
        }
        public async virtual void ListenAsync()
        {
            while (_isNotDisposed)
            {
                try
                {
                    TcpClient client = await _server.AcceptTcpClientAsync();

                    NetworkStream stream = client.GetStream();

                    byte[] bytes = new byte[1024];     // готовим место для принятия сообщения
                    int data = stream.Read(bytes, 0, bytes.Length);   // читаем сообщение от клиента
                    string message = Encoding.Default.GetString(bytes, 0, data); // выводим на экран полученное сообщение в виде строки
                    try
                    {
                        double[,] matrix = Parsing.StringToTwoDemensionalDoubleArray(message);
                        string mesaageToClient = DoOperation(matrix);
                        bytes = Encoding.Unicode.GetBytes(mesaageToClient);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                        throw new Exception("Parsing exception, client message is not correct");
                    }
                    client.Close();
                }
                catch
                {
                    continue;
                }
            }
        }
        protected virtual string DoOperation(double[,] matrix)
        {
            if (OperationEvent != null)
            {
                double[] data = OperationEvent.Invoke(matrix);
                return Parsing.ArrayToString(data);
            }
            else
                throw new Exception("Operation is null");
        }

        public void Dispose()
        {
            _server.Stop();
            _isNotDisposed = false;
            GC.SuppressFinalize(this);
        }
    }
}