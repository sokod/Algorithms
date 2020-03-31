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
            ulong n = ulong.Parse(Console.ReadLine());
            int[] pisano = PisanoPeriod();
            n = (n % 60 > 0) ? n % 60 : 0;
            Console.WriteLine(pisano[n+2]-1);
            Console.ReadKey();
        }

        // module 10
        static int[] PisanoPeriod()
        {
            int[] fibonacci = new int[61];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                    fibonacci[i] = (fibonacci[i - 1] + fibonacci[i - 2])%10;
            }
            return fibonacci;
        }
    }
}