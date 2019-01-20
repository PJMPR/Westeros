using System.Collections.Generic;
using Westeros.Diet.ApiClient.Contracts;

namespace Westeros.Diet.ApiClient
{
    public interface IDietApiClient
    {
        void AddNewUserProfile(UserProfileDto userProfileToAdd);
        IEnumerable<UserProfileDto> AllUserProfiles();
        void DeleteUserProfile(int id);
        UserProfileDto GetUserProfile(int id);
        void UpdateUserProfile(UserProfileDto userProfileToUpdate);

        void AddNewDietPlan(DietPlanDto dietPlanToAdd);
        IEnumerable<DietPlanDto> AllDietPlans();
        void DeleteDietPlan(int id);
        DietPlanDto GetDietPlan(int id);
        void UpdateDietPlan(DietPlanDto dietPlanToUpdate);

        void AddNewEntry(EntryDto entryToAdd);
        IEnumerable<EntryDto> AllEntries();
        void DeleteEntry(int id);
        EntryDto GetEntry(int id);
        void UpdateEntry(EntryDto entryToUpdate);

    }
}
