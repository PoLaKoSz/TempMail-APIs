using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoLaKoSz.TempMail.DataAccessLayer.Web
{
    /// <summary>
    /// Simple web access layer only for the bare minimum.
    /// </summary>
    public abstract class MailService
    {
        private IHttpClient _client;
        private readonly Uri _baseAddress;



        /// <summary>
        /// This ctor only for UnitTesting!
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="httpClient"></param>
        public MailService(Uri baseAddress, IHttpClient httpClient)
        {
            _baseAddress = baseAddress;

            _client = httpClient;
        }



        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        protected async Task<string> GetAsync()
        {
            return await GetAsync(_baseAddress);
        }

        protected async Task<string> GetAsync(string segment)
        {
            return await GetAsync(new Uri(_baseAddress, segment));
        }

        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        protected async Task<string> GetAsync(Uri requestUri)
        {
            var httpResponse = await _client.GetAsync(_baseAddress);

            var asd = await httpResponse.Content.ReadAsStringAsync();

            //System.IO.File.WriteAllText($"{GetType()}.html", asd, System.Text.Encoding.UTF8);

            return asd;
        }
    }
}
