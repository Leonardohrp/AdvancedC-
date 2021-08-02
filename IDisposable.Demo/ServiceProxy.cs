using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IDisposable.Demo
{
    public class ServiceProxy : System.IDisposable
    {
        private readonly HttpClient httpClient;
        private bool disposed;
        public ServiceProxy(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        ~ServiceProxy()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Dispose managed objects
                httpClient.Dispose();
            }

            // Dispose unmanage objects

            disposed = true;
        }

        public void Get()
        {
            var response = httpClient.GetAsync("");
        }

        public void Post(string request)
        {
            var response = httpClient.PostAsync("", new StringContent(request));
        }
    }
}
