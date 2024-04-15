using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace lab2
{
    class Program
    {
        static int n = 10000000; //Элементы
        static int m = 8; //Потоки
        static int sqrtn = (int)Math.Floor(Math.Sqrt(n));
        static bool[] bitmap = new bool[n+1]; //не простые, индекс с 1
        static List<int> simple = new List<int>();
        static int startsimp;
        static Thread[] threads = new Thread[m];
        static int step;
        static int count = 0;
        static int index = 1;
        static object locksect = new object();//Крит.секц
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            double sum=0;
            for (int t = 0; t < 10; t++)
            {
                stopWatch.Start();

                for (int i = 2; i <= sqrtn; i++)
                    Check(i, sqrtn);
                AddSimp(1,sqrtn);
                simple.Sort();
                startsimp = simple.Count;

                /*========================Последовательное=========================*/

                //Run0();

                /*========================№1=========================*/

                /*
                for (int i = 0; i < m; i++)
                {
                    threads[i] = new Thread(Run1);
                }
                step = (n - sqrtn) / m;


                for (int i = 0; i < m - 1; i++)
                {
                    threads[i].Start(new int[] { i * step + sqrtn + 1, (i + 1) * step + sqrtn });
                }
                threads[m - 1].Start(new int[] { (m - 1) * step + sqrtn + 1, n });
                for (int i = 0; i < m; i++)
                {
                    threads[i].Join();
                }
               */

                /*=======================№2==========================*/

                /*
                for (int i = 0; i < m; i++)
                {
                    threads[i] = new Thread(Run2);
                }
                step = startsimp / m;


                for (int i = 0; i < m - 1; i++)
                {
                    threads[i].Start(new int[] { i * step + 1, (i + 1) * step  + 1 });
                }
                threads[m - 1].Start(new int[] { (m - 1) * step + 1, startsimp });
                for (int i = 0; i < m; i++)
                {
                    threads[i].Join();
                }
                AddSimp(sqrtn + 1, n);
                */

                /*=======================№3==========================*/

                
                for (int i = 1; i < simple.Count; i++)
                {
                    ThreadPool.QueueUserWorkItem(Run3, simple.ElementAt(i));
                }
                while (count < simple.Count - 1) { }

                AddSimp(sqrtn + 1, n);
                

                /*=======================№4==========================*/

                /*
                for (int i = 0; i < m; i++) threads[i] = new Thread(Run4);
                for (int i = 0; i < m; i++) threads[i].Start();
                for (int i = 0; i < m; i++) threads[i].Join();

                AddSimp(sqrtn + 1, n);
                */

                stopWatch.Stop();
                sum+=stopWatch.Elapsed.TotalMilliseconds;

                stopWatch.Reset();
                bitmap = new bool[n + 1];
                simple.Clear();
                startsimp = 0;
                step = 0;
                count = 0;
                index = 1;
                locksect = new object();
            }
            sum = sum / 10;
            Console.WriteLine("Среднее время на 10 замеров, {1} элементов, {2} потоков: {0} мс", sum, n, m);
            Console.ReadKey();

        }
        public static void Check(int num, int fin)
        {
            for (int i = num + 1; i <= fin; i++)
            {
                if (!bitmap[i] & (i % num) == 0)
                {
                    bitmap[i] = true;
                }
            }
        }
        public static void AddSimp(int start, int fin)
        {
            for (int i = start; i <= fin; i++)
                if (!bitmap[i]) simple.Add(i);
        }
        public static void Run0() //Последовательное
        {
            bool flag;
            for (int j = sqrtn + 1; j <= n; j++) 
            {
                flag = false;
                for (int i = 1; i < startsimp; i++)
                {
                    if (j % simple.ElementAt(i) == 0)
                    {
                        bitmap[j] = true;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    simple.Add(j); 
                }
            }
        }
        public static void Run1(object o) //декомпозиция по данным
        {
            int[] data = (int[])o;
            int start = data[0];
            int fin = data[1];

            bool flag;
            for (int j = start; j <= fin; j++)
            {
                flag = false;
                for (int i = 1; i < startsimp; i++)
                {
                    if (j % simple.ElementAt(i) == 0)
                    {
                        bitmap[j] = true;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    simple.Add(j);
                }
            }
        }
        public static void Run2(object o) //декомпозиция набора простых чисел
        {
            int[] data = (int[])o;
            int start = data[0];
            int fin = data[1];

            for (int j = sqrtn+1; j <= n; j++)
            {
                for (int i = start; i < fin; i++)
                {
                    if (j % simple.ElementAt(i) == 0)
                    {
                        bitmap[j] = true;
                        break;
                    }
                }
            }
        }
        static void Run3(object o) //применение пула потоков
        {
            int num = (int)o;

            for (int i = sqrtn + 1; i <= n; i++)
            {
                if (i % num == 0) bitmap[i] = true;
            }
            lock (locksect)
            {
                count++;
            }
        }
        static void Run4() //последовательный перебор простых чисел
        {
            while (true)
            {
                int num;
                lock (locksect)
                {
                    if (index >= simple.Count) return;
                    num = simple.ElementAt(index);
                    index++;
                }
                
                for (int i = sqrtn + 1; i <= n; i++)
                {
                    if (i % num == 0) bitmap[i] = true;
                }
            }
        }

    }

}
