//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using static Project1.Constants;
//namespace Project1.SmartAI
//{
//    public class RangeDetectionWeapons
//    {

        
//        private RangeTypeToMovement rangeResults;
//        private int radius;

//        public RangeDetectionWeapons((int,int) weaponPosition, int radius)
//        {

//            this.movementManager = movementManager;
//            this.radius = radius;
//        }

//        private double DeterminePositionRelativeToRadius()
//        {
//            int playerX = (int)Player.getPosition().X;
//            int playerY = (int)Player.getPosition().Y;
//            int entityX = movementManager.getPosition().Item1;
//            int entityY = movementManager.getPosition().Item2;

//            return Math.Sqrt(Math.Pow(playerX - entityX, RADIUS_FORMULA_POWER_OF_2) + Math.Pow(playerY - entityY, RADIUS_FORMULA_POWER_OF_2));

//        }
//        public RangeTypeToMovement DetectionField()
//        {
//            double playerPosToEnemy = DeterminePositionRelativeToRadius();

//            return DetermineMovementAction(playerPosToEnemy);
//        }

//        private RangeTypeToMovement DetermineMovementAction(double playerPosToEnemy)
//        {
//            rangeResults = (playerPosToEnemy - radius <= 0) ? RangeTypeToMovement.SEEK : RangeTypeToMovement.PASSIVE;

//            return rangeResults;
//        }

//    }
//}
