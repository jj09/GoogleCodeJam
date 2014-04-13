using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemD.DeceitfulWar
{
    class Program
    {
        class Case
        {
            public int N { get; set; }
            public IEnumerable<double> NaomisBlocks { get; set; }
            public IEnumerable<double> KensBlocks { get; set; }            
        }

        static void Main(string[] args)
        {
            const string fileName = "D-large";
            var input = File.ReadAllLines("../../" + fileName + ".in");

            int testCasesCount = int.Parse(input[0]);
            var cases = new List<Case>();

            for (int i = 0; i < testCasesCount; ++i)
            {
                var c = new Case();
                c.N = int.Parse(input[1 + i * 3]);
                c.NaomisBlocks = input[2 + i*3].Split(' ').Select(x => double.Parse(x));
                c.KensBlocks = input[3 + i * 3].Split(' ').Select(x => double.Parse(x));
                cases.Add(c);
            }

            var output = new List<string>();

            foreach (var aCase in cases)
            {
                int caseNo = output.Count + 1;
                int deceitfulWarPoints = 0;
                int warPoints = 0;

                var naomisBlocksForWar = aCase.NaomisBlocks.ToList();
                var kensBlocksForWar = aCase.KensBlocks.ToList();

                var naomisBlocksForDeceitfulWar = aCase.NaomisBlocks.OrderBy(x => x).ToList();
                var kensBlocksForDeceitfulWar = aCase.KensBlocks.OrderBy(x => x).ToList();

                while (aCase.N-- > 0)
                {
                    // war
                    var naomisBlock = naomisBlocksForWar[0];
                    naomisBlocksForWar.RemoveAt(0);

                    var kensBlocks = kensBlocksForWar.Where(x => x > naomisBlock);
                    double kensBlock;
                    if (kensBlocks.Count() == 0)
                    {
                        kensBlock = kensBlocksForWar.Min();
                    }
                    else
                    {
                        kensBlock = kensBlocks.Min();
                    }
                    kensBlocksForWar.Remove(kensBlock);

                    if (naomisBlock > kensBlock)
                    {
                        ++warPoints;
                    }

                    // decitful war
                    double kensDeceitfulBlock;
                    double naomisDeceitfulBlock;
                    if (naomisBlocksForDeceitfulWar.Max() > kensBlocksForDeceitfulWar.Max())
                    {
                        // choose max
                        kensDeceitfulBlock = kensBlocksForDeceitfulWar.Max();
                        naomisDeceitfulBlock = naomisBlocksForDeceitfulWar.Max();
                        ++deceitfulWarPoints;
                    }
                    else
                    {
                        // choose min
                        kensDeceitfulBlock = kensBlocksForDeceitfulWar.Max();
                        naomisDeceitfulBlock = naomisBlocksForDeceitfulWar.Min();
                    }
                    kensBlocksForDeceitfulWar.Remove(kensDeceitfulBlock);
                    naomisBlocksForDeceitfulWar.Remove(naomisDeceitfulBlock);
                }

                output.Add("Case #" + caseNo + ": " + deceitfulWarPoints + " " + warPoints);
            }

            File.WriteAllLines("../../" + fileName + ".out", output);
        }
    }
}
