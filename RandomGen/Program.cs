using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RandomListGen;

namespace RandomGen
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int minValue  = 1;                          // The inclusive lower bound
            int maxValue  = 10000;                      // The inclusive upper bound
            int cTotalNum = 10000;                      // Total numbers to be generated
            RandomList randomList = new RandomList();   // create an instance of random number generator library


            Console.Write("Generating a list of " + cTotalNum + " unique numbers in random order between " + minValue + " and "+ maxValue+" (inclusive)...");
            List<int> lResult = randomList.Generate(minValue, maxValue, cTotalNum); // List of int, which holds ultimate generated random numbers.
            Console.Write("done!\r\n\n");


                foreach (var rNum in lResult)
                {
                    Console.Write(rNum.ToString() + "\t"); // print output to tab delimited console.
                }

                System.Console.WriteLine("\r\n\nWould you like to have generated random numbers saved on a file ? [y / any other key to exit]");

            if (Console.ReadKey(false).Key == ConsoleKey.Y)
            {
                try
                {
                    // within .net 3.5
                    File.WriteAllLines(System.AppDomain.CurrentDomain.FriendlyName + ".csv", lResult.Select(x => x.ToString()).ToArray());
                    Console.WriteLine("\r\nOutput saved to file.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\r\nerror creating output file: " + e.Message);
                }
                finally
                {
                    System.Environment.Exit(0);
                }

            }
            else
            {
                System.Environment.Exit(0);
            }
            
        }
    }
}