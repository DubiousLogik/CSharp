using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles
{
    class ReturnMaxNumber
    {
        //This class returns the max of 2 integers without using if-else, == nor comparisons of any kind

        public static int ReturnMaxInt(int a, int b)
        {
            //d = distance from a to b
            int d = a - b;
            int UnitDistanceVector=0;
            int result;

            try
            {
                UnitDistanceVector =  (d / Math.Abs(d));  //this will fail if they are equal, otherwise will resolve to 1 or -1
            } 
            catch(Exception e) 
            {
                result = a;
            } 

            try
            {
                //this will fail if the UnitDistanceVector is negative, which would mean b is bigger than a
                int[] canary = new int[UnitDistanceVector];
                //if you get here successfully then a is bigger than b
                result = a;
            }
            catch(Exception e)
            {
                //since we are in here then b is bigger than a
                result = b;
            }

            return result;
        }
    }
}
