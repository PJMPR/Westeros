using System.Collections.Generic;
using Westeros.Ranking.ApiClient.Contracts;

namespace Westeros.Ranking.ApiClient
{
    interface IStarkApiClient
    {
        void AddNewKomentarz(OcenaDto komentarz);
        IEnumerable<OcenaDto> AllKomentarze();
        void DeleteKomentarz(int id);
        OcenaDto GetKomentarz(int id);
        void UpdateKomentarz(OcenaDto komentarz);


        void AddNewPrzepis(PrzepisDto przepis);
        IEnumerable<PrzepisDto> AllPrzepisy();
        void DeletePrzepis(int id);
        PrzepisDto GetPrzepis(int id);
        void UpdatePrzepis(PrzepisDto przepis);

        void AddNewDieta(DietaDto dieta);
        IEnumerable<DietaDto> AllDiety();
        void DeleteDieta(int id);
        DietaDto GetDieta(int id);
        void UpdateDieta(DietaDto dieta);
    }
}