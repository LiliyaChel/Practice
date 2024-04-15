using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static int N = 1000000; //Количество сообщений
        static int M = 10; //Длина сообщения
        static int W = 2; //Число писателей
        static int R = 2; //Число читателей
        static string[,] WriteMessages = new string[W, N]; //Массив сообщений писателей
        static List<string>[] ReadMessages = new List<string>[R]; //Списки сообщений читателей
        static bool finish; //Маркер конца
        static bool bEmpty; //Маркер пустого буфера
        static string buffer; //Буфер


        static AutoResetEvent aFull;
        static AutoResetEvent aEmpty;

        static Semaphore sFull;
        static Semaphore sEmpty;

        static int fFull;
        static int fEmpty;

        static void Main(string[] args)
        {
            char C1 = 'L';
            char C2 = 'C';
            int V1 = C1 % 4;
            int V2 = C2 % 4;
            Console.WriteLine("Вариант: {0}, {1}", V1, V2);


            Stopwatch stopWatch = new Stopwatch();
            double tsum = 0;
            double dubsum = 0;
            double lostsum = 0;
            //int[] result;
            Thread[] WriteThreads;
            Thread[] ReadThreads;

            CreateMessages();

            for (int t = 0; t < 5; t++)
            {
                WriteThreads = new Thread[W];
                ReadThreads = new Thread[R];

                finish = false;
                
                bEmpty = true;

                //aFull = new AutoResetEvent(false);
                //aEmpty = new AutoResetEvent(true);

                //sFull = new Semaphore(0, 1);
                //sEmpty = new Semaphore(1, 1);

                //fFull = 0;
                //fEmpty = 1;

                stopWatch.Start();

                for (int i = 0; i < W; i++)
                    WriteThreads[i] = new Thread(Write1);
                for (int i = 0; i < R; i++)
                    ReadThreads[i] = new Thread(Read1);

                for (int i = 0; i < W; i++)
                    WriteThreads[i].Start(i);
                for (int i = 0; i < R; i++)
                    ReadThreads[i].Start(i);


                for (int i = 0; i < W; i++)
                    WriteThreads[i].Join();
                finish = true;

                //aFull.Set();

                //sFull.Release();

                for (int i = 0; i < R; i++)
                    ReadThreads[i].Join();

                stopWatch.Stop();

                //result = CheckMessages();

                if (t > 0) //Пропустить первый тест
                {
                   // lostsum += result[0];
                   // dubsum += result[1];
                    tsum += stopWatch.Elapsed.TotalMilliseconds;
                }

                stopWatch.Reset();

                ReadMessages = new List<string>[R];
            }
            Console.WriteLine("2 повтора: {0} писателей, {1} сообщений длиной {2} символов на каждого, {3} читателей:\nВремя выполнения {4} мс: ", W, N, M, R, tsum/4/*, lostsum/4, dubsum/4*/);
            Console.ReadKey();
        }
        public static void CreateMessages()
        {
            Random random = new Random();
            string word;
            for (int i = 0; i < W; i++)
            {
               for (int j = 0; j < N; j++)
                {
                    word = "";
                    for (int k = 0; k < M; k++) 
                        word += (char)random.Next(65, 90);
                    WriteMessages[i,j] = word;
                }
            }
        }
        public static int[] CheckMessages()
        {
            int[] check = new int[2]; //0 - пропущено, 1 - дублировано.
            bool check1 = false;
            int check2 = 0;
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < R; k++)
                    {
                        if(ReadMessages[k].Contains(WriteMessages[i, j]))
                        {
                            check1 = true;
                            check2++;
                        }                        
                    }
                    if (!check1)
                        check[0]++;
                    if (check2 > 1)
                        check[1]++;
                    check1 = false;
                    check2 = 0;
                }
            }


            return check;
        }
        //Обычный, lock, lock с двойной проверкой
        public static void Read1(object o)
        {
            int num = (int)o;
            ReadMessages[num] = new List<string>();
            while (!finish)
            {
                if (!bEmpty)
                {
                    lock ("Read")
                    {
                        if (!bEmpty)
                        {
                            ReadMessages[num].Add(buffer);
                            bEmpty = true;
                        }
                    }
                }
            }
        }
        public static void Write1(object o)
        {
            int num = (int)o;
            int i = 0;
            while (i < N)
            {
                if (bEmpty)
                {
                    lock ("Write")
                    {
                        if (bEmpty)
                        {
                            buffer = WriteMessages[num, i];
                            i++;
                            bEmpty = false;
                        }
                    }
                }
            }
        }
        //AutoResetEvent и Semaphore
        public static void Read2(object o)
        {
            int num = (int)o;
            ReadMessages[num] = new List<string>();
            while (!finish)
            {
                aFull.WaitOne();
                //sFull.WaitOne();
                if (finish)
                {
                    aFull.Set();
                    //sFull.Release();
                    break;
                }
                ReadMessages[num].Add(buffer);
                aEmpty.Set();
                //sEmpty.Release();
            }

        }
        public static void Write2(object o)
        {
            int num = (int)o;

            int i = 0;
            while (i < N)
            {
                aEmpty.WaitOne();
                //sEmpty.WaitOne();
                buffer = WriteMessages[num, i];
                i++;
                aFull.Set();
                //sFull.Release();
            }
        }
        //Interlocked.CompareExchange (что, с чем сравнить, на что заменить) возвр что
        public static void Read3(object o)
        {
            int num = (int)o;
            ReadMessages[num] = new List<string>();
            while (!finish)
            {
                if (Interlocked.CompareExchange(ref fFull, 0, 1) == 1)
                {
                    ReadMessages[num].Add(buffer);
                    fEmpty = 1;
                }
            }
        }
        public static void Write3(object o)
        {
            int num = (int)o;
            int i = 0;
            while (i < N)
            {
                if (Interlocked.CompareExchange(ref fEmpty, 0, 1) == 1)
                {
                    buffer = WriteMessages[num, i];
                    i++;
                    fFull = 1;
                }
            }
        }
    }
}
