using Microsoft.VisualStudio.TestTools.UnitTesting;
using Westeros.UserProfile.Data.Services;

namespace Westeros.UserProfile.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculator c = new Calculator();
            Assert.AreEqual(4, c.execute(2));
        }
    }
}
