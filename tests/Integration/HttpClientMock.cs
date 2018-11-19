using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PoLaKoSz.TempMail.DataAccessLayer.Web;

namespace PoLaKoSz.TempMail.Tests.Integration
{
    /// <summary>
    /// Mock the HttpClient. Use the ResponseFromServer property to change what
    /// should be returned from the fase server.
    /// </summary>
    class HttpClientMock : IHttpClient
    {
        public HttpRequestHeaders DefaultRequestHeaders { get; }
        public string ResponseFromServer { get; set; }
        public Uri LastCalledURL { get; private set; }
        public Uri BaseAddress { get; }



        public HttpClientMock()
        {
            DefaultRequestHeaders = new HttpRequestMessage().Headers;
            DefaultRequestHeaders.Add("Accept", "*/*");
            DefaultRequestHeaders.Add("User-Agent", "github.com PoLaKoSz Deezer API");

            ResponseFromServer = "";

            BaseAddress = new Uri("https://api.deezer.com/");
        }



        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            LastCalledURL = requestUri;

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ResponseFromServer)
            };

            return Task.Run(() => httpResponse);
        }
    }
}
