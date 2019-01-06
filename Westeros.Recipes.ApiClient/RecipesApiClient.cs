using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Westeros.Demo.ApiClient.Contracts;
using Microsoft.Extensions.Configuration;

namespace Westeros.Demo.ApiClient
{
    public class RecipesApiClient : IRecipesApiClient
    {
        HttpClient _httpClient;

        public RecipesApiClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }



        public async void AddNewPerson(IngridientsDto personToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/People", personToAdd);
        }
        public async void UpdatePerson(IngridientsDto personToUpdate)
        {
            await _httpClient.PutAsJsonAsync("api/People", personToUpdate);
        }
        public IEnumerable<IngridientsDto> All()
        {
            return _httpClient
                .GetAsync("api/People")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<IngridientsDto>>()
                .Result;
        }
        public IngridientsDto GetById(int id)
        {
            return _httpClient
                       .GetAsync($"api/People/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<IngridientsDto>()
                       .Result;
        }

        public async void DeletePerson(int id)
        {
            await _httpClient.DeleteAsync($"api/People/{id}");
        }

    }
}
