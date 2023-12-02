using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project1.SmartAI;
using static Project1.Constants;
namespace Project1.Enemies.SpikeAdditonalFiles.SpikeMovementFolder
{
    public class MoveXAxis
    {

        public static void Execute(SPIKE_ID id, IMove move_manager, bool returnToOrigin) {

            (int,int) pos = returnToOrigin ? AxisBoundaryMaps.GetSpikeLocalPosition(id): (roomBoundsMaxX/DOUBLE,0);
            

            if (id == SPIKE_ID.TOP_LEFT || id == SPIKE_ID.BOTTOM_LEFT)
            {
                int endingPos = (roomBoundsMinX +  (pos.Item1));
                Move(pos, move_manager);
               CheckBounds(move_manager, roomBoundsMinX,endingPos);
            }
            else
            {
                int endingPos = (AxisBoundaryMaps.GetSpikeLocalPosition(id).Item1 + SPIKE_WIDTH * DOUBLE) - (pos.Item1);
                Move(pos, move_manager);
                CheckBounds(move_manager,endingPos,roomBoundsMaxX);
            }


        }

        private static void Move((int, int) endingPosition, IMove move_manager)
        {
            int x = move_manager.getPosition().Item1;
            Vector2 target = new Vector2(endingPosition.Item1, endingPosition.Item2);
            SeekPlayerOnOneAxis.Move(new Vector2 (x, move_manager.getPosition().Item2), move_manager,true,target);
            
        }
        private static void CheckBounds(IMove move_manager, int lowerBound, int upperBound)
        {
            int endingX = (Math.Clamp(move_manager.getPosition().Item1, lowerBound, upperBound));
            move_manager.setPosition(endingX, move_manager.getPosition().Item2);
        }

    }
}
