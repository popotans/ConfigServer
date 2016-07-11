﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConfigServer.Core
{
    internal interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }

    internal class HttpClientWrapper : IHttpClientWrapper
    {
        readonly IConfigServerClientAuthenticator authenticator;

        public HttpClientWrapper(IConfigServerClientAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        public HttpResponseMessage Get(Uri uri)
        {
            return GetAsync(uri).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {              
                return await authenticator.ApplyAuthentication(httpClient).GetAsync(uri);                
            }
        }
    }
}