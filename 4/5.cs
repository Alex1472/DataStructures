using System;

public class MainClass
{
    static Random rand = new Random();
    public static void Main()
    {
        string s = Console.ReadLine();
            Vertex root = null;
            for (int i = 0; i < s.Length; ++i)
                root = Merge(root, new Vertex(s[i]));

            int n = int.Parse(Console.ReadLine());
            string[] buf;
            for (int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int l = int.Parse(buf[0]);
                int r = int.Parse(buf[1]);
                int k = int.Parse(buf[2]);
                Vertex[] fSplit = Split(root, l);
                Vertex[] sSplit = Split(fSplit[1], r - l + 1);
                Vertex delSubstring = Merge(fSplit[0], sSplit[1]);
                Vertex substring = sSplit[0];
                Vertex[] tSplit = Split(delSubstring, k);
                root = Merge(Merge(tSplit[0], substring), tSplit[1]);
            }
            PrintTree(root);
    }
    
    static Vertex[] Split(Vertex root, long key) {
            if (root == null)
                return new Vertex[] { null, null };
            int leftSize = root.left == null ? 0 : root.left.size;

            if (leftSize >= key) {
                Vertex[] splittedTree = Split(root.left, key);
                root.left = splittedTree[1];
                Recalc(root);
                return new Vertex[] { splittedTree[0], root };
            } else {
                Vertex[] splittedTree = Split(root.right, key - leftSize - 1);
                root.right = splittedTree[0];
                Recalc(root);
                return new Vertex[] { root, splittedTree[1] };
            }
        }

        static Vertex Merge(Vertex less, Vertex more) {
            if (less == null)
                return more;
            if (more == null)
                return less;
            int x = rand.Next() % (less.size + more.size);
            if (x < less.size) {
                less.right = Merge(less.right, more);
                Recalc(less);
                return less;
            } else {
                more.left = Merge(less, more.left);
                Recalc(more);
                return more;
            }
        }

        static void Recalc(Vertex v) {
            if (v == null)
                return;
            int size = 1;
            size += v.left == null ? 0 : v.left.size;
            size += v.right == null ? 0 : v.right.size;
            v.size = size;
        }

        static void PrintTree(Vertex root) {
            if (root == null) return;

            PrintTree(root.left);
            Console.Write(root.letter);
            PrintTree(root.right);
        }
}

public class Vertex {
        public Vertex left;
        public Vertex right;
        public int size;
        public char letter;

        public Vertex(char letter) {
            this.left = null;
            this.right = null;
            this.size = 1;
            this.letter = letter;
        }
    }

    
