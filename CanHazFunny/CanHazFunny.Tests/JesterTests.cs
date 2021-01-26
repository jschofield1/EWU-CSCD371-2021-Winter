using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_AssignsNullJokeService_ThrowsArgumentNullException()
        {
            //Assign

            //Act
            _ = new Jester(new JokeService(), null);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_AssignsNullJokeOutput_ThrowsArgumentNullException()
        {
            //Assign

            //Act
            _ = new Jester(null, new JokeOutput());

            //Assert
        }

        [TestMethod]
        public void Jester_AssignsJokeServiceAndJokeOutput_BothNotNull()
        {
            //Assign
            IJokeService jokeService = new JokeService();
            IJokeOutput jokeOutput = new JokeOutput();

            //Act
            _ = new Jester(jokeService, jokeOutput);

            //Assert
            Assert.IsNotNull(jokeService);
            Assert.IsNotNull(jokeOutput);
        }

        [TestMethod]
        public void Jester_TellJokeFiltersOutChuckNorris_ReturnsJokesWithoutChuckNorris()
        {
            //Assign
            Mock<IJokeService> mock = new Mock<IJokeService>();
            _ = mock.SetupSequence(JokeService => JokeService.GetJoke())
                .Returns("Chuck Norris joke")
                .Returns("Yo momma joke");

            //Act
            new Jester(mock.Object, new JokeOutput()).TellJoke();

            //Assert
            mock.Verify(jokeService => jokeService.GetJoke(), Times.Exactly(2));
        }
    }
}
