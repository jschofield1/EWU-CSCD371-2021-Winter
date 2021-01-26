using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void JokeService_RequestsJoke_ReturnsJokeAsString()
        {
            //Assign
            IJokeService jokeService = new JokeService();

            //Act
            string joke = jokeService.GetJoke();

            //Assert
            Assert.IsNotNull(joke);
        }
    }
}
