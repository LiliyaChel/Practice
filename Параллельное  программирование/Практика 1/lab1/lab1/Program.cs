using System;
using System.Threading;
using System.Diagnostics;

namespace lab1
{
    class Program
    {
        static int N = 100000;
        static int M = 2;
        static int K = 10;
        static int[] a = new int[N];
        static double[] b = new double[N];
        static Thread[] threads = new Thread[M];

        static void Main(string[] args)
        {
            DateTime dt;
            TimeSpan ts;

            RndArr();
            double sum = 0;

            /*//Последовательное выполнение
            M = 1;
            Run1(0);
            for (int i = 0; i < 25; i++)
            {
                dt = DateTime.Now;
                Run1(0);
                ts = DateTime.Now - dt;
                sum += (double)ts.TotalMilliseconds;
            }
            Console.WriteLine("Среднее время на 25 замеров: {0} мс", sum / 50);
            sum = 0;*/

            //Лишний замер
            for (int i = 0; i < M; i++)
                threads[i] = new Thread(Run2);
            for (int i = 0; i < M; i++)
                threads[i].Start(i);
            for (int i = 0; i < M; i++)
                threads[i].Join();

            //Замеры
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < M; j++)
                    threads[j] = new Thread(Run2);

                dt = DateTime.Now;
                for (int j = 0; j < M; j++)
                    threads[j].Start(j);
                for (int j = 0; j < M; j++)
                    threads[j].Join();
                ts = DateTime.Now - dt;
                sum += (double)ts.TotalMilliseconds;
            }
            Console.WriteLine("Среднее время на 20 замеров: {0} мс", sum / 50);

            Console.ReadKey();
        }
        //Многопоточный
        public static void Run1(object number)
        {
            int num = (int)number;
            int fin = (num + 1) * N / M > a.Length ? a.Length : (num + 1) * N / M;
            for (int i = num * N / M; i < fin; i++)
                b[i] = (int)Math.Pow(a[i], 1.789);
        }
        //Усложнение обработки
        public static void Run2(object number)
        {
            int num = (int)number;
            int fin = (num + 1) * N / M > a.Length ? a.Length : (num + 1) * N / M;
            for (int i = num * N / M; i < fin; i++)
            {
                for (int j = 0; j < K; j++)
                    b[i] += (int)Math.Pow(a[i], 1.789);
            }
        }
        //Неравномерный
        public static void Run3(object number)
        {
            int num = (int)number;
            int fin = (num + 1) * N / M > a.Length ? a.Length : (num + 1) * N / M;
            for (int i = num * N / M; i < fin; i++)
            {
                for (int j = 0; j < i; j++)
                    b[i] += (int)Math.Pow(a[i], 1.789);
            }
        }
        //Круговой
        public static void Run4(object number)
        {
            int num = (int)number;
            for (int i = num; i < a.Length; i+=M)
            {
                for (int j = 0; j < i; j++)
                    b[i] += (int)Math.Pow(a[i], 1.789);
            }
        }
        static void RndArr()
        {
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(200, 500);
            }
        }

    }


}
