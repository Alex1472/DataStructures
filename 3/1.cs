using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSequence {
    public class Program {

        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            HashTable hashTable = new HashTable(10000000);
            string[] buf; 
            for (int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (buf[0] == "add")
                    hashTable.Add(int.Parse(buf[1]), buf[2]);
                if (buf[0] == "find") {
                    string result = hashTable.Find(int.Parse(buf[1]));
                    if (result != null)
                        Console.WriteLine(result);
                    else
                        Console.WriteLine("not found");
                }
                if (buf[0] == "del") {
                    hashTable.Delete(int.Parse(buf[1]));
                }

            }
        }
    }

    public class HashTable {
        readonly int size;
        string[] hashTable;

        public HashTable(int size) {
            this.size = size;
            this.hashTable = new string[size];
        }

        public void Add(int number, string name){
            this.hashTable[number] = name;
        }

        public void Delete(int number) {
            this.hashTable[number] = null;
        }

        public string Find(int number) {
            return this.hashTable[number];
        }
    }
}
