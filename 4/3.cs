using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {

        static long[] minKey;
        static long[] maxKey;

        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            if (n == 0) {
                Console.WriteLine("CORRECT");
                return;
            }
            Node[] nodes = new Node[n];
            string[] buf;
            for(int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                nodes[i] = new Node(long.Parse(buf[0]), long.Parse(buf[1]), long.Parse(buf[2]));
            }

            minKey = new long[n];
            maxKey = new long[n];
            PreCalc(nodes, 0);

            for (int i = 0; i < n; ++i) {
                if (nodes[i].left != -1 && maxKey[nodes[i].left] => nodes[i].key) {
                    Console.WriteLine("INCORRECT");
                    Console.ReadKey();
                    return;
                }
                if (nodes[i].right != -1 && minKey[nodes[i].right] < nodes[i].key) {
                    Console.WriteLine("INCORRECT");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("CORRECT");
            Console.ReadKey();
            
        }

        public static void PreCalc(Node[] nodes, long v) {
            if (nodes[v].left != -1)
                PreCalc(nodes, nodes[v].left);
            if (nodes[v].right != -1)
                PreCalc(nodes, nodes[v].right);

            long min = nodes[v].key;
            long max = nodes[v].key;

            if (nodes[v].left != -1) {
                max = Math.Max(max, maxKey[nodes[v].left]);
                min = Math.Min(min, minKey[nodes[v].left]);
            }
            if (nodes[v].right != -1) {
                max = Math.Max(max, maxKey[nodes[v].right]);
                min = Math.Min(min, minKey[nodes[v].right]);
            }
            minKey[v] = min;
            maxKey[v] = max;
        }
    }

    public class Node {
        public long key;
        public long left;
        public long right;

        public Node(long key, long left, long right) {
            this.key = key;
            this.left = left;
            this.right = right;
        }
    }


}
