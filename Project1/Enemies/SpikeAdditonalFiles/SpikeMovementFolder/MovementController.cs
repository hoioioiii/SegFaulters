using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
namespace Project1.Enemies.SpikeAdditonalFiles.SpikeMovementFolder
{
    public class MovementController
    {

        public static void Move(SPIKE_ID id, bool axisX, IMove move_manager,bool returnToOrigin)
        {
            if (axisX) {
                MoveXAxis.Execute(id, move_manager, returnToOrigin);
            }
            else
            {
                MoveYAxis.Execute(id, move_manager, returnToOrigin);
            }
        }

    }
}
