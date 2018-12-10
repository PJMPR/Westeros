using System.Collections.Generic;
using Westeros.Ranking.ApiClient.Contracts;

namespace Westeros.Ranking.ApiClient
{
    interface IStarkApiClient
    {
        void AddNewOcena(OcenaDto Ocena);
        IEnumerable<OcenaDto> AllOceny();
        void DeleteOcena(int id);
        OcenaDto GetOcena(int id);
        void UpdateOcena(OcenaDto Ocena);


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