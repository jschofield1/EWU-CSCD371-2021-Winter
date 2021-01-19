using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_CheckingFilePath()
        {
            FileLogger logger = new FileLogger("TestFile.txt");

            Assert.AreEqual("TestFile.txt", logger.FilePath);
        }

        [TestMethod]
        public void FileLogger_CheckingClassName()
        {
            FileLogger logger = new FileLogger("TestFile.txt");

            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        public void FileLogger_InputMatchesWithLog()
        {
            FileLogger logger = new FileLogger("TestFile.txt");

            logger.Log(LogLevel.Error, "Testing");
            string[]? testFileLines = File.ReadAllLines("TestFile.txt");

            Assert.AreEqual(logger.ClassName, testFileLines[1]);
        }
    }
}
