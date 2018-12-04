using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Demo.Data.Services
{
    public class Calculator : ICalculator
    {
        public void execute()
        {
            Console.WriteLine("Działam");
        }
    }
}
