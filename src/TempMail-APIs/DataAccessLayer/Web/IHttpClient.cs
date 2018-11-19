﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PoLaKoSz.TempMail.DataAccessLayer.Web
{
    public interface IHttpClient
    {
        /// <summary>
        /// Gets the headers which should be sent with each request.
        /// </summary>
        /// <returns>The headers which should be sent with each request.</returns>
        HttpRequestHeaders DefaultRequestHeaders { get; }

        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.</exception>
        Task<HttpResponseMessage> GetAsync(Uri requestUri);

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.</exception>
        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
    }
}
