﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Features;
using System.Security.Claims;
using System.Threading;
using System.IO;

namespace ConfigServer.Core.Hosting
{
    public class TestHttpContext : HttpContext
    {
        public TestHttpContext(string path)
        {
            Request = new TestHttpRequest(path);
        }

        public override AuthenticationManager Authentication { get { throw new NotImplementedException(); } }

        public override ConnectionInfo Connection { get { throw new NotImplementedException(); } }

        public override IFeatureCollection Features { get { throw new NotImplementedException(); } }

        public override IDictionary<object, object> Items { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override HttpRequest Request { get; }

        public override CancellationToken RequestAborted { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override IServiceProvider RequestServices { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override HttpResponse Response { get { throw new NotImplementedException(); } }

        public override ISession Session { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override string TraceIdentifier { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override ClaimsPrincipal User { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override WebSocketManager WebSockets { get { throw new NotImplementedException(); } }

        public override void Abort()
        {
            throw new NotImplementedException();
        }
    }

    public class TestHttpRequest : HttpRequest
    {
        public TestHttpRequest(string path)
        {
            Path = path;
        }

        public override Stream Body { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override long? ContentLength { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override string ContentType { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override IRequestCookieCollection Cookies { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override IFormCollection Form { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override bool HasFormContentType { get { throw new NotImplementedException(); } }

        public override IHeaderDictionary Headers { get { throw new NotImplementedException(); } }

        public override HostString Host { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override HttpContext HttpContext { get { throw new NotImplementedException(); } }

        public override bool IsHttps { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override string Method { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override PathString Path { get; set; }

        public override PathString PathBase { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override string Protocol { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override IQueryCollection Query { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override QueryString QueryString { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override string Scheme { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }

    public class TestHttpResponse : HttpResponse
    {
        public override Stream Body { get; set; }

        public override long? ContentLength { get; set; }

        public override string ContentType { get; set; }

        public override IResponseCookies Cookies
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool HasStarted
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IHeaderDictionary Headers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override HttpContext HttpContext
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int StatusCode { get; set; }

        public override void OnCompleted(Func<object, Task> callback, object state)
        {
            throw new NotImplementedException();
        }

        public override void OnStarting(Func<object, Task> callback, object state)
        {
            throw new NotImplementedException();
        }

        public override void Redirect(string location, bool permanent)
        {
            throw new NotImplementedException();
        }
    }
}
