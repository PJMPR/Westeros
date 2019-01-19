using System.Collections.Generic;
using Westeros.UserProfile.ApiClient.Contracts;

namespace Westeros.UserProfile.ApiClient
{
    public interface IUserProfileApiClient
    {
        void AddUser(UserDto userToAdd);
        IEnumerable<UserDto> All();
        void DeleteUser(int id);
        UserDto GetById(int id);
        void UpdatePerson(UserDto userToUpdate);
    }
}