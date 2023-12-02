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
    public class MoveYAxis
    {

        public static void Execute(SPIKE_ID id, IMove move_manager, bool returnToOrigin) {

            
            (int,int) pos = returnToOrigin ? AxisBoundaryMaps.GetSpikeLocalPosition(id): (0,Math.Abs(roomBoundsMaxY-roomBoundsMinY)/DOUBLE);
           

            if (id == SPIKE_ID.TOP_LEFT || id == SPIKE_ID.TOP_RIGHT)
            {
               Move(pos, move_manager);
               CheckBounds(move_manager, roomBoundsMinY, (roomBoundsMinY + pos.Item2));
            }
            else
            {
                int endingPos = (roomBoundsMaxY - pos.Item2);
                Move(pos, move_manager);
                CheckBounds(move_manager, endingPos, roomBoundsMaxY);
            }
        }

        private static void Move((int, int) endingPosition, IMove move_manager)
        {
            Vector2 target = new Vector2 (endingPosition.Item1,endingPosition.Item2);
            int y = move_manager.getPosition().Item2;
            SeekPlayerOnOneAxis.Move(new Vector2 ( move_manager.getPosition().Item1,y), move_manager,false, target);
            
        }
        private static void CheckBounds(IMove move_manager, int lowerBound, int upperBound)
        {
            int endingY = (Math.Clamp(move_manager.getPosition().Item2,lowerBound , upperBound));
            move_manager.setPosition(move_manager.getPosition().Item1, endingY);
        }

    }
}
