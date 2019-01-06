using System.Collections.Generic;
using Westeros.Demo.ApiClient.Contracts;

namespace Westeros.Demo.ApiClient
{
    public interface IRecipesApiClient
    {
        void AddNewPerson(IngridientsDto personToAdd);
        IEnumerable<IngridientsDto> All();
        void DeletePerson(int id);
        IngridientsDto GetById(int id);
        void UpdatePerson(IngridientsDto personToUpdate);
    }
}