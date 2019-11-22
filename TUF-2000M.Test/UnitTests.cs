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
        public void TestReadUrlAndNthLine(int lineNr, string expected)
        {
            Reader r = new Reader();
            bool result = false;
            result = r.ReadURL("http://tuftuf.gambitlabs.fi/feed.txt");

            string str = r.GetLine(lineNr);

            Assert.AreEqual(expected, str);
        }
    }
}
