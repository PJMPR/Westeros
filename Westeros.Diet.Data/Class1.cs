using System;

namespace Westeros.Diet.Data
{
    public class Calculator
    {
        enum PhysicalActivity 
        {
        ExtremelyInactive, Sedentary, ModeratelyActive, VigorouslyActive, ExtremelyActive};
        enum Goal {LoseWeight, KeepWeight, GetMuscles};

        public void Calculate(PhysicalActivity physicalActivity, Goal goal){}

    }
}
