using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemB.Lawnmower
{
    class Lawnmower
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
                            bool possible = true;
                            
                            //input
                            line = sr.ReadLine();
                            string[] input = line.Split(' ');
                            int n = int.Parse(input[0]);
                            int m = int.Parse(input[1]);

                            int[,] lawn = new int[n, m];
                            for (int j = 0; j < n; ++j)
                            {
                                line = sr.ReadLine();
                                string[] lineTab = line.Split(' ');
                                for (int k = 0; k < m; ++k)
                                    lawn[j, k] = int.Parse(lineTab[k]);
                            }

                            //computation
                            //for (int j = 1; j < n-1 && possible; ++j)
                            //{
                            //    for (int k = 1; k < m - 1 && possible; ++k)
                            //    {
                            //        if (lawn[j, k] < lawn[0, k] && lawn[j, k] < lawn[j, 0])
                            //            possible = false;

                            //        if (lawn[j, k] != lawn[0, k]) 
                            //        {
                            //            for (int l = 0; l < m && possible; ++l)
                            //            {
                            //                if (lawn[0, k] > lawn[0, l])
                            //                {
                            //                    possible = false;
                            //                }
                            //            }
                                        
                                        
                            //        }

                            //        if (lawn[j, k] != lawn[j, 0])
                            //        {
                            //            for (int l = 0; l < n && possible; ++l)
                            //            {
                            //                if (lawn[j, 0] > lawn[l, 0])
                            //                {
                            //                    possible = false;
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                            for (int j = 1; j < n && possible; ++j)
                            {
                                for (int k = 1; k < m && possible; ++k)
                                {
                                    if (lawn[j, 0] < lawn[j, k])
                                    {
                                        for (int l = 0; l < n && possible; ++l)
                                        {
                                            if(lawn[j, 0]<lawn[l,0])
                                                possible = false;
                                        }                                        
                                    }
                                }
                            }

                            for (int j = 1; j < n && possible; ++j)
                            {
                                for (int k = 1; k < m && possible; ++k)
                                {
                                    if (lawn[j, m-1] < lawn[j, k])
                                    {
                                        for (int l = 0; l < n && possible; ++l)
                                        {
                                            if (lawn[j, m-1] < lawn[l, m-1])
                                                possible = false;
                                        }
                                    }
                                }
                            }



                            for (int j = 1; j < m && possible; ++j)
                            {
                                for (int k = 1; k < n && possible; ++k)
                                {
                                    if (lawn[0, j] < lawn[k, j])
                                    {
                                        for (int l = 0; l < m && possible; ++l)
                                        {
                                            if (lawn[0,j] < lawn[0,l])
                                                possible = false;
                                        }
                                    }
                                }
                            }

                            for (int j = 1; j < m && possible; ++j)
                            {
                                for (int k = 1; k < n && possible; ++k)
                                {
                                    if (lawn[n-1, j] < lawn[k, j])
                                    {
                                        for (int l = 0; l < m && possible; ++l)
                                        {
                                            if (lawn[n-1, j] < lawn[0, l])
                                                possible = false;
                                        }
                                    }
                                }
                            }

                            for (int j = 1; j < n && possible; ++j)
                            {
                                for (int k = 1; k < m && possible; ++k)
                                {
                                    if (lawn[j, k] < lawn[0, k] && lawn[j, k] < lawn[j, 0])
                                    {
                                        possible = false;
                                    }
                                }
                            }

                            //output
                            sw.WriteLine("Case #" + (i + 1) + ": " + (possible ? "YES" : "NO"));
                            Console.WriteLine("Case #" + (i + 1) + ": " + (possible ? "YES" : "NO"));
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
