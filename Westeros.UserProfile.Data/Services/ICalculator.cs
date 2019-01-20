using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data.Services
{
    public interface ICalculator
    {
        decimal BMI(User user);
        decimal WHR(decimal hip, decimal waist);
        decimal BMR_Harrisa_Benedicta(User user);
        decimal BMR_Mifflin_StJeor(User user);
        decimal AMR(int bm, int m, int u, int d, int bd);
        decimal TER(User user, int bm, int m, int u, int d, int bd);
    }
}
