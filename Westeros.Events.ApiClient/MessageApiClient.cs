
using System;
using System.Collections.Generic;
using System.Net.Http;
using Westeros.Events.ApiClient.Contracts;

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

        public IEnumerable<MessageDto> All()
        {
            return _httpClient
                .GetAsync("api/Message")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<MessageDto>>()
                .Result;
        }

        public async void DeleteMessage(int id)
        {
            await _httpClient.DeleteAsync($"api/Message/{id}");
        }

        public MessageDto GetById(int id)
        {
            return _httpClient
                       .GetAsync($"api/Message/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<MessageDto>()
                        .Result;
        }

        public async void SendMessage(MessageDto message)
        {
            await _httpClient.PostAsJsonAsync("api/Message", message);
        }
    }
}
