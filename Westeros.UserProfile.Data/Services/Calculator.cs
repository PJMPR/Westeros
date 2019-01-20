using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data.Services
{
    public class Calculator : ICalculator
    {
        public int execute(int x)
        {
            return (x ^ 2);
        }
    }
}
