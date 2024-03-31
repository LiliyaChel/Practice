using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_1();
            //Task_2();
            //Task_3();
            Task_4();
            //Console.ReadKey();
        }

        static void Task_1()
        {
            int[] abcd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int result = (abcd[1] >= abcd[3]) ? abcd[0] : abcd[0] + (abcd[3] - abcd[1]) * abcd[2];
            Console.WriteLine(result);
        }

        static void Task_2()
        {
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Ceiling(Math.Log(N,2)));
        }

        static void Task_3()
        {
            int[] nt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] persones = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int left = persones[int.Parse(Console.ReadLine())-1];
            if (left == persones[nt[0] -1] || left == persones[0] || left - persones[0] <= nt[1] || persones[nt[0] - 1] - left <= nt[1])
            {
                Console.WriteLine(persones[nt[0] - 1]-persones[0]);
            }
            else
            if (left - persones[0] <= persones[nt[0] - 1] - left)
                Console.WriteLine(persones[nt[0] - 1] - 2 * persones[0] + left);
            else
                Console.WriteLine(2 * persones[nt[0] - 1] - persones[0] - left);
        }

        static void Task_4()
        {
            int[] nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long[] A = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long start_sum = A.Sum();
            int curr_point = 0;
            int[] current = new int[nk[0]];
            for (int i = 0; i < nk[0]; i++)
            {
                curr_point = curr_point > A[i].ToString().Length ? curr_point : A[i].ToString().Length;
                current[i] = 9;
            }
            int k = nk[1];
            while (curr_point > 0)
            {
                for (int i = 0; i < nk[0]; i++)
                {
                    if (A[i].ToString().Length >= curr_point)
                    {
                        current[i] = int.Parse(A[i].ToString()[A[i].ToString().Length - curr_point].ToString());
                    }
                }
                Array.Sort(current, A);
                for (int i = 0; i < nk[0]; i++)
                {
                    if (current[i] == 9) break;
                    char[] fix = A[i].ToString().ToArray();
                    fix[A[i].ToString().Length - curr_point] = '9';
                    A[i] = long.Parse(new string(fix));
                    k--;
                    if (k == 0) break;
                }
                if (k == 0) break;
                curr_point--;
            }
            long fin_sum = A.Sum();
            Console.WriteLine((fin_sum - start_sum));
        }
    }
}