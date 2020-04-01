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
            int finish = int.Parse(Console.ReadLine());
            int canGoDistance = int.Parse(Console.ReadLine());
            Console.ReadLine();
            string[] _stops = Console.ReadLine().Split(' ');
            int[] stops = new int[_stops.Length + 2];
            stops[0] = 0;
            stops[stops.Length - 1] = finish;
            for (int i = 1; i <= _stops.Length; i++)
            {
                stops[i] = int.Parse(_stops[i-1]);
            }
            Console.WriteLine(MinRefills(stops, canGoDistance));

            Console.ReadKey();
        }

        static int MinRefills(int[] stops, int canGoDistance)
        {
            int refills = 0; int currentStop = 0;
            while (currentStop < stops.Length - 1)
            {
                int tempStop = currentStop;
                while ((stops[currentStop] + canGoDistance) >= stops[tempStop + 1])
                {
                    tempStop++;
                    if (tempStop == stops.Length - 1) return refills;
                }
                refills++;
                if (currentStop == tempStop) return -1;
                currentStop = tempStop;
            }
            return refills;
        }
    }
}
