using System;

namespace Westeros.Diet.Data.Model
{
    public class Calculator
    {

        private UserProfile userProfile;

        private enum PhysicalActivity   {ExtremelyInactive, Inactive, ModeratelyActive, Active, VigorouslyActive, ExtremelyActive};

        private enum Goal  {LoseWeight, KeepWeight, GetMuscles};

        private double BmiCalculate(UserProfile userProfile) {
           return ((userProfile.Weight) / ((userProfile.Height) * (userProfile.Height)));
        }

        //podstawowe zapotrzebowanie kaloryczne

      private double BmrCalculate() {
 
            double bmr;

            if (userProfile.Gender == Female) {
                bmr = ((9.99 * userProfile.Weight)+
                            (6.25 * userProfile.Height*100)-
                            (4.92 * userProfile.Age) - 161);
                return bmr;
            }
            if (userProfile.Gender == Male)
            {
                bmr = ((9.99 * userProfile.Weight) +
                            (6.25 * userProfile.Height * 100) -
                            (4.92 * userProfile.Age) + 5);
                return bmr;
            }
        }

        private double TotalCaloricDemand(PhysicalActivity physicalActivity, Goal goal)
        {
           double totalBmr = BmrCalculate();
            
            switch (PhysicalActivity) {

                case PhysicalActivity.ExtremelyInactive:
                    return totalBmr;

                case PhysicalActivity.Inactive:
                    return totalBmr = totalBmr * 1.2;

                case PhysicalActivity.ModeratelyActive:
                    return totalBmr = totalBmr * 1.4;

                case PhysicalActivity.Active:
                    return totalBmr = totalBmr * 1.6;

                case PhysicalActivity.VigorouslyActive:
                    return totalBmr = totalBmr * 1.8;

                case PhysicalActivity.ExtremelyActive:
                    return totalBmr = totalBmr * 2.0;
            }


            switch (Goal)
            {
                case Goal.LoseWeight: return totalBmr - 300;

                case Goal.KeepWeight: return totalBmr;

                case Goal.GetMuscles: return totalBmr + 300;
                    
            }

            return totalBmr;

        }
    }
   }

