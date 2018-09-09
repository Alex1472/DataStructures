using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            string[] buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; ++i)
                numbers[i] = int.Parse(buf[i]);

            int window = int.Parse(Console.ReadLine());

            QueueWithMax queue = new QueueWithMax();
            for (int i = 0; i < window; ++i)
                queue.Enqueue(numbers[i]);
            Console.Write(queue.Max() + " ");
            for (int i = window; i < n; ++i) {
                queue.Enqueue(numbers[i]);
                queue.Dequeue();
                Console.Write(queue.Max() + " ");
            }
            Console.ReadKey();
        }
    }

    public class StackWithMax {
        Stack<int> dataStack;
        Stack<int> maxStack;

        public StackWithMax() {
            this.dataStack = new Stack<int>();
            this.maxStack = new Stack<int>();
        }

        public void Push(int x) {
            this.dataStack.Push(x);
            if (this.maxStack.Count == 0) {
                this.maxStack.Push(x);
                return;
            }
            this.maxStack.Push(Math.Max(x, this.maxStack.Peek()));
        }

        public int Pop() {
            this.maxStack.Pop();
            return this.dataStack.Pop();
        }

        public int Max() {
            return this.maxStack.Peek();
        }

        public int Count() {
            return this.maxStack.Count();
        }
    }

    public class QueueWithMax {
        StackWithMax LStack;
        StackWithMax RStack;

        public QueueWithMax() {
            this.LStack = new StackWithMax();
            this.RStack = new StackWithMax();
        }

        public void Enqueue(int x) {
            this.LStack.Push(x);
        }

        public int Dequeue() {
            if (this.RStack.Count() == 0)
                while (this.LStack.Count() != 0)
                    this.RStack.Push(this.LStack.Pop());
            return this.RStack.Pop();
        }

        public int Max() {
            if (this.LStack.Count() == 0)
                return this.RStack.Max();
            if (this.RStack.Count() == 0)
                return this.LStack.Max();
            return Math.Max(this.RStack.Max(), this.LStack.Max());
        }
    }
}
