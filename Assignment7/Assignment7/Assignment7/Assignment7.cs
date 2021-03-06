using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7
{
    class Assignment7
    {
        public static async Task<int> DownloadTextAsync(params string[] urls)
        {
            WebClient webClient = new();

            return await Task.Run(async () =>
            {
                int total = 0;

                foreach (string url in urls)
                    total += await Task.Run(() => webClient.DownloadString(url).Length);

                return total;
            });
        }

        public static async Task<int> DownloadTextRepeatedlyAsync(int repetitions, CancellationToken cancellationToken, IProgress<double> progress, params string[] urls)
        {
            if (repetitions < 0) 
                throw new AggregateException(nameof(repetitions));
            
            if (progress is null) 
                throw new AggregateException(nameof(progress));

            int total = 0;
            int count = 1;

            for (int i = 0; i < repetitions && !cancellationToken.IsCancellationRequested; i++)
            {
                total += await DownloadTextAsync(urls);

                if (progress != null)
                    progress.Report((double)count++ / repetitions);
            }
            return total;
        }

        public static void CancelTask(double progress, double duration, CancellationTokenSource source)
        {
            if (progress < duration)
                source.Cancel();
        }
    }
}
