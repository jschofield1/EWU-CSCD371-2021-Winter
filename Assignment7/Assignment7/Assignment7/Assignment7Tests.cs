using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class Assignment7Tests
    {
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextAsync_PassedNullUrl_ThrowsAggregateException()
        {
            Console.WriteLine(Assignment7.DownloadTextAsync(null!).Result);
        }

        [TestMethod]
        public void DownloadTextAsync_PassedValidParams_ReturnsExpectedResult()
        {
            Assert.IsTrue(Assignment7.DownloadTextAsync("https://google.com").Result > 9000);
        }

        [TestMethod]
        public void DownloadTextAsync_PassedNoParams_LengthIs0()
        {
            Assert.AreEqual<int>(0, Assignment7.DownloadTextAsync().Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_PassedNullProgress_ThrowsAggregateException()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            CancellationToken token = source.Token;

            int repetitions = 42;

            Assert.AreEqual(0, Assignment7.DownloadTextRepeatedlyAsync(repetitions, token, null!, "https://google.com", "https://google.com").Result);
        }

        public void DownloadTextRepeatedlyAsync_PassedValidParams_ReturnsExpectedResult()
        {
            CancellationTokenSource source = new();
            
            CancellationToken token = source.Token;
            
            int repetitions = 42;
            int result = 0;

            result = Assignment7.DownloadTextRepeatedlyAsync(repetitions, token, new Progress<double>(duration => Console.WriteLine(duration)), "https://google.com").Result;
            
            Assert.IsTrue(result > 9000);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_PassedNegativeRepetitions_ThrowsAggregateException()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            
            CancellationToken token = source.Token;
            
            int repetitions = -42;
            
            Assert.AreEqual(0, Assignment7.DownloadTextRepeatedlyAsync(repetitions, token, new Progress<double>(x => Console.WriteLine(x)), "https://google.com", "https://google.com").Result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_CancelTaskCalled_TaskIsCancelled()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            
            CancellationToken token = source.Token;
            
            int repetitions = 42;
            
            int result = Assignment7.DownloadTextRepeatedlyAsync(repetitions, token, new Progress<double>(duration => Assignment7.CancelTask(.1, duration, source)), "https://google.com", "https://google.com").Result;
            
            Assert.IsTrue(result > 42 && result < 10000000);
        }
    }
}
