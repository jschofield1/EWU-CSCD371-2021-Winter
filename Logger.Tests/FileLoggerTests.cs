using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        /*
        [TestMethod]
        public void FileLogger_AssignsFilePathAndClassName()
        {

            //Arrange
            var logFactory = new LogFactory();

            //Act
            FileLogger logger = (FileLogger)logFactory.CreateLogger("FileLogger");
            string temp = logger.FilePath;

            //Assert
            Assert.AreEqual("testFile.txt", temp);
            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        public void FileLogger_LogMatchesInput()
        {
            string? filePath = null;
            if (File.Exists("testFile.txt"))
                filePath = "testFile.txt";
            else
                throw new FileNotFoundException();
            //Arrange
            FileLogger logger = new FileLogger(filePath);
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH:mm");

            //Act
            logger.Log(LogLevel.Error, "Message: Test");
            string[]? lines = File.ReadAllLines("testFile.txt");

            //Assert
            Assert.AreEqual("Date/time: " + dateTime, lines[0]);
            Assert.AreEqual(logger.ClassName, lines[1]);
            Assert.AreEqual(nameof(LogLevel.Error), lines[2]);
            Assert.AreEqual("Message: Test", lines[3]);
        }
        */
        [TestMethod]
        public void FileLogger_CheckingFilePath()
        {
            //Arrange

            //Act
            FileLogger logger = new FileLogger("TestFile.txt");

            //Assert
            Assert.AreEqual("TestFile.txt", logger.FilePath);
        }

        [TestMethod]
        public void FileLogger_CheckingClassName()
        {
            //Arrange

            //Act
            FileLogger logger = new FileLogger("testFile.txt");

            //Assert
            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        public void FileLogger_InputMatchesWithLog()
        {

            FileLogger logger = new FileLogger("testFile.txt");

            logger.Log(LogLevel.Error, "The message is that this is a test");
            string[]? testFileLines = File.ReadAllLines("testFile.txt");

            Assert.AreEqual(logger.ClassName, testFileLines[1]);

        }
    }
}
