using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoginStuff.Tests
{
    [TestClass]
    public class ApplicationTests
    {

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
            Console.WriteLine("Inside Setup");
            Application = new Application();
        }

        [TestMethod]
        public void CreateApplication()
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
        public void InvalidPassword()
        {
            // Arrange

            // Act
            bool result = Application.Login(
                userName: "Inigo.Montoya", password: "Bad Password");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidCredentials()
        {
            // Arrange

            // Act
            bool result = Application.Login(
                userName: "Princess.Buttercup", password: "Westley");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
