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



         public async void AddIngredient(IngredientsDto ingredient)
        {
            await _httpClient.PostAsJsonAsync("api/Ingredients", ingredient);
        }
        public async void UpdateIngredient(IngredientsDto ingredient)
        {
            await _httpClient.PutAsJsonAsync("api/Ingredients", ingredient);
        }
        public IEnumerable<IngredientsDto> AllIngredients()
        {
            return _httpClient
                .GetAsync("api/Ingredients")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<IngredientsDto>>()
                .Result;
        }
        public IngredientsDto GetIngredient(int id)
        {
            return _httpClient
                       .GetAsync($"api/Ingredients/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<IngredientsDto>()
                       .Result;
        }

        public async void DeleteIngredient(int id)
        {
            await _httpClient.DeleteAsync($"api/Ingredients/{id}");
        }

    }
}
