using System;

namespace Westeros.Diet.Data.Model
{
    public class Calculator
    {
        public enum PhysicalActivity
        {
            ExtremelyInactive,
            Sedentary,
            ModeratelyActive,
            VigorouslyActive,
            ExtremelyActive
        };

        public enum Goal
        {
            LoseWeight,
            KeepWeight,
            GetMuscles
        };

        public void Calculate(PhysicalActivity physicalActivity, Goal goal){}
    }
}
