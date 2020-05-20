using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] denominations = new int[] { 1, 3, 4 };
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(DPChange(n, denominations));
            Console.ReadKey();
        }
        static int DPChange(int money, int[] coins)
        {
            int[] MinNumCoins = new int[money+1];
            MinNumCoins[0] = 0;
            for (int i = 1; i < MinNumCoins.Length; i++)
            {
                MinNumCoins[i] = int.MaxValue;
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i>=coins[j])
                    {
                        if (MinNumCoins[i]> MinNumCoins[i - coins[j]] + 1)
                            MinNumCoins[i] = MinNumCoins[i - coins[j]] + 1;
                    }
                }
                
            }
            return MinNumCoins[money]; ;
        }
    }
}
