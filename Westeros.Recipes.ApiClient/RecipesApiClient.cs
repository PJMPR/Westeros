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



        public async void AddRecipe(RecipesDto Recipe)
        {
            await _httpClient.PostAsJsonAsync("api/Recipes", Recipe);
        }
        public async void UpdateRecipe(RecipesDto Recipe)
        {
            await _httpClient.PutAsJsonAsync("api/Recipes", Recipe);
        }
        public IEnumerable<RecipesDto> AllRecipes()
        {
            return _httpClient
                .GetAsync("api/Recipes")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<RecipesDto>>()
                .Result;
        }
        public RecipesDto GetRecipe(int id)
        {
            return _httpClient
                       .GetAsync($"api/Recipes/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<RecipesDto>()
                       .Result;
        }

        public async void DeleteRecipe(int id)
        {
            await _httpClient.DeleteAsync($"api/Recipes/{id}");
        }



         public async void AddIngridient(IngridientsDto Ingridient)
        {
            await _httpClient.PostAsJsonAsync("api/Ingridients", Ingridient);
        }
        public async void UpdateIngridient(IngridientsDto Ingridient)
        {
            await _httpClient.PutAsJsonAsync("api/Ingridients", Ingridient);
        }
        public IEnumerable<IngridientsDto> AllIngridients()
        {
            return _httpClient
                .GetAsync("api/Ingridients")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<IngridientsDto>>()
                .Result;
        }
        public IngridientsDto GetIngridient(int id)
        {
            return _httpClient
                       .GetAsync($"api/Ingridients/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<IngridientsDto>()
                       .Result;
        }

        public async void DeleteIngridient(int id)
        {
            await _httpClient.DeleteAsync($"api/Ingridients/{id}");
        }

    }
}
