using Microsoft.VisualStudio.TestTools.UnitTesting;
using Westeros.UserProfile.Data;
using Westeros.UserProfile.Data.Services;

namespace Westeros.UserProfile.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BmiTest()
        {
            User user = new User();
            Calculator c = new Calculator();
            user.weight = 100;
            user.height = 2;

            decimal expected = 25;

            Assert.AreEqual(expected, c.BMI(user));
        }
        [TestMethod]
        public void WHRTest()
        {

            Calculator whr = new Calculator();
            decimal waist = 50;
            decimal hip = 50;

            decimal expected = 1;

            Assert.AreEqual(expected, whr.WHR(hip, waist));
        }
        [TestMethod]
        public void BMR_Harrisa_BenedictaTest()
        {
            User user = new User();
            Calculator bmr = new Calculator();
            user.age = 30;

            user.gender = 0;
            user.weight = 80;
            user.height = (decimal)1.58;

            decimal expected = (decimal)1000.9;

            Assert.AreEqual(expected, bmr.BMR_Harrisa_Benedicta(user));
        }
        [TestMethod]
        public void BMR_Mifflin_StJeorTest()
        {
            User user = new User();
            Calculator bmrm = new Calculator();
            user.age = 30;

            user.gender = 0;
            user.weight = 80;
            user.height = (decimal)1.58;

            decimal expected = (decimal)666.475;

            Assert.AreEqual(expected, bmrm.BMR_Mifflin_StJeor(user));
        }
        [TestMethod]
        public void AMRTest()
        {

            Calculator a = new Calculator();
            int bm = 1;
            int m = 1;
            int u = 1;
            int d = 1;
            int bd = 1;

            decimal expected = (decimal)28.3;

            Assert.AreEqual(expected, a.AMR(bm, m, u, d, bd));
        }
        [TestMethod]
        public void TERTest()
        {
            User user = new User();
            Calculator t = new Calculator();
            user.age = 30;

            user.gender = 0;
            user.weight = 80;
            user.height = (decimal)1.58;
            int bm = 1;
            int m = 1;
            int u = 1;
            int d = 1;
            int bd = 1;

            decimal expected = (decimal)(1000.9 + 28.3);

            Assert.AreEqual(expected, t.TER(user, bm, m, u, d, bd));
        }
    }

}
