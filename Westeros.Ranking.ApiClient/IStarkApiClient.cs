using System.Collections.Generic;
using Westeros.Ranking.ApiClient.Contracts;

namespace Westeros.Ranking.ApiClient
{
    interface IStarkApiClient
    {
        void AddNewKomentarz(KomentarzDto komentarz);
        IEnumerable<KomentarzDto> AllKomentarze();
        void DeleteKomentarz(int id);
        KomentarzDto GetKomentarz(int id);
        void UpdateKomentarz(KomentarzDto komentarz);


        void AddNewPrzepis(PrzepisDto przepis);
        IEnumerable<PrzepisDto> AllPrzepise();
        void DeletePrzepis(int id);
        PrzepisDto GetPrzepis(int id);
        void UpdatePrzepis(PrzepisDto przepis);

        void AddNewDieta(DietaDto dieta);
        IEnumerable<DietaDto> AllDietae();
        void DeleteDieta(int id);
        DietaDto GetDieta(int id);
        void UpdateDieta(DietaDto dieta);
    }
}