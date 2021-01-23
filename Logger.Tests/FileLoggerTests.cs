using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_AssignGoodFilePath_PathMatches()
        {
            //Arrange
            FileLogger? logger = new FileLogger("testFile");

            //Act
            string path = "";
            if (logger != null && !string.IsNullOrEmpty(logger.FilePath))
                path = logger.FilePath;

            //Assert
            Assert.AreEqual(path, "testFile");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileLogger_AssignNullFilePath_ReturnsArgumentNullException()
        {
            //Arrange

            //Act
            _ = new FileLogger(null!);

            //Assert
        }

        [TestMethod]
        public void FileLogger_AssignsGoodFilePath_LogMatchesInput()
        {
            if (!File.Exists("testFile.txt"))
                throw new FileNotFoundException();

            string filePath = "testFile.txt";

            //Arrange
            LogFactory? logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(filePath);
            FileLogger? fileLogger = (FileLogger?)logFactory.CreateLogger(nameof(FileLogger));
            string? dateTime = null;

            //Act
            if (fileLogger != null)
            {
                fileLogger.Log(LogLevel.Error, "Testing");
                dateTime = DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss");
            }
            string[]? lines = File.ReadAllLines("testFile.txt");

            //Assert
            Assert.AreEqual("Date/time: " + dateTime, lines[0]);
            Assert.AreEqual(nameof(FileLogger), lines[1]);
            Assert.AreEqual(nameof(LogLevel.Error), lines[2]);
            Assert.AreEqual("Testing", lines[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Log_PassedBadFile_ReturnsFileNotFoundException()
        {
            //Arrange
            FileLogger? fileLogger = new FileLogger("");

            //Act
            fileLogger.Log(LogLevel.Error, "BadFile");

            //Assert
        }
    }
}
