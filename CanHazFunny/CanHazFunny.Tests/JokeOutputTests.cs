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
            Mock<IJokeService> mockJoke = new Mock<IJokeService>();
            _ = mockJoke.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("Corny dad joke");

            Mock<IJokeOutput> mockOutput = new Mock<IJokeOutput>();
            _ = mockOutput.SetupSequence(jokeOutput => jokeOutput.PrintJoke("Corny dad joke"));

            //Act
            new Jester(mockJoke.Object, mockOutput.Object).TellJoke();

            //Assert
            mockOutput.VerifyAll();
        }
    }
}
