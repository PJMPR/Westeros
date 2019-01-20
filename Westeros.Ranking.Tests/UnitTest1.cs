using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Web.Calculator;

namespace Westeros.Ranking.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testRosnace()
        {
            List<Oceny> testowa=new List<Oceny>();
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez�e", Ocena = 2 });
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez�e", Ocena = 1 });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez�e", Ocena = 4 });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez�e", Ocena = 3 });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez�e", Ocena = 5 });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez�e", Ocena = 4 });

            List<Oceny> wynikowa=new List<Oceny>(testowa);

            wynikowa = OcenaCalculator.ocenyRosnaco(wynikowa.ToArray()).ToList();

            Assert.IsTrue(wynikowa.SequenceEqual(testowa.OrderBy(x => x.Ocena)));
        }

        [TestMethod]
        public void testMalejace()
        {
            List<Oceny> testowa = new List<Oceny>();
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez�e", Ocena = 2 });
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez�e", Ocena = 1 });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez�e", Ocena = 4 });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez�e", Ocena = 3 });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez�e", Ocena = 5 });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez�e", Ocena = 4 });

            List<Oceny> wynikowa = new List<Oceny>(testowa);

            wynikowa = OcenaCalculator.ocenyMalejaco(wynikowa.ToArray()).ToList();

            Assert.IsTrue(wynikowa.SequenceEqual(testowa.OrderByDescending(x => x.Ocena)));
        }

        [TestMethod]
        public void testOcenyDoPrzepisu()
        {

        }
    }
}
