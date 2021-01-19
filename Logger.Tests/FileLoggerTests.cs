using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_ChecksFilePath_PathIsExpected()
        {
            //Arrange

            //Act
            FileLogger logger = new FileLogger("testFile.txt");
            
            //Assert
            Assert.AreEqual("testFile.txt", logger.FilePath);
        }

        [TestMethod]
        public void FileLogger_ChecksClassName_NameIsExpected()
        {
            //Arrange
            
            //Act
            FileLogger logger = new FileLogger("testFile.txt");

            //Assert
            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        public void FileLogger_ChecksInput_InputMatchesLog()
        {
            //Arrange
            FileLogger logger = new FileLogger("testFile.txt");

            //Act
            logger.Log(LogLevel.Error, "Testing");
            string[]? testFileLines = File.ReadAllLines("testFile.txt");

            //Assert
            Assert.AreEqual(logger.ClassName, testFileLines[1]);
        }
    }
}
