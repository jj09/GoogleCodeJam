﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA
{
    /* Correct
     https://code.google.com/codejam/contest/1460488/dashboard
    Problem

    We have come up with the best possible language here at Google, called Googlerese. To translate text into Googlerese, we take any message and replace each English letter with another English letter. This mapping is one-to-one and onto, which means that the same input letter always gets replaced with the same output letter, and different input letters always get replaced with different output letters. A letter may be replaced by itself. Spaces are left as-is.

    For example (and here is a hint!), our awesome translation algorithm includes the following three mappings: 'a' -> 'y', 'o' -> 'e', and 'z' -> 'q'. This means that "a zoo" will become "y qee".

    Googlerese is based on the best possible replacement mapping, and we will never change it. It will always be the same. In every test case. We will not tell you the rest of our mapping because that would make the problem too easy, but there are a few examples below that may help.

    Given some text in Googlerese, can you translate it to back to normal text?

    Solving this problem

    Usually, Google Code Jam problems have 1 Small input and 1 Large input. This problem has only 1 Small input. Once you have solved the Small input, you have finished solving this problem.

    Input

    The first line of the input gives the number of test cases, T. T test cases follow, one per line.
    Each line consists of a string G in Googlerese, made up of one or more words containing the letters 'a' - 'z'. There will be exactly one space (' ') character between consecutive words and no spaces at the beginning or at the end of any line.

    Output

    For each test case, output one line containing "Case #X: S" where X is the case number and S is the string that becomes G in Googlerese.

    Limits

    1 ≤ T ≤ 30.
    G contains at most 100 characters.
    None of the text is guaranteed to be valid English.
    Sample

    Input
    3
    ejp mysljylc kd kxveddknmc re jsicpdrysi
    rbcpc ypc rtcsra dkh wyfrepkym veddknkmkrkcd
    de kr kd eoya kw aej tysr re ujdr lkgc jv
    
    Output
    Case #1: our language is impossible to understand
    Case #2: there are twenty six factorial possibilities
    Case #3: so it is okay if you want to just give up
     */
    class SpeakingInTongues
    {
        static Dictionary<string, string> dict = new Dictionary<string, string>
        {
            {"a", "y"},
            {"b", "h"},
            {"c", "e"},
            {"d", "s"},
            {"e", "o"},
            {"f", "c"},
            {"g", "v"},
            {"h", "x"},
            {"i", "d"},
            {"j", "u"},
            {"k", "i"},
            {"l", "g"},
            {"m", "l"},
            {"n", "b"},
            {"o", "k"},
            {"p", "r"},
            {"q", "z"},
            {"r", "t"},
            {"s", "n"},
            {"t", "w"},
            {"u", "j"},
            {"v", "p"},
            {"w", "f"},
            {"x", "m"},
            {"y", "a"},
            {"z", "q"}
        };
        
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../A-small-practice.in"))
                {
                    using(StreamWriter sw = new StreamWriter("../../A-small-practice.out"))
                    {
                        string line = sr.ReadLine();
                        int n = int.Parse(line);
                        for(int i=0; i<n; ++i)
                        {
                            line = sr.ReadLine();
                            StringBuilder sb = new StringBuilder();
                            for (int j = 0; j < line.Length; ++j)
                            {
                                if(line[j].CompareTo(' ')!=0)
                                    sb.Append(dict[line[j].ToString()]);
                                else
                                    sb.Append(" ");
                            }
                            sw.WriteLine("Case #" + (i + 1) + ": " + sb);
                            Console.WriteLine("Case #" + (i + 1) + ": " + sb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
