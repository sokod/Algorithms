using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());
            Console.WriteLine(ChangeMoney(value));
            Console.ReadKey();
        }

        private static int ChangeMoney(int value)
        {
            if (value == 1)
                return 0;
            int change = 0;
            int denomination = 10;
            for (int i = 0; i < 3; i++)
            {
                if (value / denomination > 0)
                {
                    change += value / denomination;
                    value %= denomination;
                }
                denomination -= 5;
                if (denomination <= 0) denomination = 1;
            }
            return change;
        }
    }
}
