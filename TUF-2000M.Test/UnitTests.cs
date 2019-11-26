using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUF_2000M;

namespace TUF_2000M.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestReadUrl()
        {
            Reader r = new Reader();
            bool result = false;
            result = r.ReadURL("http://tuftuf.gambitlabs.fi/feed.txt");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.AggregateException),
            "The URL did not work")]
        public void TestReadBadUrl()
        {
            Reader r = new Reader();
            bool result = false;
            result = r.ReadURL("http://tuftuf.gambitlabs.fi/feed2.txt");
        }

        [TestMethod]
        public void TestReadUrlAndFirstLine()
        {
            Reader r = new Reader();
            bool result = false;
            result = r.ReadURL("http://tuftuf.gambitlabs.fi/feed.txt");

            string str = r.GetLine(1);

            Assert.AreEqual("2018-08-03 04:06", str);
        }

        [DataTestMethod]
        [DataRow(1, "2018-08-03 04:06")]
        [DataRow(22, "21:64432")]
        [DataRow(64, "63:0")]
        [DataRow(101, "100:17503")]
        public void TestReadNthLine(int lineNr, string expected)
        {
            string[] mock = System.IO.File.ReadAllLines(@"feed.txt");

            Reader r = new Reader(mock);
            string str = r.GetLine(lineNr);

            Assert.AreEqual(expected, str);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.IOException),
            "The line number was beyond EOF")]
        public void TestReadLineAfterEOF()
        {
            string[] mock = System.IO.File.ReadAllLines(@"feed.txt");

            Reader r = new Reader(mock);
            string str = r.GetLine(105);
        }

        [TestMethod]
        public void Test2DecToReal4()
        {
            Reader r = new Reader();
            ushort register1 = 63647;   // register 1
            ushort register2 = 15846;   // register 2
            var value = r.ConvertFromUShortToReal4(register1, register2);

            Assert.AreEqual(typeof(float), value.GetType());
            Assert.AreEqual(1.12778894603252410888671875E-1, value);
        }

        [TestMethod]
        public void Test2DecToLong()
        {
            Reader r = new Reader();
            ushort register1 = 23;  // register 9
            ushort register2 = 0;   // register 10
            var value = r.ConvertFromUShortToInt32(register1, register2);

            Assert.AreEqual(typeof(System.Int32), value.GetType());
            Assert.AreEqual(23, value);
        }

        [TestMethod]
        public void TestDecToBCD()
        {
            // register 53-55 (Calendar)
           
            Reader r = new Reader();
            ushort register1 = 9267; 
            ushort register2 = 775;
            ushort register3 = 6152;

            
            int[] calendar = r.ConvertFromUShortToBCD(register1, register2, register3);
            int[] expected = new int[6];

            expected[0] = 33;   // s
            expected[1] = 24;   // m
            expected[2] = 07;   // h
            expected[3] = 03;   // d
            expected[4] = 08;   // m
            expected[5] = 18;   // y

            Assert.AreEqual(6, calendar.GetLength(0));
            for(int i=0;i<6;i++)
                Assert.AreEqual(expected[i], calendar[i]);
        }

    }
}
