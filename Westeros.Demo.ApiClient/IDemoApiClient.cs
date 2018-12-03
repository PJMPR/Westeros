using System.Collections.Generic;
using Westeros.Demo.ApiClient.Contracts;

namespace Westeros.Demo.ApiClient
{
    public interface IDemoApiClient
    {
        void AddNewPerson(PersonDto personToAdd);
        IEnumerable<PersonDto> All();
        void DeletePerson(int id);
        PersonDto GetById(int id);
        void UpdatePerson(PersonDto personToUpdate);
    }
}