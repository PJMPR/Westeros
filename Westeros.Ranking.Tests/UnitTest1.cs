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
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez쿮", Ocena = 2 });
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez쿮", Ocena = 1 });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez쿮", Ocena = 4 });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez쿮", Ocena = 3 });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez쿮", Ocena = 5 });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez쿮", Ocena = 4 });

            List<Oceny> wynikowa=new List<Oceny>(testowa);

            wynikowa = OcenaCalculator.ocenyRosnaco(wynikowa.ToArray()).ToList();

            Assert.IsTrue(wynikowa.SequenceEqual(testowa.OrderBy(x => x.Ocena)));
        }

        [TestMethod]
        public void testMalejace()
        {
            List<Oceny> testowa = new List<Oceny>();
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez쿮", Ocena = 2 });
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez쿮", Ocena = 1 });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez쿮", Ocena = 4 });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez쿮", Ocena = 3 });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez쿮", Ocena = 5 });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez쿮", Ocena = 4 });

            List<Oceny> wynikowa = new List<Oceny>(testowa);

            wynikowa = OcenaCalculator.ocenyMalejaco(wynikowa.ToArray()).ToList();

            Assert.IsTrue(wynikowa.SequenceEqual(testowa.OrderByDescending(x => x.Ocena)));
        }

        [TestMethod]
        public void testOcenyDoPrzepisu()
        {
            List<Oceny> testowa = new List<Oceny>();
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez쿮", Ocena = 2,resourceId = 1,resourceName = "dieta"});
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez쿮", Ocena = 1, resourceId = 2, resourceName = "dieta" });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez쿮", Ocena = 4, resourceId = 1, resourceName = "przepis" });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez쿮", Ocena = 3 ,resourceId = 2, resourceName = "przepis" });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez쿮", Ocena = 5, resourceId = 1, resourceName = "dieta" });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez쿮", Ocena = 4 ,resourceId = 2, resourceName = "przepis" });

            List<Oceny> wynikowa = new List<Oceny>(testowa);

            wynikowa = OcenaCalculator.OcenyDoPrzepisu(wynikowa.ToArray(),1).ToList();

            Assert.IsFalse(wynikowa.Any(x=>x.resourceName=="dieta"));
            Assert.IsFalse(wynikowa.Any(x=>x.resourceId!=1));
        }

        [TestMethod]
        public void testOcenyDoDiety()
        {
            List<Oceny> testowa = new List<Oceny>();
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez쿮", Ocena = 2, resourceId = 1, resourceName = "dieta" });
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez쿮", Ocena = 1, resourceId = 2, resourceName = "dieta" });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez쿮", Ocena = 4, resourceId = 1, resourceName = "przepis" });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez쿮", Ocena = 3, resourceId = 2, resourceName = "przepis" });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez쿮", Ocena = 5, resourceId = 1, resourceName = "dieta" });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez쿮", Ocena = 4, resourceId = 2, resourceName = "przepis" });

            List<Oceny> wynikowa = new List<Oceny>(testowa);

            wynikowa = OcenaCalculator.OcenyDoDiety(wynikowa.ToArray(), 2).ToList();

            Assert.IsFalse(wynikowa.Any(x => x.resourceName == "przepis"));
            Assert.IsFalse(wynikowa.Any(x => x.resourceId != 2));
        }

        [TestMethod]
        public void testPoliczIloscOcen()
        {
            List<Oceny> testowa = new List<Oceny>();
            testowa.Add(new Oceny() { id = 1, Data = DateTime.Now, Nick = "asd1", Tekst = "no niez쿮", Ocena = 2 });
            testowa.Add(new Oceny() { id = 2, Data = DateTime.Now, Nick = "DassadThe12", Tekst = "no niez쿮", Ocena = 1 });
            testowa.Add(new Oceny() { id = 3, Data = DateTime.Now, Nick = "asd2", Tekst = "no niez쿮", Ocena = 4 });
            testowa.Add(new Oceny() { id = 4, Data = DateTime.Now, Nick = "asd3", Tekst = "no niez쿮", Ocena = 3 });
            testowa.Add(new Oceny() { id = 5, Data = DateTime.Now, Nick = "asd4", Tekst = "no niez쿮", Ocena = 5 });
            testowa.Add(new Oceny() { id = 6, Data = DateTime.Now, Nick = "asd5", Tekst = "no niez쿮", Ocena = 4 });

            List<int> ret = OcenaCalculator.policzIloscOcen(testowa.ToArray()).ToList();

            List<int> wynikowa=new List<int>();
            wynikowa.Add(1);
            wynikowa.Add(1);
            wynikowa.Add(1);
            wynikowa.Add(2);
            wynikowa.Add(1);

            Assert.IsTrue(ret.SequenceEqual(wynikowa));
        }
    }
}
