using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA.MagicTrick
{
    class Case
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int[][] FirstArrangement { get; set; }
        public int[][] SecondArrangement { get; set; }

        public Case()
        {
            FirstArrangement = new int[4][];
            for (int i = 0; i < 4; ++i)
            {
                FirstArrangement[i] = new int[4];
            }

            SecondArrangement = new int[4][];
            for (int i = 0; i < 4; ++i)
            {
                SecondArrangement[i] = new int[4];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../A-small-attempt0.in");
            

            int casesCount = int.Parse(input[0]);
            var cases = new List<Case>();

            for (int i = 0; i < casesCount; ++i)
            {
                var newCase = new Case();
                newCase.FirstNumber = int.Parse(input[1 + i * 10])-1;

                for (int j = 0; j < 4; ++j)
                {
                    var numbers = input[1 + i * 10 + 1 + j].Split(' ');
                    for (int k = 0; k < 4; ++k)
                    {
                        newCase.FirstArrangement[j][k] = int.Parse(numbers[k]);
                    }
                }

                newCase.SecondNumber = int.Parse(input[6 + i * 10])-1;

                for (int j = 0; j < 4; ++j)
                {
                    var numbers = input[6 + i * 10 + 1 + j].Split(' ');
                    for (int k = 0; k < 4; ++k)
                    {
                        newCase.SecondArrangement[j][k] = int.Parse(numbers[k]);
                    }
                }
                cases.Add(newCase);
            }


            var output = new List<string>();
            foreach (var aCase in cases)
            {
                int[] numbers = aCase.FirstArrangement[aCase.FirstNumber];
                var result = aCase.FirstArrangement[aCase.FirstNumber].Intersect(aCase.SecondArrangement[aCase.SecondNumber]);
                int caseNo = output.Count + 1;
                if(result.Count() == 1) 
                {
                    output.Add("Case #" + caseNo + ": " + result.ElementAt(0).ToString());
                }
                else if (result.Count() == 0)
                {
                    output.Add("Case #" + caseNo + ": Volunteer cheated!");
                }
                else if (result.Count() > 1)
                {
                    output.Add("Case #" + caseNo + ": Bad magician!");
                }
            }

            File.WriteAllLines("../../A-small-attempt0.out", output);
        }
    }
}
