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
            Task_3();
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
    }
}