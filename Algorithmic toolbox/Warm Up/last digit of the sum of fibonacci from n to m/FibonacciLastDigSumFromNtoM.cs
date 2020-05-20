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
            ulong n = ulong.Parse(inputs[0]);
            ulong m = ulong.Parse(inputs[1]);
            int[] f = PisanoPeriod();
            n = (n+1) % 60;
            m = (m+2) % 60;
            int to = f[m] - 1;
            int from = f[n] - 1;
            if (to == 0 && from == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (to == 0) to = 10;
                int result = (to - from > 0) ? to - from : (to - from) + 10;
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        //module 10
        static int[] PisanoPeriod()
        {
            int[] fibonacci = new int[61];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = (fibonacci[i - 1] + fibonacci[i - 2]) % 10;
            }
            return fibonacci;
        }
    }
}