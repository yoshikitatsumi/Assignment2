using System;
using System.ComponentModel;
using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Punter J = Factory.CreatePunter("Joe", 100);


            int num = Factory.count;

            Assert.AreEqual(num, 1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Punter B = Factory.CreatePunter("Bob", 100);


            int num = Factory.count;

            Assert.AreEqual(num, 2);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Punter A = Factory.CreatePunter("Al", 100);

            int num = Factory.count;

            Assert.AreEqual(num, 3);
        }
    }
}
