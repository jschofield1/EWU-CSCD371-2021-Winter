using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_ChecksFilePath_PathMatches()
        {
            FileLogger logger = new FileLogger("testFile.txt");
            
            Assert.AreEqual("testFile.txt", logger.FilePath);
        }

        [TestMethod]
        public void FileLogger_ChecksClassName_NameMatches()
        {
            FileLogger logger = new FileLogger("testFile.txt");

            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        public void FileLogger_ChecksInput_InputMatches()
        {
            FileLogger logger = new FileLogger("testFile.txt");

            logger.Log(LogLevel.Error, "Testing");
            string[]? testFileLines = File.ReadAllLines("testFile.txt");

            Assert.AreEqual(logger.ClassName, testFileLines[1]);
        }
    }
}
