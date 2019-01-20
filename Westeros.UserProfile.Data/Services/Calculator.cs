using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data.Services
{
    public class Calculator
    {
        public decimal BMI (User user)
        {
            return (user.weight / (user.height * user.height) ?? 0);
        }

        // dane z formularza
        public decimal WHR (decimal hip, decimal waist)
        {
            return (waist/hip);
        }

        public decimal BMR_Harrisa_Benedicta(User user)
        {
            decimal w = user.weight ?? 0;
            decimal h = user.height ?? 0;

            if (user.gender == Gender.Male)
            {
                return (66 + ((decimal)13.7 * w) + (5 * h) - (decimal)(6.76 * user.age));
            }
            else
            {
                return (655 + ((decimal)9.6 * w) + ((decimal)1.8 *h) - (decimal)(6.76 * user.age));
            }
        }

        public decimal BMR_Mifflin_StJeor(User user)
        {
            decimal w = user.weight ?? 0;
            decimal h = user.height ?? 0;

            if (user.gender == Gender.Male)
            {
                return (((decimal)9.99 * w) + ((decimal)6.25 * h) - (decimal)(4.92 * user.age) + 5);
            }
            else
            {
                return (((decimal)9.99 * w) + ((decimal)6.25 * h) - (decimal)(4.92 * user.age) - 161);
            }
        }

        // dane z formularza
        public decimal AMR (int bm, int m, int u, int d, int bd)
        {
            return (bm*(decimal)1.4 + m*(decimal)2.5 + u*(decimal)4.2 + d*(decimal)8.2 + bd*12);
        }

        // Jeżeli użytkownik poda dane do BMR i AMR, to można podać indeks TER, który jest ich sumą
        public decimal TER (User user, int bm, int m, int u, int d, int bd)
        {
            return (BMR_Harrisa_Benedicta(user) + AMR(bm,m,u,d,bd));
        }
    }
}
