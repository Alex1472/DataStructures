using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence { 
    public class Program {
        static void Main(string[] args) {
            StackWithMax stack = new StackWithMax();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; ++i) {
                string[] buf = Console.ReadLine().Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                if (buf[0] == "push")
                    stack.Push(int.Parse(buf[1]));
                if (buf[0] == "pop")
                    stack.Pop();
                if (buf[0] == "max")
                    Console.WriteLine(stack.Max());
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
    }
}
