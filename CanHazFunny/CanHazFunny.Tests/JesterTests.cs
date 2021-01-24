using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_PassNullIJokeOutput_ThrowsArgumentNullException()
        {
            _ = new Jester(new JokeService(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_PassNullIJokeService_ThrowsArgumentNullException()
        {
            _ = new Jester(null, new JokeOutput());
        }
    }
}
