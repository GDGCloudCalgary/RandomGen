using System;
using System.Collections.Generic;

namespace RandomListGen
{
    public class RandomList
    {
        public RandomList()
        {

        }



        /// <summary>
        /// Produce total of iTotalNum random list of integer numbers between iMinValue and iMaxValue
        /// <para>NOTE:  iTotalNum must be greater than iMaxValue - iMinValue</para>
        /// <para>iMinValue: The inclusive lower bound</para>
        /// <para>iMaxValue: The inclusive upper bound</para>
        /// <para>iTotalNum: Total numbers to be generated</para>
        /// </summary>
        /// <param name="iMinValue"></param>
        /// <param name="iMaxValue"></param>
        /// <param name="iTotalNum"></param>
        /// <returns></returns>
        public List<int> Generate(int iMinValue, int iMaxValue, int iTotalNum)
        {
            // The ´HashSet´ is faster for lookup than list lookup, however it doesn't  
            // preserve the order of the items, we still need the List though
            HashSet<int> hCheck = new HashSet<int>();   
            List<int> lSeries = new List<int>();    // List of int, which holds ultimate generated random numbers.

            Random rand = new Random();

            while (lSeries.Count < iTotalNum)
            {
                int curValue = rand.Next(iMinValue, iMaxValue);
                while (hCheck.Contains(curValue))
                {
                    // check to see if current generated number is unique

                    // A 32-bit signed integer greater than or equal to minValue and less than maxValue; 
                    // that is, the range of return values includes minValue but not maxValue. 
                    // adding 1 to maxValue to meet objective of inclusive of 1 and 10000
                    curValue = rand.Next(iMinValue, iMaxValue + 1);
                }
                lSeries.Add(curValue);
                hCheck.Add(curValue);
            }

            return lSeries;
        }
    }
}
