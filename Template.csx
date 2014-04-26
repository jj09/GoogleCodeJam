using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    class Program
    {
        class Case
        {
        	public int CaseNumber { get; set; }
        }

        static void Main(string[] args)
	    {
		    const string fileName = "A-sample";

            var input = File.ReadAllLines("../../" + fileName + ".in");
            var cases = new List<Case>();

            // read input
            int testCasesCount = int.Parse(input[0]);

            for (int i = 0; i < testCasesCount; ++i)
            {
                var c = new Case();
                c.CaseNumber = i+1;
                
                // specific parsing

                cases.Add(c);
            }

            // process cases

            var output = new List<string>();

            foreach (var c in cases)
            {

        	    output.Add("Case #" + c.CaseNumber + ": " );
            }

            File.WriteAllLines("../../" + fileName + ".out", output);
	    }
    }

}
