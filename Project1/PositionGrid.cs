using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    internal static class PositionGrid
    {
        private static Dictionary<(int, int), (int, int)> gridDict;
        
        public static (int, int) getPosBasedOnGrid(int x, int y)
        {
            return gridDict.GetValueOrDefault((x, y));
        }

        public static void createMap()
        {
            gridDict = new Dictionary<(int, int), (int, int)>(); //<(row, col), (posX, posY)>
            //load in blockPositionDictionary 7 rows x 12 columns
            for (int row = 0; row < 7; row++) //per 7 rows
            {
                for (int col = 0; col < 12; col++) //12 columns
                {
                    //114, 75 is the starting point of the grid
                    //48 is the width/height of each block
                    gridDict.Add((row, col), (112 + FRAME_BUFFER_X + BLOCK_DIMENSION * (col), 73 + FRAME_BUFFER_Y + BLOCK_DIMENSION * (row)));
                }
            }
        }
        
        public static void Update()
        {
            createMap();
        }

    }
}
