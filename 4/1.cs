using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {

        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            Node[] nodes = new Node[n];
            string[] buf;
            for(int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                nodes[i] = new Node(int.Parse(buf[0]), int.Parse(buf[1]), int.Parse(buf[2]));
            }
            InOrder(nodes, 0);
            Console.WriteLine();
            PreOrder(nodes, 0);
            Console.WriteLine();
            PostOrder(nodes, 0);
            Console.ReadKey();
        }

        static void InOrder(Node[] nodes, int v) {
            if (nodes[v].left != -1)
                InOrder(nodes, nodes[v].left);
            Console.Write(nodes[v].key + " ");
            if (nodes[v].right != -1)
                InOrder(nodes, nodes[v].right);
        }
        
        static void PreOrder(Node[] nodes, int v) {
            Console.Write(nodes[v].key + " ");
            if (nodes[v].left != -1)
                PreOrder(nodes, nodes[v].left);
            if (nodes[v].right != -1)
                PreOrder(nodes, nodes[v].right);
        }

        static void PostOrder(Node[] nodes, int v) {
            if (nodes[v].left != -1)
                PostOrder(nodes, nodes[v].left);
            if (nodes[v].right != -1)
                PostOrder(nodes, nodes[v].right);
            Console.Write(nodes[v].key + " ");
        }
    }

    public class Node {
        public int key;
        public int left;
        public int right;

        public Node(int key, int left, int right) {
            this.key = key;
            this.left = left;
            this.right = right;
        }
    }


}
