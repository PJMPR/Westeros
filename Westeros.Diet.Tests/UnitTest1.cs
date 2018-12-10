using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Tests
{
    [TestClass]
    public class UnitTest1
    {
         
        [TestMethod]
        public void BmiCalculateTest()
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Height = 1.87;
            userProfile.Weight = 93;

            var userWeight = userProfile.Weight;
            var userHeight = userProfile.Height;

            decimal uWeight = (decimal)userWeight;
            decimal uHeight = (decimal)userHeight;
            decimal expected = 26.5949841287998m;

            var amount = Calculator.BmiCalculate(userProfile);
            decimal actual = (decimal)amount;

            Assert.AreEqual(expected, actual);            
        }

        [TestMethod]
        public void BmrCalculateTest()
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Age = 25;
            userProfile.Height = 1.87;
            userProfile.Weight = 93;
            userProfile.Gender = Gender.Male;

            var userWeight = userProfile.Weight;
            var userHeight = userProfile.Height;

            decimal uWeight = (decimal)userWeight;
            decimal uHeight = (decimal)userHeight;
            decimal expected = 1979.82m;

            var amount = Calculator.BmrCalculate(userProfile);
            decimal actual = (decimal)amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalCaloricDemandCalculateTest()
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Age = 25;
            userProfile.Height =1.87D;
            userProfile.Weight = 93D;
            userProfile.Gender = Gender.Male;

            var userWeight = userProfile.Weight;
            var userHeight = userProfile.Height;

            decimal uWeight = (decimal)userWeight;
            decimal uHeight = (decimal)userHeight;
            decimal expected = 4259.64m;

            var amount = Calculator.TotalCaloricDemand(userProfile, PhysicalActivity.ExtremelyActive, Goal.GetMuscles);
            decimal actual = (decimal)amount;

            Assert.AreEqual(expected, actual);
        }
    }
}
