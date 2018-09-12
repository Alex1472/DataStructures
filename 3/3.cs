using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main()
    {
        string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            ulong[] textSuffixHash = CalculateSuffixHash(text);
            ulong patternHash = CalculateSuffixHash(pattern)[0];

            ulong x = 1;
            for (int i = 0; i < pattern.Length; ++i)
                x *= 263;
            List<int> result = new List<int>();
            if (textSuffixHash[text.Length - pattern.Length] == patternHash)
                result.Add(text.Length - pattern.Length);

            for(int i = text.Length - pattern.Length - 1; i >= 0; --i) {
                if (textSuffixHash[i] - textSuffixHash[i + pattern.Length] * x == patternHash)
                    result.Add(i);
                
            }

            for (int i = result.Count - 1; i >= 0; --i)
                Console.Write(result[i] + " ");
    }
    
    static ulong[] CalculateSuffixHash(string s) {
            ulong[] hash = new ulong[s.Length];
            ulong x = 263;
            ulong result = 0;
            for (int i = s.Length - 1; i >= 0; --i) {
                result = result * x + s[i];
                hash[i] = result;
            }
            return hash;
        }
}
