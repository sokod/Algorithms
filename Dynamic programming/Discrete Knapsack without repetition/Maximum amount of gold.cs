using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    struct Item
    {
        public int weight;
        public int value;
        public Item(int weight,int value)
        {
            this.weight = weight;
            this.value = value;
        }
        public Item(int weight)
        {
            this.weight = weight;
            this.value = weight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputs = input.Split(' ');
            int capacity = int.Parse(inputs[0]);
            int itemList = int.Parse(inputs[1]);
            input = Console.ReadLine();
            Item[] items = new Item[itemList];
            inputs = input.Split(' ');
            for (int i = 0; i < itemList; i++)
            {
                items[i] = new Item(int.Parse(inputs[i]));
            }
            Console.WriteLine(Knapsack(capacity,items));
            Console.ReadKey();
        }

        private static int Knapsack(int capacity, Item[] items)
        {
            int[,] values = new int[capacity+1,items.Length+1];

            for (int j = 1; j <= items.Length; j++)
            {
                for (int i = 1; i <= capacity; i++)
                {
                    values[i,j] = values[i,j-1];
                    if (items[j-1].weight<=i)
                    {
                        int val = values[i - items[j-1].weight,j-1] + items[j-1].value;
                        if (values[i, j] < val)
                            values[i, j] = val;
                    }
                }
            }
            return (values[capacity, items.Length]);
        }
    }
} 
