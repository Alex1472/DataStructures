using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {

        static void Main(string[] args) {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            HashTable hashTable = new HashTable(m);
            string[] buf;
            for (int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (buf[0] == "add")
                    hashTable.Add(buf[1]);
                if (buf[0] == "check")
                    hashTable.Check(int.Parse(buf[1]));
                if (buf[0] == "del")
                    hashTable.Delete(buf[1]);
                if (buf[0] == "find")
                    Console.WriteLine(hashTable.Find(buf[1]) ? "yes" : "no");
            }
            Console.ReadKey();
        }
    }

    public class HashTable {
        const int p = 1000000007;
        long[] powers;
        int hashTableSize;
        LinkedList<string>[] data;

        public HashTable(int size) {
            this.hashTableSize = size;
            this.data = new LinkedList<string>[size];
            for (int i = 0; i < size; ++i)
                this.data[i] = new LinkedList<string>();
            this.powers = new long[15];
            long x = 1;
            for (int i = 0; i < 15; ++i) {
                powers[i] = x;
                x = (x * 263) % p;
            }
        }

        long CalculateHash(string s) {
            long result = 0;
            for (int i = 0; i < s.Length; ++i)
                result = (result + s[i] * powers[i]) % p;
            return result % hashTableSize;
        }

        public void Add(string s) {
            if (!Find(s))
                this.data[CalculateHash(s)].AddFirst(s);
        }

        public void Check(int m) {
            foreach (string s in this.data[m])
                Console.Write(s + " ");
            Console.WriteLine();
        }

        public bool Find(string s) {
            long hash = CalculateHash(s);
            LinkedListNode<string> result = this.data[hash].Find(s);
            return !(result == null);
        }

        public void Delete(string s) {
            long hash = CalculateHash(s);
            this.data[hash].Remove(s);
        }
    }
}
