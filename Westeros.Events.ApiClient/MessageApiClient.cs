
using System;
using System.Collections.Generic;
using System.Net.Http;
using Westeros.Events.Data.Model;

namespace Westeros.Events.ApiClient
{
    class MessageApiClient : IEventsApiClient
    {
        HttpClient _httpClient;
      
        public MessageApiClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);

        }

        public IEnumerable<Message> All()
        {
            return _httpClient
                .GetAsync("api/Message")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Message>>()
                .Result;
        }

        public async void DeleteMessage(int id)
        {
            await _httpClient.DeleteAsync($"api/Message/{id}");
        }

        public Message GetById(int id)
        {
            return _httpClient
                       .GetAsync($"api/Message/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<Message>()
.Result;
        }

        public async void SendMessage(Message message)
        {
            await _httpClient.PostAsJsonAsync("api/Message", message);
        }
    }
}
