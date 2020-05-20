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
            Segment[] segments = new Segment[3];
            segments[0] = new Segment(1, 4);
            segments[1] = new Segment(2, 3);
            segments[2] = new Segment(3, 5);
            int[] expected = new int[] { 3 };
            int[] actual = Program.optimalPoints(segments);
            for (int i = 0; i < actual.Length; i++)
            {
                TestContext.WriteLine(actual[i].ToString() + " ");
            }
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestMethod2()
        {
            Segment[] segments = new Segment[3];
            segments[0] = new Segment(1, 3);
            segments[1] = new Segment(2, 5);
            segments[2] = new Segment(3, 6);
            int[] expected = new int[] { 3 };
            int[] actual = Program.optimalPoints(segments);
            for (int i = 0; i < actual.Length; i++)
            {
                TestContext.WriteLine(actual[i].ToString() + " ");
            }
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestMethod3()
        {
            Segment[] segments = new Segment[4];
            segments[0] = new Segment(4, 7);
            segments[1] = new Segment(1, 3);
            segments[2] = new Segment(2, 5);
            segments[3] = new Segment(5, 6);
            int[] expected = new int[] { 3, 6};
            int[] actual = Program.optimalPoints(segments);
            for (int i = 0; i < actual.Length; i++)
            {
                TestContext.WriteLine(actual[i].ToString() + " ");
            }
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestMethod4()
        {
            Segment[] segments = new Segment[4];
            segments[0] = new Segment(1, 4);
            segments[1] = new Segment(3, 6);
            segments[2] = new Segment(2, 5);
            segments[3] = new Segment(6, 8);
            int[] expected = new int[] { 4, 8 };
            int[] actual = Program.optimalPoints(segments);
            for (int i = 0; i < actual.Length; i++)
            {
                TestContext.WriteLine(actual[i].ToString() + " ");
            }
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestMethod5()
        {
            Segment[] segments = new Segment[5];
            segments[0] = new Segment(1, 7);
            segments[1] = new Segment(3, 5);
            segments[2] = new Segment(1, 4);
            segments[3] = new Segment(3, 6);
            segments[4] = new Segment(5, 8);
            int[] expected = new int[] { 4, 8 };
            int[] actual = Program.optimalPoints(segments);
            for (int i = 0; i < actual.Length; i++)
            {
                TestContext.WriteLine(actual[i].ToString() + " ");
            }
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
