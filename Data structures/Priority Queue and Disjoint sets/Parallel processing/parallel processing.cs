using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    public class worker
    {
        public int ID { get; set; }
        public long nextFreeTime { get; set; }
        public worker(int i)
        {
            ID = i;
        }
    }
    class Program
    {
        static private int numWorkers;
        static private int[] jobs;

        static private int[] assignedWorker;
        static private long[] startTime;

        static void Main(string[] args)
        {
            solve();
            Console.ReadKey();
        }

        static private void readData()
        {
            numWorkers = int.Parse(Console.ReadLine().Split(' ')[0]);
            jobs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        }

        static private void writeResponse()
        {
            for (int i = 0; i < jobs.Length; ++i)
            {
                Console.WriteLine(assignedWorker[i] + " " + startTime[i]);
            }
        }

        static private void assignJobs()
        {
            assignedWorker = new int[jobs.Length];
            startTime = new long[jobs.Length];
            worker[] workers = new worker[numWorkers];
            for (int i = 0; i < numWorkers; i++)
            {
                workers[i] = new worker(i);
            }

            for (int i = 0; i < jobs.Length; i++)
            {
                assignedWorker[i] = workers[0].ID;
                startTime[i] = workers[0].nextFreeTime;
                workers[0].nextFreeTime += jobs[i];
                SiftDown(0, workers);
            }
        }


        static public void solve()
        {
                readData();
                assignJobs();
                writeResponse();
        }

        static void SiftDown(int i, worker[] arr)
        {
            int minIndex = i;
            int l = LeftChild(i);
            if (l < arr.Length && (arr[l].nextFreeTime < arr[minIndex].nextFreeTime ||(arr[l].nextFreeTime == arr[minIndex].nextFreeTime && arr[l].ID<arr[minIndex].ID)))
                minIndex = l;

            int r = RightChild(i);
            if (r < arr.Length && (arr[r].nextFreeTime < arr[minIndex].nextFreeTime || (arr[r].nextFreeTime == arr[minIndex].nextFreeTime && arr[r].ID < arr[minIndex].ID)))
                minIndex = r;


            if (i != minIndex)
            {
                worker buffer = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = buffer;
                SiftDown(minIndex, arr);
            }
        }

        static void SiftDown(int i, long[] arr)
        {
            int minIndex = i;
            int l = LeftChild(i);
            if (l < arr.Length && arr[l] < arr[minIndex])
                minIndex = l;

            int r = RightChild(i);
            if (r < arr.Length && arr[r] < arr[minIndex])
                minIndex = r;


            if (i != minIndex)
            {
                long buffer = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = buffer;
                SiftDown(minIndex, arr);
            }
        }
        static int Parent(int i)
        {
            return ((i - 1) / 2);
        }
        static int LeftChild(int i)
        {
            return ((2 * i) + 1);
        }
        static int RightChild(int i)
        {
            return ((2 * i) + 2);
        }
    }
}
