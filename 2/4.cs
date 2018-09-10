using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {

        static int[] parent;
        static int[] rank;
        
        static void Main(string[] args) {
            string[] buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(buf[0]);
            int e = int.Parse(buf[1]);
            int d = int.Parse(buf[2]);

            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; ++i)
                parent[i] = i;

            for (int i = 0; i < e; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Union(int.Parse(buf[0]) - 1, int.Parse(buf[1]) - 1);
            }

            for (int i = 0; i < d; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (Find(int.Parse(buf[0]) - 1) == Find(int.Parse(buf[1]) - 1)) {
                    Console.WriteLine(0);
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine(1);
            Console.ReadKey();
        }

        static int Find(int v) {
            if (parent[v] == v)
                return v;
            parent[v] = Find(parent[v]);
            return parent[v];
        }

        static void Union(int a, int b) {
            int idA = Find(a);
            int idB = Find(b);
            if (idA == idB)
                return;

            if (rank[idA] >= rank[idB])
                parent[idB] = idA;
            else
                parent[idA] = idB;

            if (rank[idA] == rank[idB])
                ++rank[idA];
        }
    }
}
