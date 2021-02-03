using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMindGame.Business;
using MasterMindGame.Business.Common;

namespace MasterMindGame.UnitTest
{
    [TestClass]
    public class CodeMakerTest
    {
        [TestMethod]
        public void TestMakeCode()
        {
            var codeMaker = new AutoCodeMaker();
            var actual = codeMaker.GetHintDetail("123", "429");
            var expected = "1,0";
            Assert.IsTrue(actual.Equals(expected));
        }
    }
}
