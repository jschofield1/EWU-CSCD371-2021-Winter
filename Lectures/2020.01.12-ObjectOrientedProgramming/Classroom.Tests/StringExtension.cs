using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Classroom.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void TitleCase_OneWordTitle_ReturnsUpercase()
        {
            string result = StringExtension.TitleCase("Inigo");
            Assert.AreEqual("Inigo", result);
        }

        [TestMethod]
        public void TitleCase_OneWordTitleInLowerCase_ReturnsUpercase()
        {
            string result = StringExtension.TitleCase("inigo");
            Assert.AreEqual("Inigo", result);
        }

        [TestMethod]
        public void TitleCase_OneWordTitleInLowerCaseUsingExtensionMethod_ReturnsUpercase()
        {
            string result = "inigo".TitleCase(42);
            Assert.AreEqual("Inigo", result);
        }

    }
}
