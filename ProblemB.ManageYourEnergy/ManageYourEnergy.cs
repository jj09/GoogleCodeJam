using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemB.ManageYourEnergy
{
    class ManageYourEnergy
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../B-small-attempt2.in"))
                {
                    using (StreamWriter sw = new StreamWriter("../../B-small-attempt2.out"))
                    {
                        string line = sr.ReadLine();
                        int casesCount = int.Parse(line);

                        for (int i = 0; i < casesCount; ++i)
                        {
                            //input
                            line = sr.ReadLine();
                            string[] input = line.Split(' ');
                            int E = int.Parse(input[0]);
                            int R = int.Parse(input[1]);
                            int N = int.Parse(input[2]);

                            line = sr.ReadLine();
                            input = line.Split(' ');
                            int[] v = new int[N];
                            for (int j = 0; j < N; ++j)
                            {
                                v[j] = int.Parse(input[j]);
                            }

                            //computation

                            results.Clear();
                            Work(v, N, E, R, 0, 0);
                            int result = results.Max();


                            //output
                            sw.WriteLine("Case #" + (i + 1) + ": " + result);
                            Console.WriteLine("Case #" + (i + 1) + ": " + result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Work(int[] v, int N, int E, int R, int result, int task)
        {
            if (E > 0)
            {
                for (int i = 0; i <= E; ++i)
                {
                    int e = E - i + R > E ? E : E - i + R;
                    int newResult = result + (i * v[task]);
                    if (task + 1 < N)
                        Work(v, N, e, R, newResult, task + 1);
                    else
                        results.AddLast(newResult);
                }
            }
            else if (task + 1 < N)
            {
                Work(v, N, R, R, result, task + 1);
            }
            
        }

        private static LinkedList<int> results = new LinkedList<int>();
    }
}
