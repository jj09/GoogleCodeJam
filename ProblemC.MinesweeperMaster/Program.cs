using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemC.MinesweeperMaster
{
    class Program
    {
        class Case
        {
            public int R { get; set; }  // board width(?)
            public int C { get; set; }  // board height(?)
            public int M { get; set; }  // number of mines
        }

        static void Main(string[] args)
        {
            const string fileName = "C-sample";
            var input = File.ReadAllLines("../../" + fileName + ".in");

            int testCasesCount = int.Parse(input[0]);
            var cases = new List<Case>();

            for (int i = 0; i < testCasesCount; ++i)
            {
                var c = new Case();
                string[] caseLine = input[1 + i].Split(' ');
                c.R = int.Parse(caseLine[0]);
                c.C = int.Parse(caseLine[1]);
                c.M = int.Parse(caseLine[2]);
                cases.Add(c);
            }

            var output = new List<string>();

            foreach (var aCase in cases)
            {
                int caseNo = output.Count + 1;
                
                // TODO: implement

                // generate all possible mines configuration (choose M numbers from all cells)
                // enumerate adjacent mines number (iteratively)
                // validate solution - check if there is a path from all 0 fields to all no-mines fields (recursive checking)
                // c has to be 0

                output.Add("Case #" + caseNo);
            }

            File.WriteAllLines("../../" + fileName + ".out", output);
        }
    }
}
