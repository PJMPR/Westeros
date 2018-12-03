using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Westeros.Events.Data.Model;

namespace Westeros.Events.ApiClient
{
    class ApiClient
    {
        HttpClient _httpClient;
      
        public ApiClient()
        {
            _httpClient = new HttpClient();
            
        }
        public void SendMessage(Message message)
        {
            //_httpClient.PostAsJsonAsync("api/Message")
        }
    }
}
