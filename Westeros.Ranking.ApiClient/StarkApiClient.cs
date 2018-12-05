using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Westeros.Ranking.ApiClient.Contracts;

namespace Westeros.Ranking.ApiClient
{
    class StarkApiClient : IStarkApiClient
    {
        public StarkApiClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }
        public void AddNewKomentarz(KomentarzDto komentarz)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KomentarzDto> AllKomentarze()
        {
            throw new NotImplementedException();
        }

        public void DeleteKomentarz(int id)
        {
            throw new NotImplementedException();
        }

        public KomentarzDto GetKomentarz(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateKomentarz(KomentarzDto komentarz)
        {
            throw new NotImplementedException();
        }

        public void AddNewPrzepis(PrzepisDto przepis)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrzepisDto> AllPrzepise()
        {
            throw new NotImplementedException();
        }

        public void DeletePrzepis(int id)
        {
            throw new NotImplementedException();
        }

        public PrzepisDto GetPrzepis(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePrzepis(PrzepisDto przepis)
        {
            throw new NotImplementedException();
        }

        public void AddNewDieta(DietaDto dieta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DietaDto> AllDietae()
        {
            throw new NotImplementedException();
        }

        public void DeleteDieta(int id)
        {
            throw new NotImplementedException();
        }

        public DietaDto GetDieta(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDieta(DietaDto dieta)
        {
            throw new NotImplementedException();
        }
    }
}