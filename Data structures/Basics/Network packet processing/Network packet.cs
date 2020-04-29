using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    class Request
    {
        public Request(int arrival_time, int process_time)
        {
            this.arrival_time = arrival_time;
            this.process_time = process_time;
        }

        public int arrival_time;
        public int process_time;
    }
    class Response
    {
        public Response(bool dropped, int start_time)
        {
            this.dropped = dropped;
            this.start_time = start_time;
        }

        public bool dropped;
        public int start_time;
    }
    class Buffer
    {
        private int size_;
        private List<int> finish_time_;

        public Buffer(int size)
        {
            this.size_ = size;
            this.finish_time_ = new List<int>();
        }

        public Response Process(Request request)
        {
            if (finish_time_.Count == 0)
            {
                finish_time_.Add(request.arrival_time + request.process_time);
                return new Response(false, request.arrival_time);
            }
            else
            {
                while (finish_time_.Count > 0 && finish_time_[0] <= request.arrival_time)
                {
                    finish_time_.RemoveAt(0);
                }

                if (finish_time_.Count == size_)
                    return new Response(true, -1);
                else if (finish_time_.Count == 0)
                    finish_time_.Add(request.arrival_time + request.process_time);
                else
                    finish_time_.Add(finish_time_[finish_time_.Count - 1] + request.process_time);
            }

            return new Response(false, finish_time_[(finish_time_.Count - 1)] - request.process_time);
        }
    }
    class Program
    {
        private static List<Request> ReadQueries(int count) 
        {
            List<Request> requests = new List<Request>();
            for (int i = 0; i< count; ++i) 
            {
                int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int arrival_time = inputs[0];
                int process_time = inputs[1];
                requests.Add(new Request(arrival_time, process_time));
            }
            return requests;
        }

        private static List<Response> ProcessRequests(List<Request> requests, Buffer buffer)
        {
            List<Response> responses = new List<Response>();
            for (int i = 0; i < requests.Count(); ++i)
            {
                responses.Add(buffer.Process(requests[i]));
            }
            return responses;
        }

        private static void PrintResponses(List<Response> responses)
        {
            for (int i = 0; i < responses.Count(); ++i)
            {
                Response response = responses[i];
                if (response.dropped)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(response.start_time);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Buffer buffer = new Buffer(inputs[0]);
            List<Request> requests = ReadQueries(inputs[1]);
            List<Response> responses = ProcessRequests(requests, buffer);
            PrintResponses(responses);
            Console.ReadKey();
        }
    }
}
