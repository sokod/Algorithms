using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursera
{
    class Program
    {
        public static LinkedList<string>[] table;
        public static readonly int p = 1000000007; // prime
        public static readonly int x = 263;
        public static int buckets;

        static void Main(string[] args)
        {
            buckets = int.Parse(Console.ReadLine());
            table = new LinkedList<string>[buckets];
            for (int i = 0; i < buckets; i++)
            {
                table[i] = new LinkedList<string>();
            }
            int lines = int.Parse(Console.ReadLine());
            string[] input = new string[lines];
            for (int i = 0; i < lines; i++)
            {
                input[i] = Console.ReadLine();
            }

            foreach (string s in input)
                Output(s);
            
            Console.ReadKey();
        }

        public static void Output(string input)
        {
            string[] inputs = input.Split(' ');

            switch (inputs[0][0])
            {
                case 'a':
                    Add(inputs[1]);
                    break;
                case 'd':
                    Delete(inputs[1]);
                    break;
                case 'f':
                    Find(inputs[1]);
                    break;
                case 'c':
                    Check(int.Parse(inputs[1]));
                    break;
                default:
                    throw new UnauthorizedAccessException();
            }
        }

        private static void Check(int v)
        {
            if (table[v].Count==0)
                Console.WriteLine();
            else
            {
                var current = table[v].First;
                while (current != null)
                {
                    Console.Write(current.Value+" ");
                    current = current.Next;
                }
                Console.Write("\n");
            }

        }

        private static void Find(string v)
        {
            int hash = Hash(v);
            if (table[hash].Contains(v))
                Console.WriteLine("yes");
            else Console.WriteLine("no");
        }

        private static void Delete(string v)
        {
            int hash = Hash(v);
            if(table[hash].Count>0)
            {
                var current = table[hash].First;
                while(current !=null)
                {
                    if (current.Value == v)
                    {
                        table[hash].Remove(current);
                        return;
                    }
                    current = current.Next;
                }
            }
        }

        private static void Add(string v)
        {
            int hash = Hash(v);
            if (table[hash].Contains(v))
                return;

            table[hash].AddFirst(v);
        }

        public static int Hash(string input)
        {
            long hash = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
            for (int i = input.Length - 1; i >= 0; --i)
            {
                hash = (hash * x + input[i]) % p;
            }
            return (int)((hash % buckets));

        }

    }
}
