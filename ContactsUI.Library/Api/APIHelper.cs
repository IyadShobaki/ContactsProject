using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ContactsUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
