using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //Provides grid system details using the methods
    public static class GridSystem
    {
        //static variables
        //<(int row, int col), int pos>
        private static Dictionary<(int, int), int> pixelDictionary;
        private static int rowCount;
        private static int colCount;

        static GridSystem()
        {
            for (int row = 1; row <= rowCount; row++)
            {
                for(int col = 1; col <= colCount; col++)
                {
                    // assign pixel positions to pixelDictionary
                }
            }
        }
       
        
    }
}
