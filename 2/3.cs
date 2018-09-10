using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {
        
        static void Main(string[] args) {
            string[] buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(buf[0]);
            int m = int.Parse(buf[1]);
            long maxWeight = 0;
            buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vertex[] vertexes = new Vertex[n];

            for(int i = 0; i < n; ++i) {
                long weight = long.Parse(buf[i]);
                maxWeight = Math.Max(maxWeight, weight);
                vertexes[i] = new Vertex(weight, null, 0);
            }

            for(int i = 0; i < m; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long a = long.Parse(buf[0]) - 1;
                long b = long.Parse(buf[1]) - 1;
                Union(vertexes[a], vertexes[b]);
                Vertex root = Find(vertexes[a]);
                maxWeight = Math.Max(maxWeight, root.weight);
                Console.WriteLine(maxWeight);
            }
            Console.ReadKey();

        }

        static Vertex Find(Vertex v) {
            if (v.parent == null)
                return v;
            v.parent = Find(v.parent);
            return v.parent;
        }

        static void Union(Vertex a, Vertex b) {
            Vertex idA = Find(a);
            Vertex idB = Find(b);

            if (idA == idB)
                return;
            if (idA.rank >= idB.rank) {
                idB.parent = idA;
                idA.weight += idB.weight;
            } else {
                idA.parent = idB;
                idB.weight += idA.weight;
            }
            if (idA.rank == idB.rank)
                ++idA.rank;
        }
    }

    public class Vertex {
        public long weight;
        public Vertex parent;
        public long rank;

        public Vertex(long weight, Vertex parent, long rank) {
            this.weight = weight;
            this.parent = parent;
            this.rank = rank;
        }
    }
}
