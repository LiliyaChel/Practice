using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] abcd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int result = (abcd[1] >= abcd[3]) ? abcd[0] : abcd[0] + (abcd[3] - abcd[1]) * abcd[2];
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}