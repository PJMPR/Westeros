using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Westeros.Diet.ApiClient.Contracts;
using Microsoft.Extensions.Configuration;

namespace Westeros.Diet.ApiClient
{
    public class DietApiClient : IDietApiClient
    {
        HttpClient _httpClient;

        public DietApiClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }



        public async void AddNewUserProfile(UserProfileDto userProfileToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/UserProfiles", userProfileToAdd);
        }
        public async void UpdateUserProfile(UserProfileDto userProfileToUpdate)
        {
            await _httpClient.PutAsJsonAsync("api/UserProfiles", userProfileToUpdate);
        }
        public IEnumerable<UserProfileDto> AllUserProfiles()
        {
            return _httpClient
                .GetAsync("api/UserProfiles")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<UserProfileDto>>()
                .Result;
        }
        public UserProfileDto GetUserProfile(int id)
        {
            return _httpClient
                       .GetAsync($"api/UserProfiles/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<UserProfileDto>()
                       .Result;
        }

        public async void DeleteUserProfile(int id)
        {
            await _httpClient.DeleteAsync($"api/UserProfiles/{id}");
        }

        public async void AddNewDietPlan(DietPlanDto dietPlanToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/DietPlan", dietPlanToAdd);
        }
        public async void UpdateDietPlan(DietPlanDto dietPlanToUpdate)
        {
            await _httpClient.PutAsJsonAsync("api/DietPlan", dietPlanToUpdate);
        }
        public IEnumerable<DietPlanDto> AllDietPlans()
        {
            return _httpClient
                .GetAsync("api/DietPlan")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<DietPlanDto>>()
                .Result;
        }
        public DietPlanDto GetDietPlan(int id)
        {
            return _httpClient
                       .GetAsync($"api/DietPlan/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<DietPlanDto>()
                       .Result;
        }

        public async void DeleteDietPlan(int id)
        {
            await _httpClient.DeleteAsync($"api/DietPlan/{id}");
        }

        public async void AddNewEntry(EntryDto entryToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/Entries", entryToAdd);
        }
        public async void UpdateEntry(EntryDto entryToUpdate)
        {
            await _httpClient.PutAsJsonAsync("api/Entries", entryToUpdate);
        }
        public IEnumerable<EntryDto> AllEntries()
        {
            return _httpClient
                .GetAsync("api/Entries")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<EntryDto>>()
                .Result;
        }
        public EntryDto GetEntry(int id)
        {
            return _httpClient
                       .GetAsync($"api/Entries/{id}")
                       .Result
                       .Content
                       .ReadAsAsync<EntryDto>()
                       .Result;
        }

        public async void DeleteEntry(int id)
        {
            await _httpClient.DeleteAsync($"api/Entries/{id}");
        }

        
    }
}