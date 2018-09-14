using System;

public class MainClass {

    public static Random rand = new Random();
    public static void Main() {

        int n = int.Parse(Console.ReadLine());
            string[] buf;
            Vertex root = null;

            long s = 0;
            for (int i = 0; i < n; ++i) {
                buf = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (buf[0] == "+" && !Find(root, f(long.Parse(buf[1]), s)))
                    root = Add(root, f(long.Parse(buf[1]), s));

                if (buf[0] == "?")
                    Console.WriteLine(Find(root, f(long.Parse(buf[1]), s)) ? "Found" : "Not found");
               
                if (buf[0] == "-" && Find(root, f(long.Parse(buf[1]), s))) 
                    root = Delete(root, f(long.Parse(buf[1]), s));
                    
                if (buf[0] == "s") {
                    long l = f(long.Parse(buf[1]), s);
                    long r = f(long.Parse(buf[2]), s);

                    Vertex[] fSplit = Split(root, l);
                    if (r == 1000000000) {
                        if (fSplit[1] != null)
                            s = fSplit[1].sum;
                        else
                            s = 0;
                        Console.WriteLine(s);
                        root = Merge(fSplit[0], fSplit[1]);
                    } else {
                        Vertex[] sSplit = Split(fSplit[1], r + 1);
                        if (sSplit[0] != null)
                            s = sSplit[0].sum;
                        else 
                            s = 0;
                        Console.WriteLine(s);
                        root = Merge(fSplit[0], Merge(sSplit[0], sSplit[1]));
                    }
                }

            }
    }
    
    static long f(long i, long s){
            return (i + s) % 1000000001;
        }

        static Vertex[] Split(Vertex root, long key) {
            if (root == null)
                return new Vertex[] { null, null };

            if (root.key < key) {
                Vertex[] splittedTree = Split(root.right, key);
                root.right = splittedTree[0];
                Recalc(root);
                return new Vertex[] { root, splittedTree[1] };
            } else {
                Vertex[] splittedTree = Split(root.left, key);
                root.left = splittedTree[1];
                Recalc(root);
                return new Vertex[] { splittedTree[0], root };
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

        static Vertex Add(Vertex root, long key) {
            if (root == null)
                return new Vertex(key);

            
            int x = rand.Next() % (root.size + 1);

            if (x == 0) {
                Vertex[] splittedTree = Split(root, key);
                Vertex result = new Vertex(key);
                result.left = splittedTree[0];
                result.right = splittedTree[1];
                Recalc(result);
                return result;
            }

            if (root.key >= key)
                root.left = Add(root.left, key);
            else
                root.right = Add(root.right, key);
            Recalc(root);
            return root;
        }

        static Vertex Delete(Vertex root, long key) {
            if (root.key == key)
                return Merge(root.left, root.right);

            if (root.key > key)
                root.left = Delete(root.left, key);
            else
                root.right = Delete(root.right, key);
            Recalc(root);
            return root;
        }

        static void Recalc(Vertex v) {
            if (v == null)
                return;
            int size = 1;
            size += v.left == null ? 0 : v.left.size;
            size += v.right == null ? 0 : v.right.size;
            v.size = size;

            long sum = v.key;
            sum += v.left == null ? 0 : v.left.sum;
            sum += v.right == null ? 0 : v.right.sum;
            v.sum = sum;
        }

        static bool Find(Vertex root, long key) {
            if (root == null)
                return false;
            if (root.key == key)
                return true;

            if (root.key > key)
                return Find(root.left, key);
            else
                return Find(root.right, key);
        }

        static void PrintTree(Vertex root, int level) {
            if (root == null)
                return;
            PrintTree(root.left, level + 1);
            for (int i = 0; i < level; ++i)
                Console.Write(".");
            Console.WriteLine(root.key);
            PrintTree(root.right, level + 1);
        }
}

public class Vertex {
        public Vertex left;
        public Vertex right;
        public long key;
        public long sum;
        public int size;

        public Vertex(long key) {
            this.left = null;
            this.right = null;
            this.key = key;
            this.size = 1;
            this.sum = key;
        }
    }

