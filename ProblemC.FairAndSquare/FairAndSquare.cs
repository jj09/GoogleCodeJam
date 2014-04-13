using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProblemC.FairAndSquare
{
    // computation takes more than 20 mins (should be less than 8)
    class FairAndSquare
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../C-large-practice-1.in"))
                {
                    using (StreamWriter sw = new StreamWriter("../../C-large-practice-1.out"))
                    {
                        string line = sr.ReadLine();
                        int casesCount = int.Parse(line);

                        for (int i = 0; i < casesCount; ++i)
                        {
                            line = sr.ReadLine();
                            string[] input = line.Split(' ');
                            ulong A = ulong.Parse(input[0]);
                            ulong B = ulong.Parse(input[1]);

                            int max = 0;

                            ulong j = (ulong)Math.Sqrt(A);
                            while (j * j < A)
                                j = (ulong)Math.Sqrt(++A);

                            while (j*j <= B)
                            {
                                string number = j.ToString();

                                if (IsPalindrom(number))
                                {
                                    ulong square = j * j;
                                    if (IsPalindrom(square.ToString()))
                                    {
                                        ++max;
                                    }
                                }
                                ++j;
                            }

                            sw.WriteLine("Case #" + (i + 1) + ": " + max);
                            Console.WriteLine("Case #" + (i + 1) + ": " + max);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool IsPalindrom(string str)
        {
            for (int k = 0; k < str.Length - k; ++k)
            {
                if (str[k] != str[str.Length - k - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static string Reverse(string number)
        {
            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static BigInteger Sqrt(BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}
