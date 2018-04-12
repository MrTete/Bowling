using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QL.Exo1.Tests
{
    [TestClass]
    public class StringClassTests
    {
        [TestMethod]
        public void GetStringTest()
        {
            StringClass chaine = new StringClass();
            Assert.AreEqual("This is a string", chaine.GetString());
        }
    }
}
