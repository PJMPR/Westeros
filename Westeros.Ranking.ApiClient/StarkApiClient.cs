using System;
using System.Collections.Generic;
using System.Net.Http;
using Westeros.Ranking.ApiClient.Contracts;
using Westeros.Ranking.Data.Model;

namespace Westeros.Ranking.ApiClient
{
    public class StarkApiClient : IStarkApiClient
    {
        private readonly HttpClient _httpClient;

        public StarkApiClient(string baseAddress)
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(baseAddress)};
        }

        public async void AddNewOcena(OcenaDto Ocena)
        {
            await _httpClient.PostAsJsonAsync("api/OcenyApi", Ocena);
        }

        public IEnumerable<OcenaDto> AllOceny()
        {
            return _httpClient
                .GetAsync("api/OcenyApi")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<OcenaDto>>()
                .Result;
        }

        public async void DeleteOcena(int id)
        {
            await _httpClient.DeleteAsync($"api/OcenyApi/{id}");
        }

        public OcenaDto GetOcena(int id)
        {
            return _httpClient.GetAsync($"api/OcenyApi/{id}").Result.Content.ReadAsAsync<OcenaDto>().Result;
        }

        public async void UpdateOcena(OcenaDto Ocena)
        {
            await _httpClient.PutAsJsonAsync("api/OcenyApi", Ocena);
        }

        public async void AddNewPrzepis(PrzepisDto Przepis)
        {
            await _httpClient.PostAsJsonAsync("api/PrzepisyApi", Przepis);
        }

        public IEnumerable<PrzepisDto> AllPrzepisy()
        {
            return _httpClient
                .GetAsync("api/PrzepisyApi")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<PrzepisDto>>()
                .Result;
        }

        public async void DeletePrzepis(int id)
        {
            await _httpClient.DeleteAsync($"api/PrzepisyApi/{id}");
        }

        public PrzepisDto GetPrzepis(int id)
        {
            return _httpClient.GetAsync($"api/PrzepisyApi/{id}").Result.Content.ReadAsAsync<PrzepisDto>().Result;
        }

        public async void UpdatePrzepis(PrzepisDto Przepis)
        {
            await _httpClient.PutAsJsonAsync("api/PrzepisyApi", Przepis);
        }


        public async void AddNewDieta(DietaDto Diety)
        {
            await _httpClient.PostAsJsonAsync("api/DietyApi", Diety);
        }

        public IEnumerable<DietaDto> AllDiety()
        {
            return _httpClient
                .GetAsync("api/DietyApi")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<DietaDto>>()
                .Result;
        }

        public async void DeleteDieta(int id)
        {
            await _httpClient.DeleteAsync($"api/DietyApi/{id}");
        }

        public DietaDto GetDieta(int id)
        {
            return _httpClient.GetAsync($"api/DietyApi/{id}").Result.Content.ReadAsAsync<DietaDto>().Result;
        }

        public async void UpdateDieta(DietaDto Diety)
        {
            await _httpClient.PutAsJsonAsync("api/DietyApi", Diety);
        }

        public async void IterateDieta(int id)
        {
            Iterator i=new Iterator();
            i.id = id;
            i.resourcename = Iterator.DIETA_RESOURCE_NAME;
            await _httpClient.PutAsJsonAsync("/api/Iterator", i);
        }

        public async void IteratePrzepis(int id)
        {
            Iterator i = new Iterator();
            i.id = id;
            i.resourcename = Iterator.PRZEPIS_RESOURCE_NAME;
            await _httpClient.PutAsJsonAsync("/api/Iterator", i);
        }
    }
}