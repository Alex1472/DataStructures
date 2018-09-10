using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {
        
        static void Main(string[] args) {
            SortedSet<Tuple<long, long>> priorityQueue = new SortedSet<Tuple<long, long>>();
            string[] buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long proc = long.Parse(buf[0]);
            long problems = long.Parse(buf[1]);
            long[] durations = new long[problems];
            buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (long i = 0; i < problems; ++i)
                durations[i] = long.Parse(buf[i]);
            for (long i = 0; i < proc; ++i)
                priorityQueue.Add(new Tuple<long, long>(0, i));

            for(long i = 0; i < problems; ++i) {
                Tuple<long, long> min = priorityQueue.Min;
                priorityQueue.Remove(min);
                priorityQueue.Add(new Tuple<long, long>(min.Item1 + durations[i], min.Item2));
                Console.WriteLine(min.Item2 + " " + min.Item1);
            }
            Console.ReadKey();
        }
    }
}
