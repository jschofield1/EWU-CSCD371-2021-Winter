using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        private static readonly string filePath = "Logger.Tests";

        [TestMethod]
        public void ConfigureFileLogger_SetsFilePath()
        {
            //Arrange
            var logger = new LogFactory();
            logger.ConfigureFileLogger(filePath);

            //Act

            //Assert
            Assert.AreEqual(filePath, logger.FilePath);
        }
    }
}