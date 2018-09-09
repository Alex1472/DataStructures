using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());

            List<int>[] children = new List<int>[n];
            for (int i = 0; i < n; ++i)
                children[i] = new List<int>();
            int root = -1;

            string[] buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; ++i) {
                int parent = int.Parse(buf[i]);
                if (parent == -1) {
                    root = i;
                    continue;
                }
                children[parent].Add(i);
            }

            Console.WriteLine(CalculateTreeHeight(root, children));
            Console.ReadKey();
        }

        public static int CalculateTreeHeight(int point, List<int>[] children) {
            int height = 1;
            foreach (int i in children[point])
                height = Math.Max(height, CalculateTreeHeight(i, children) + 1);
            return height;
        }
    }

    
}
