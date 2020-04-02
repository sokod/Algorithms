using System;
using Greedy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreedyTest
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            int min = 96;
            int max = 907;
            Assert.IsTrue(Program.IsGreaterOrEqual(min, max));
        }

        [TestMethod]
        public void TestMethod2()
        {
            int min = 907;
            int max = 96;
            Assert.IsFalse(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod3()
        {
            int min = 20;
            int max = 202;
            Assert.IsFalse(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod4()
        {
            int min = 202;
            int max = 20;
            Assert.IsTrue(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod5()
        {
            int min = 20;
            int max = 202;
            Assert.IsFalse(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod6()
        {
            int min = 858;
            int max = 85;
            Assert.IsTrue(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod7()
        {
            int min = 195;
            int max = 19;
            Assert.IsTrue(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod8()
        {
            int min = 19;
            int max = 195;
            Assert.IsFalse(Program.IsGreaterOrEqual(min, max));
        }
        [TestMethod]
        public void TestMethod9()
        {
            int min = 10;
            int max = 100;
            Assert.IsTrue(Program.IsGreaterOrEqual(min, max));
        }
    }
}
