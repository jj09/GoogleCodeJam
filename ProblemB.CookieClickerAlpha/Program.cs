using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemB.CookieClickerAlpha
{
    class Case
    {
        public double C { get; set; }    // farm cost
        public double F { get; set; }    // cookies/sec (from farm)
        public double X { get; set; }    // to win
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../B-large.in");

            int testCasesCount = int.Parse(input[0]);
            var cases = new List<Case>();

            for (int i = 0; i < testCasesCount; ++i)
            {
                var c = new Case();
                var vals = input[1 + i].Split(' ').Select(x => double.Parse(x));
                c.C = vals.ElementAt(0);
                c.F = vals.ElementAt(1);
                c.X = vals.ElementAt(2);
                cases.Add(c);
            }

            var output = new List<string>();

            foreach (var aCase in cases)
            {
                int caseNo = output.Count + 1;
                double result = 0.0;
                int farmsCount = 0;

                double cookiesPerSec = 2.0;
                
                while (true)
                {
                    cookiesPerSec = 2 + farmsCount * aCase.F;
                                      
                    double timeNoExtraFarm = aCase.X / cookiesPerSec;
                    double timeToFarmBuyOpportunity = aCase.C / cookiesPerSec;

                    if (timeNoExtraFarm > timeToFarmBuyOpportunity)
                    {
                        // case - farm purchase?
                        result += timeToFarmBuyOpportunity;
                        timeNoExtraFarm -= timeToFarmBuyOpportunity;

                        double cookiesPerSecWithExtraFarm = 2 + (farmsCount + 1) * aCase.F;
                        double timeWithExtraFarm = aCase.X / cookiesPerSecWithExtraFarm;

                        if (timeNoExtraFarm < timeWithExtraFarm)
                        {
                            // don't buy
                            result += timeNoExtraFarm;
                            break;
                        }
                        else
                        {
                            // buy                            
                            ++farmsCount;
                        }
                    }
                    else
                    {
                        // case - no purchase farm  
                        result += timeNoExtraFarm;
                        break;
                    }
                }

                output.Add("Case #" + caseNo + ": " + result.ToString("0.0000000"));    // print to 7 decimal places
            }

            File.WriteAllLines("../../B-large.out", output);
        }
    }
}
