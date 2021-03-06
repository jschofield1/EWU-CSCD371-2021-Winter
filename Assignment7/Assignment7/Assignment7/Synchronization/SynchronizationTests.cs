using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7.Synchronization
{
    [TestClass]
    public class SynchronizationTests
    {
        //Sometimes passes, sometimes fails
        [TestMethod]
        public void Unsynchronized_PassedValidInput_IsNotSynchronized()
        {
            string[] input = { "1000000" };

            Assert.AreNotEqual<int>(0, Synchronization.Unsynchronized(input));
        }

        [TestMethod]
        public void LockSolution_PassedValidInput_IsSynchronized()
        {
            string[] input = { "1000000" };

            Assert.AreEqual<int>(0, Synchronization.LockSolution(input));
        }

        [TestMethod]
        public void InterlockSolution_PassedValidInput_IsSynchronized()
        {
            string[] input = { "1000000" };

            Assert.AreEqual<int>(0, Synchronization.InterlockedSolution(input));
        }

        [TestMethod]
        public void ThreadLocalSolution_PassedValidInput_IsSynchronized()
        {
            string[] input = { "1000000" };

            Assert.AreEqual<int>(0, Synchronization.ThreadLocalSolution(input));
        }
    }
}