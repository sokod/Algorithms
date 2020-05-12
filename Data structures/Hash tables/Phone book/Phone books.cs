using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    class Program
    {
        public static string[] phones = new string[10000000];
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string[] inputs=new string[lines];
            for (int i = 0; i < lines; i++)
            {
                inputs[i] = Console.ReadLine();
            }
            foreach(string input in inputs)
            {
                Output(input);
            }
            Console.ReadKey();
        }
        static void Output(string input)
        {
            string[] inputs = input.Split(' ');
            int value = int.Parse(inputs[1]);
            if (inputs.Length==3)
            {
                phones[value] = inputs[2];
            }
            else
            {
                if (input[0] == 'f')
                {
                    if (phones[value] != null)
                        Console.WriteLine(phones[value]);
                    else Console.WriteLine("not found");
                }
                else if (input[0]=='d')
                {
                    if (phones[value] != null)
                        phones[value] = null;
                }
            }
        }

    }
}
