using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        private static readonly string filePath = "Logger.Tests";

        [TestMethod]
        public void ConfigureFileLogger_SetsFilePath_PathMatchesLog()
        {
            //Arrange
            var logger = new LogFactory();

            //Act
            logger.ConfigureFileLogger(filePath);

            //Assert
            Assert.AreEqual(filePath, logger.FilePath);
        }
    }
}