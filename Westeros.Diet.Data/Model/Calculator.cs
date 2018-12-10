using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westeros.Diet.Data.Model
{
    public enum PhysicalActivity { ExtremelyInactive, Inactive, ModeratelyActive, Active, VigorouslyActive, ExtremelyActive };

    public enum Goal { LoseWeight, KeepWeight, GetMuscles };

    public static class Calculator
    {       

        public static double BmiCalculate(UserProfile userProfile) {
           return ((userProfile.Weight) / ((userProfile.Height) * (userProfile.Height)));
        }

      public static double BmrCalculate(UserProfile userProfile) {
 
            double bmr =0;

            if (userProfile.Gender == Gender.Female) {
                bmr = ((9.99 * userProfile.Weight)  +
                        (6.25 * userProfile.Height*100) -
                         (4.92 * userProfile.Age) - 161);
                return bmr;
            }
            if (userProfile.Gender == Gender.Male)
            {
                bmr = ((9.99 * userProfile.Weight)  +
                        (6.25 * userProfile.Height * 100) -
                         (4.92 * userProfile.Age) + 5);
                return bmr;
            }
            return bmr;
        }

        public static double TotalCaloricDemand(UserProfile userProfile, PhysicalActivity physicalActivity, Goal goal)
        {
            double totalBmr = BmrCalculate(userProfile);

            switch (physicalActivity)
            {
                case PhysicalActivity.ExtremelyInactive:
                    break;

                case PhysicalActivity.Inactive:
                    totalBmr = totalBmr * 1.2;
                    break;

                case PhysicalActivity.ModeratelyActive:
                    totalBmr = totalBmr * 1.4;
                    break;

                case PhysicalActivity.Active:
                    totalBmr = totalBmr * 1.6;
                    break;

                case PhysicalActivity.VigorouslyActive:
                    totalBmr = totalBmr * 1.8;
                    break;

                case PhysicalActivity.ExtremelyActive:
                    totalBmr = totalBmr * 2.0;
                    break;
            }


            switch (goal)
            {
                case Goal.LoseWeight:
                    totalBmr = totalBmr - 300;
                    break;

                case Goal.KeepWeight:
                    break;

                case Goal.GetMuscles:
                    totalBmr = totalBmr + 300;
                    break;
            }
            return totalBmr;
        }

        public static decimal TotalConsumption(Entry entry, UserProfile userProfile, PhysicalActivity physicalActivity, Goal goal)
        {
            return 1;
        }
    }
   }

