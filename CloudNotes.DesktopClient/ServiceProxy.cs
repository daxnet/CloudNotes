using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CloudNotes.DesktopClient
{
    public class ServiceProxy : HttpClient
    {
        public ServiceProxy(ClientCredential clientCredential)
            : base(new HttpClientHandler
                       {
                           Credentials = new NetworkCredential(clientCredential.UserName, clientCredential.Password)
                       }, true)
        {
            this.BaseAddress =
                new Uri(
                    clientCredential.ServerUri.EndsWith("/")
                        ? clientCredential.ServerUri
                        : clientCredential.ServerUri + "/");
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
