using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {
        static void Main(string[] args) {
            string[] buf = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(buf[1]);
            int size = int.Parse(buf[0]);

            Queue<Package> queue = new Queue<Package>();
            int currentWorkTime = 0;
            int[] result = new int[n];
            for (int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Package package = new Package(int.Parse(buf[0]), int.Parse(buf[1]), i);

                while (currentWorkTime <= package.Arrival && queue.Count > 0) {
                    Package p = queue.Dequeue();
                    result[p.i] = currentWorkTime;
                    currentWorkTime += p.Duration;
                }

                if (currentWorkTime <= package.Arrival){
                    currentWorkTime = package.Arrival;
                    queue.Enqueue(package);
                    continue;
                }
                if (queue.Count + 1 < size)
                    queue.Enqueue(package);
                else
                    result[i] = -1;
            }
            while(queue.Count != 0) {
                Package p = queue.Dequeue();
                if (currentWorkTime < p.Arrival)
                    currentWorkTime = p.Arrival;
                result[p.i] = currentWorkTime;
                currentWorkTime += p.Duration;
            }
            for (int i = 0; i < n; ++i)
                Console.Write(result[i] + " ");
            Console.ReadKey();
        }
    }

    public class Package {
        public int Arrival;
        public int Duration;
        public int i; 

        public Package(int arrival, int duration, int i) {
            Arrival = arrival;
            Duration = duration;
            this.i = i;
        }
    }
}
