using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoginStuff.Tests
{
    [TestClass]
    public class ApplicationTests
    {
        [ClassInitialize]
        static public void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine($"Inside ClassInitialize in directory '{ testContext.TestDir }'");
        }

        public TestContext TestContext { get; set; }

        Application _Application;
        public Application Application
        {
            get => _Application;
            set => _Application = value ??
                throw new ArgumentNullException(nameof(value));
        }

        [TestInitialize]
        public void Setup()
        {
            // Cleanup past runs
            Cleanup();
            
            // Do Not Hard Code Paths - use realtive paths.

            TestContext.WriteLine("Inside Setup");
            Application = new Application();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up big file here
            Console.WriteLine("Inside Cleanup");
        }

        [TestMethod]
        public void Create_Application_Success()
        {
            _ = new Application();
        }

        [TestMethod]
        public void ValidLogin()
        {
            // Arrange

            // Act
            bool result = Application.Login(
                userName: "Inigo.Montoya", password: "OpenSaysMe");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Login_GivenInvalidPassword_ReturnFalse()
        {
            // Arrange

            // Act
            bool result = Application.Login(
                userName: "Inigo.Montoya", password: "Bad Password");

            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Login_ValidCredentialsForPrincessButtercup_ReturnTrue()
        {
            // Arrange

            // Act
            bool result = Application.Login(
                userName: "Princess.Buttercup", password: "RealPassword");

            // Assert
            Assert.IsTrue(result);
        }

        [DataRow("Princess.Buttercup", "Real Bad Passord")]
        [DataRow("Prince.Humperdink", "Another Bad Passord")]
        [TestMethod]
        public void Login_GivenInvalidCredentials_ReturnFalse(string userName, string password)
        {
            // Arrange

            // Act
            bool result = Application.Login(
                userName, password);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
