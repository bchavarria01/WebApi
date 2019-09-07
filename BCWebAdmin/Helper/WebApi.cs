using System;
using System.Net.Http;

namespace BCWebAdmin.Helper
{
    public class WebApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            return client;
        }
    }
}
