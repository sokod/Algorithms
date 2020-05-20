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
        static Nullable<ulong> FmodM(ulong n, ulong m)
        {
            if (n <= 1)
                return 1;
            ulong first = 0, second = 1, third = first + second;
            ulong steps = m*m;
            List<ulong> sequence = new List<ulong>();
            for (ulong i = 0; i < steps; i++)
            {
                sequence.Add(first);
                third = (first + second) % m;
                first = second;
                second = third;
                if (first == 0 && second == 1)
                {
                    return sequence[(int)(n%(i + 1))];
                }
            }
            return null;
        }


        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            ulong n = ulong.Parse(inputs[0]);
            ulong m = ulong.Parse(inputs[1]);
            Console.WriteLine(FmodM(n, m));
            Console.ReadKey();
        }
    }
}