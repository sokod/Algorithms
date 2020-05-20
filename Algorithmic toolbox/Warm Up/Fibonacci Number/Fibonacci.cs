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
            int n = int.Parse(Console.ReadLine());
            ulong[] fibonacci = new ulong[n+1];
            if (n == 0) Console.WriteLine(0);
            else if (n == 1) Console.WriteLine(1);
            else
            {
                fibonacci[0] = 0;
                fibonacci[1] = 1;
                for (int i = 2; i < fibonacci.Length; i++)
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
                Console.WriteLine(fibonacci[n]);
            }



            Console.ReadKey();
        }
    }
}
