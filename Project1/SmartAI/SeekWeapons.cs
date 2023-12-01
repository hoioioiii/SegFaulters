//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using System.Text;
//using System.Threading.Tasks;
//using static Project1.Constants;
//using System.Runtime.CompilerServices;

//namespace Project1.SmartAI
//{
//    public class SeekWeapons
//    {
//        //this can be dino attack

//        public static void Move(Vector2 weapon, Direction direction, IMove move_manager)
//        {
//            Vector2 playerVector = Player.getPosition();
//            Vector2 distanceToPlayer = Vector2.Subtract(playerVector, weapon);

//            int weaponX = move_manager.getPosition().Item1;
//            int weaponY = move_manager.getPosition().Item2;

//            //check if we want diagonal movement
//            (int, int) newPos = weaponMovement(distanceToWeapon, weaponX, weaponY);
//            move_manager.setPosition(newPos.Item1, newPos.Item2);
//        }

//        private static (int,int) weaponMovement(Vector2 distanceToPlayer,int weaponX,int weaponY)
//        {
//            int newX = newPosition(distanceToPlayer.X, weaponX, WEAPON_AGGRO_SPD);
//            int  newY= newPosition(distanceToPlayer.Y, weaponY, WEAPON_AGGRO_SPD);
//            return (newX,newY);
//        }

//        private static int newPosition(float vectorPos, int entityPos, int factor)
//        {
//            if (Math.Abs(vectorPos) <= CONTACT_POINT) return entityPos;
//            int mod = vectorPos > 0 ? 1 : -1;
//            return entityPos = entityPos + (factor * mod);
//        }





//    }
//}
