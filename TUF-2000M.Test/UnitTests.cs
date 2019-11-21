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

            string str = r.GetLine(0);

            Assert.AreEqual("2018-08-03 04:06", str);
        }
    }
}
