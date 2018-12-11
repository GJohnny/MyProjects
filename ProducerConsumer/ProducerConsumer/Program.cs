using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static Random rd = new Random();
        static Mutex mutexObj = new Mutex();

        static int[] arr = new int[30];
        static int length = arr.Length;
        static int index = -1;


        static void ShowArr()
        {
            foreach (var x in arr)
            {
                Console.Write($"{x}, ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Organizer(Producer);
                });
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Organizer(Consumer);
                });

                Thread.Sleep(100);
            }
        }
        static void Producer()
        {
            int n = rd.Next(1, 11);

            for (int i = 0; i < n; i++)
            {
                if (index == length - 1)
                    break;

                arr[++index] = rd.Next(1, 10);
            }

            Console.WriteLine($"Producer Thread id is {Thread.CurrentThread.ManagedThreadId} : n = {n}");
            ShowArr();
            Console.WriteLine();
        }

        static void Consumer()
        {
            int n = rd.Next(1, 11);

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                if (index == -1)
                    break;

                Console.Write($"{arr[index]}, ");
                arr[index--] = 0;
            }

            Console.WriteLine($"\nConsumer Thread id is {Thread.CurrentThread.ManagedThreadId} : n = {n}");
            ShowArr();
            Console.WriteLine();
        }

        static void Organizer(Action act)
        {
            mutexObj.WaitOne();
            act();
            mutexObj.ReleaseMutex();
        }
    }
}
