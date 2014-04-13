using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA.Bullseye
{
    // Working for small instance - for big better approach is use binary search of result (ffao solution)
    class Bullseye
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../A-large.in"))
                {
                    using (StreamWriter sw = new StreamWriter("../../A-large.out"))
                    {
                        string line = sr.ReadLine();
                        int casesCount = int.Parse(line);

                        for (int i = 0; i < casesCount; ++i)
                        {
                            //input
                            line = sr.ReadLine();
                            string[] input = line.Split(' ');
                            ulong r = ulong.Parse(input[0]);
                            ulong t = ulong.Parse(input[1]);
                            int y = 0;  //always at least 1

                            //computation
                            while (true)
                            {
                                //float small = r * r;
                                //float big = (r + 1) * (r + 1);
                                //t -= (big - small);
                                ulong area = 2 * r + 1; // a*a - b*b = (a+b)*(a-b) => (r+1)*(r+1) - r*r = (r+1+r)*(r+1-r) = 2*r + 1
                                if (t >= area)
                                {
                                    t -= area;
                                    ++y;
                                    r += 2;
                                }
                                else
                                    break;
                            }

                            //output
                            sw.WriteLine("Case #" + (i + 1) + ": " + y);
                            Console.WriteLine("Case #" + (i + 1) + ": " + y);
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
