using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerAsClass;

namespace CustomerClass.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Equals_EqualIds()
        {
            var c1 = new Customer() { FirstName = "adfg", LastName = "adfggsdf", Id = 5 };
            var c2 = new Customer() { FirstName = "hfdsg", LastName = "hsadfd", Id = 5 };
            Assert.IsTrue(c1.Equals(c2));
        }
    }
}
