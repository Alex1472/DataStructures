using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {
        static List<int[]> result = new List<int[]>();
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            string[] buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] heap = new int[n];
            for (int i = 0; i < n; ++i)
                heap[i] = int.Parse(buf[i]);
            int size = 1;
            while (2 * size < n)
                size *= 2;
            for (int i = size - 1; i >= 0; --i)
                SiftDown(heap, i);

            Console.WriteLine(result.Count);
            foreach (int[] pair in result)
                Console.WriteLine(pair[0] + " " + pair[1]);
            Console.ReadKey();
        }

        static void SiftDown(int[] heap, int i) {
            int min = heap[i];
            int mini = i;

            if (2 * i + 1 < heap.Length && heap[2 * i + 1] < min) {
                mini = 2 * i + 1;
                min = heap[2 * i + 1];
            }

            if (2 * i + 2 < heap.Length && heap[2 * i + 2] < min) {
                mini = 2 * i + 2;
                min = heap[2 * i + 2];
            }

            if (mini != i) {
                result.Add(new int[] { i, mini });
                int tmp = heap[i];
                heap[i] = heap[mini];
                heap[mini] = tmp;
                SiftDown(heap, mini);
            }
        }
    }
}
