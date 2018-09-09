using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence { 
    public class Program {
        static void Main(string[] args) {
            string sequence = Console.ReadLine();
            Stack<StackBreak> stack = new Stack<StackBreak>();

            for(int i = 0; i < sequence.Length; ++i) {
                if (sequence[i] != '[' && sequence[i] != ']' && sequence[i] != '(' 
                        && sequence[i] != ')' && sequence[i] != '{' && sequence[i] != '}')
                    continue;

                if (sequence[i] == '[' || sequence[i] == '(' || sequence[i] == '{') {
                    stack.Push(new StackBreak(sequence[i], i));
                    continue;
                }
                if (stack.Count == 0) {
                    Console.WriteLine(i + 1);
                    Console.ReadKey();
                    return;
                }

                if (!Match(stack.Pop().SBreak, sequence[i])) {
                    Console.WriteLine(i + 1);
                    Console.ReadKey();
                    return;
                }
            }

            if (stack.Count == 0)
                Console.WriteLine("Success");
            else
                Console.WriteLine(stack.Pop().Position + 1);
            Console.ReadKey();
        }

        public static bool Match(char l, char r) {
            return (l == '[' && r == ']') || (l == '(' && r == ')') || (l == '{' && r == '}');
        }
    }

    public class StackBreak {
        public char SBreak;
        public int Position;

        public StackBreak(char sBreak, int position)
        {
            SBreak = sBreak;
            Position = position;
        }
    }
}
