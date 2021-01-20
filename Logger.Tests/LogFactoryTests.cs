using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        private static readonly string filePath = "Logger.Tests";

        [TestMethod]
        public void ConfigureFileLogger_SetsFilePath_PathMatchesLog()
        {
            var logger = new LogFactory();

            logger.ConfigureFileLogger(filePath);

            Assert.AreEqual(filePath, logger.FilePath);
        }
    }
}
