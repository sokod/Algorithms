using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxPairWise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            Console.WriteLine(EuclidGCD(a, b));
            Console.ReadKey();
        }
        static int EuclidGCD(int a, int b)
        {
            if (b == 0)
                return a;
            int remainder = a % b;
            return EuclidGCD(b, remainder);
        }
    }
}
