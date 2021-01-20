using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null!, "");

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Warning(null!, "");

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null!, "");

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug(null!, "");

            // Assert

        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            //Arrange
            var logger = new TestLogger();

            //Act
            logger.Warning("Warning Message {0}", 31);


            //Assert
            Assert.AreEqual("Warning Message 31", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            //Arrange
            var logger = new TestLogger();

            //Act
            logger.Information("Information Message {0}", 1);


            //Assert
            Assert.AreEqual("Information Message 1", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            //Arrange
            var logger = new TestLogger();

            //Act
            logger.Debug("Debug Message {0}", 15);

            //Assert
            Assert.AreEqual("Debug Message 15", logger.LoggedMessages[0].Message);
        }

    }

    public class TestLogger : BaseLogger
    {
        public override string ClassName { get; set; } = "TestLogger";

        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}