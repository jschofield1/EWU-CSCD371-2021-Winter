using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeOutputTests
    {
        [TestMethod]
        public void JokeOutput_PassStringToPrintJoke_WritesInputToConsole()
        {
            //Assign
            Mock<IJokeService> mockJokeService = new Mock<IJokeService>();
            _ = mockJokeService.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("Corny dad joke");

            Mock<IJokeOutput> mockJokeOutput = new Mock<IJokeOutput>();
            _ = mockJokeOutput.SetupSequence(jokeOutput => jokeOutput.PrintJoke("Corny dad joke"));

            //Act
            new Jester(mockJokeService.Object, mockJokeOutput.Object).TellJoke();

            //Assert
            mockJokeOutput.VerifyAll();
        }
    }
}
