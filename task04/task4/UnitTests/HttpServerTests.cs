using Xunit;
using ServerLibrary;
using System.Net;
using System.Net.Http;
using System.IO;

namespace UnitTests
{
    public class HttpServerTests
    {
        private IPAddress _ip = IPAddress.Parse("127.0.0.1");
        private int _port = 8888;
        [Fact]
        public async void HttpServerWriteTest()
        {
            //string message = "Hello world";
            //HttpServer server = new HttpServer(_ip, _port);
            //server.Start();

            //HttpClient client = new HttpClient();
            //HttpRequestMessage request = new HttpRequestMessage();
            //request.Method = HttpMethod.Post;
            //request.RequestUri = new System.Uri("http://" + _ip.ToString() + ":" + _port.ToString());
            //server.Write(message);
            //HttpResponseMessage response = await client.SendAsync(request);
            
            //string actualMessage = response.Content.ToString();
            //Assert.Equal(message, actualMessage);
        }
    }
}
