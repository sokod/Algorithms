using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public class Segment
    {
        public int start;
        public int finish;
        public Segment(int start,int finish)
        {
            this.start = start;
            this.finish = finish;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Segment[] segments = new Segment[n];
            string[] inputs;
            for (int i = 0; i < n; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                segments[i] = new Segment(int.Parse(inputs[0]), int.Parse(inputs[1]));
            }
            int[] optimum = optimalPoints(segments);
            Console.WriteLine(optimum.Length);
            for (int i = 0; i < optimum.Length; i++)
            {
                Console.Write(optimum[i]+" ");
            }
            Console.ReadKey();
        }
        public static int[] optimalPoints(Segment[] segments)
        {
            Array.Sort(segments, (x, y) => x.finish.CompareTo(y.finish));
            List<int> points = new List<int>();
            int currentPoint = 0;
            points.Add(segments[currentPoint].finish);
            for (int i = 1; i < segments.Length; i++)
            {
                if(segments[currentPoint].finish < segments[i].start||segments[currentPoint].finish>segments[i].finish)
                {
                    currentPoint = i;
                    points.Add(segments[currentPoint].finish);
                }

            }
            return points.ToArray();
        }
    }
}
