using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public struct Item
    {
        public long value { get; set; }
        public long weight { get; set; }

        public double fr_value { get; set; }

        public Item(long value, long weight)
        {
            this.value = value;
            this.weight = weight;
            this.fr_value = value / (double)weight;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int allItems = int.Parse(inputs[0]);
            int capacity = int.Parse(inputs[1]);
            Item[] items = new Item[allItems];
            for (int i = 0; i < allItems; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                long value = long.Parse(inputs[0]);
                long weight = long.Parse(inputs[1]);
                items[i] = new Item(value, weight);
            }

            Console.WriteLine(Equip(items,capacity).ToString("f4"));
            Console.ReadKey();
        }

        private static double Equip(Item[] items, long capacity)
        {
            Array.Sort(items, (x, y) => x.fr_value.CompareTo(y.fr_value));
            double value = 0.0;
            for (int i = items.Length-1; i >=0; i--)
            {
                if (capacity-items[i].weight <=0)
                {
                    value += items[i].fr_value * capacity;
                    return value;
                }
                else
                {
                    value += items[i].fr_value * items[i].weight;
                    capacity -= items[i].weight;
                }
            }
            return value;
        }
    }
}
