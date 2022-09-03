using System.Net;
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
    public class TcpServer : IDisposable
    {
        protected static TcpListener _server;
        public delegate double[] Operation(double[,] matrix);
        public event Operation OperationEvent;
        private bool _isNotDisposed;
        public TcpServer(IPAddress ip, int port)
        {
            _server = new TcpListener(ip, port);
        }
        /// <summary>
        /// Starts server
        /// </summary>
        public virtual void StartAsync()
        {
            _server.Start();
            _isNotDisposed = true;
            ListenAsync();
        }
        /// <summary>
        /// Starts listening of requests
        /// </summary>
        protected async virtual void ListenAsync()
        {
            while (_isNotDisposed)
            {
                try
                {
                    TcpClient client = await _server.AcceptTcpClientAsync();

                    NetworkStream stream = client.GetStream();

                    byte[] bytes = new byte[1024];
                    string message = Read(stream, bytes);
                    try
                    {
                        double[,] matrix = Parsing.StringToMultidemensionalDoubleArray(message);
                        string messageToClient = DoOperation(matrix);
                        Write(stream, bytes, messageToClient);
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
        /// <summary>
        /// Read request of client from network stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected virtual string Read(NetworkStream stream, byte[] bytes)
        {
            int data = stream.Read(bytes, 0, bytes.Length);
            return Encoding.Unicode.GetString(bytes, 0, data);
        }
        /// <summary>
        /// Write request to network stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytes"></param>
        /// <param name="message"></param>
        protected virtual void Write(NetworkStream stream, byte[] bytes, string message)
        {
            bytes = Encoding.Unicode.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// Do some operation 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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