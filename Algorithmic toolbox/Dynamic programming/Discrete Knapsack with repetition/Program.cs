using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    class Item
    {
        public int weight { get; private set; }
        public int value { get; private set; }
        public string name { get; private set; }
        public Item(int weight, int value,string name)
        {
            this.weight = weight;
            this.value = value;
            this.name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the maximum capacity?");
            int capacity = int.Parse(Console.ReadLine());
            Item[] items = new Item[] {new Item(6, 30,"meat"), new Item(3, 14,"cheese"), new Item(4, 16,"bread"), new Item(2, 9,"water") };
            List<Item>[] inKnapsack;
            int best = Knapsack(capacity, items,out inKnapsack);
            Console.WriteLine($"Complectation is finished. Value of {best} is best. You should take:");
            for (int i = 0; i < inKnapsack[capacity].Count; i++)
            {
                Console.Write(inKnapsack[capacity][i].name+";");
            }
            Console.ReadKey();
        }

        public static int Knapsack(int weight,Item[] items, out List<Item>[] inKnapsack)
        {
            int[] values = new int[weight+1];
            inKnapsack = new List<Item>[weight + 1];
            inKnapsack[0] = new List<Item>(0);
            for (int w = 1; w < values.Length; w++)
            {
                values[w] = 0;
                inKnapsack[w] = new List<Item>(items.Length);
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].weight<=w)
                    {
                        int value = values[w - items[i].weight] + items[i].value;
                        if (value > values[w])
                        {
                            values[w] = value;
                            inKnapsack[w].Clear();
                            inKnapsack[w].AddRange(inKnapsack[w - items[i].weight]);
                            inKnapsack[w].Add(items[i]);
                        }
                    }
                }
            }
            return values[weight];
        }

    }
} 
