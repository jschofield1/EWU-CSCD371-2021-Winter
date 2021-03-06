using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7.Synchronization
{
    class Synchronization
    {
        static int _Total = int.MaxValue;
        static int _Count = 0;

        readonly static object Lock = new object();

        public static int Unsynchronized(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementUnsynchronized());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                _Count++;
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }

        static void DecrementUnsynchronized()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                _Count--;
            }
        }

        public static int LockSolution(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementLock());

            // Increment

            for (int i = 0; (i < _Total); i++)
            {
                lock (Lock)
                {
                    _Count++;
                }
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }

        static void DecrementLock()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                lock (Lock)
                {
                    _Count--;
                }
            }
        }

        public static int InterlockedSolution(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementInterlocked());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                Interlocked.Increment(ref _Count);
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }
        
        static void DecrementInterlocked()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                Interlocked.Decrement(ref _Count);
            }
        }

        public static int ThreadLocalSolution(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementThreadLocal());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                ThreadLocal<int> threadLocalAdd = new ThreadLocal<int>(() => _Count++);
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }

        static void DecrementThreadLocal()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                ThreadLocal<int> threadLocalAdd = new ThreadLocal<int>(() => _Count--);
            }
        }
    }
}
