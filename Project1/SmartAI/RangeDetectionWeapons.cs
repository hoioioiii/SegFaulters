using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static Project1.Constants;
namespace Project1.SmartAI
{
    public class RangeDetectionWeapons
    {

        private IMove movementManager;
        private RangeTypeToMovement rangeResults;
        private int size;
        private Rectangle DetectionRec;
        public RangeDetectionWeapons(IMove movementManager, int radius)
        {

            this.movementManager = movementManager;
            this.size = radius * radius;
        }

        public void Update()
        {
           
            DetectionRec = new Rectangle(movementManager.getPosition().Item1, movementManager.getPosition().Item2, size, size);
        }

        public RangeTypeToMovement DetectionField(bool detected)
        {
            
            return DetermineMovementAction(detected);
        }

        private RangeTypeToMovement DetermineMovementAction(bool detected)
        {
            rangeResults = (detected) ? RangeTypeToMovement.SEEK : RangeTypeToMovement.PASSIVE;

            return rangeResults;
        }

    }
}
