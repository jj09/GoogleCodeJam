using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA.TheRepeater
{
    class Program
    {
        class Case
        {
            public int CaseNumber { get; set; }
            public int N { get; set; }
            public IList<string> Strings = new List<string>();
        }

        static void Main(string[] args)
        {
            const string fileName = "A-small-attempt1";

            var input = File.ReadAllLines("../../" + fileName + ".in");
            var cases = new List<Case>();

            // read input
            int lineIndex = 0;
            int testCasesCount = int.Parse(input[lineIndex]);
            
            for (int i = 0; i < testCasesCount; ++i)
            {
                var c = new Case();
                c.CaseNumber = i + 1;

                c.N = int.Parse(input[++lineIndex]);

                for (int j = 0; j < c.N; ++j)
                {
                    c.Strings.Add(input[++lineIndex] + " ");
                }
                
                cases.Add(c);
            }

            // process cases

            var output = new List<string>();

            foreach (var c in cases)
            {
                var strings = c.Strings.ToArray();
                int stringsLenSum = c.Strings.Sum(x => x.Length);

                //var arr = new char[c.N, stringsLenSum];
                var indexes = new int[c.N];

                var curIndex = 0;
                var moves = 0;
                while (true)
                {
                    char mostCommon = strings.Select(x => x[curIndex]).GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).Take(1).FirstOrDefault();
                    if (mostCommon == '\0')
                    {
                        break;
                    }
                    var canRemove = new bool[c.N];
                    var canInsert = new bool[c.N];
                    var isMostCommon = new bool[c.N];

                    for (int i = 0; i < c.N; ++i)
                    {
                        if (curIndex < strings[i].Length && strings[i][curIndex].Equals(mostCommon))
                        {
                            isMostCommon[i] = true;
                        }
                        else
                        {
                            if (curIndex == 0)
                            {
                                canRemove[i] = strings[i][curIndex].Equals(strings[i][curIndex + 1]);
                                canInsert[i] = false;
                            }
                            else if (curIndex == strings[i].Length - 1)
                            {
                                canRemove[i] = strings[i][curIndex].Equals(strings[i][curIndex - 1]);
                                canInsert[i] = strings[i][curIndex - 1].Equals(mostCommon);
                            }
                            else
                            {
                                canRemove[i] = (strings[i][curIndex].Equals(strings[i][curIndex - 1]) || strings[i][curIndex].Equals(strings[i][curIndex + 1]));
                                canInsert[i] = strings[i][curIndex - 1].Equals(mostCommon);
                            }
                        }
                    }

                    if (isMostCommon.Count(x => x == true) == c.N)
                    {
                        ++curIndex;
                        if (mostCommon == ' ')
                            break;
                    }
                    else
                    {
                        for (int i = 0; i < c.N; ++i)
                        {
                            if (isMostCommon[i])
                            {
                                continue;
                            }
                            else if (canInsert[i])
                            {
                                strings[i] = strings[i].Insert(curIndex, strings[i][curIndex - 1].ToString()); // strings[i].Substring(0, curIndex - 1) + strings[i][curIndex - 1] + strings[i].Substring(curIndex);
                                moves++;
                            }
                            else if (canRemove[i])
                            {
                                strings[i] = strings[i].Remove(curIndex, 1);
                                moves++;
                            }
                            else
                            {
                                moves = -1;
                                break;
                            }
                        }
                        if (moves < 0) break;
                    }
                }

                if (moves >= 0)
                {
                    output.Add("Case #" + c.CaseNumber + ": " + moves);
                }
                else
                {
                    output.Add("Case #" + c.CaseNumber + ": " + "Felga Won");
                }
            }

            File.WriteAllLines("../../" + fileName + ".out", output);
        }
    }
}
