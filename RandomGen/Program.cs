using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RandomGen
{
    class Program
    {
        static string csvOut;                           // If provided on command line, output file name for ultimate resutls to disk file.
        static void Main(string[] args)
        {

            
            bool bStdOut;                               // If no filename provided as argument, output will be send to stdout, this is a flag
            int minValue  = 1;                          // The inclusive lower bound
            int maxValue  = 10000;                      // The inclusive upper bound
            int cTotalNum = 10000;                      // Total numbers to be generated
            List<int> lResult = new List<int>();        // List of int, which holds ultimate generated random numbers.
            HashSet<int> hCheck = new HashSet<int>();   // The ´HashSet´ is faster for lookup than list lookup, however it doesn't preserve the order of the items, we still need the List though

            #region Checking command line argumnet and deciding destination output: standard output or file
            if (args.Length == 0)
            {
                bStdOut = true;
            }
            else
            {
                // output file provided
                bStdOut = false;
                csvOut = args[0]; // get output file name from command line
            }
#endregion


            #region generating random number and storing them in lResult list
            Console.Write("Generating a list of " + cTotalNum + " unique numbers in random order between " + minValue + " and "+ maxValue+" (inclusive)...");

            Random rand = new Random();
            while (lResult.Count < cTotalNum)
            {
                int curValue = rand.Next(minValue, maxValue);
                while (hCheck.Contains(curValue))
                {
                    // check to see if current generated number is unique

                    // A 32-bit signed integer greater than or equal to minValue and less than maxValue; 
                    // that is, the range of return values includes minValue but not maxValue. 
                    // adding 1 to maxValue to meet objective of inclusive of 1 and 10000
                    curValue = rand.Next(minValue, maxValue + 1);
                }
                lResult.Add(curValue);
                hCheck.Add(curValue);
            }
            Console.Write("done!\r\n\n");
#endregion


            #region producing generated results, standard output or static file.
            if (bStdOut) // if no command line argument is provided, output will be send to console.
            {
                foreach (var rNum in lResult)
                {
                    Console.Write(rNum.ToString() + "\t"); // print output to tab delimited console.
                }

                System.Console.WriteLine("\r\n\nGenerated random numbers can be redirected to output file.");
                System.Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " output.csv");
                System.Environment.Exit(0);
            }
            else  // command line provided and output will be written into static file.
            {
                try
                {
                    // within .net 3.5
                    File.WriteAllLines(csvOut, lResult.Select(x => x.ToString()).ToArray());
                    Console.WriteLine("\r\nOutput saved to file.");
                }
                catch(Exception e)
                {
                    Console.WriteLine("\r\nerror creating output file: "+ csvOut + " :" + e.Message);
                }
                finally
                {
                    System.Environment.Exit(0);
                }
            }
#endregion
        }
    }
}