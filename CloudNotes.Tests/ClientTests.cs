using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudNotes.Tests
{
    [TestClass]
    public class ClientTests
    {
        //[TestMethod]
        public void ConnectivityTest()
        {
            var clientHandler = new HttpClientHandler {Credentials = new NetworkCredential("admin", "Admin`123")};
            clientHandler.UseProxy = true;
            //clientHandler.Proxy = new WebProxy("http://daxnetvpn.cloudapp.net");
            clientHandler.Proxy = new WebProxy("daxnetvpn.cloudapp.net", 443);
            var client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("http://daxnetsvr.cloudapp.net:9023/api/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var pingResult = client.GetAsync("ping").Result;
            var json = pingResult.Content.ReadAsStringAsync().Result;
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }
    }
}
