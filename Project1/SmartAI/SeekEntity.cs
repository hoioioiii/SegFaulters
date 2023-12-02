using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
using System.Runtime.CompilerServices;

namespace Project1.SmartAI
{
    public class SeekEntity 
    {
        //this can be dino attack

        public static void Move(Vector2 target, IMove move_manager)
        {
            Vector2 user = new Vector2 (move_manager.getPosition().Item1, move_manager.getPosition().Item2);
            Vector2 distanceFromTarget = Vector2.Subtract(target, user);

            int weaponX = move_manager.getPosition().Item1;
            int weaponY = move_manager.getPosition().Item2;

            (int,int) position  = SetNewPosition(distanceFromTarget, weaponX, weaponY);

            move_manager.setPosition(position.Item1,position.Item2);
        }

        private static (int,int) SetNewPosition(Vector2 distanceFromEntity, int weaponX, int weaponY)
        {

            int newX = newPosition(distanceFromEntity.X, weaponX, WEAPON_AGGRO_SPD);
            int newY = newPosition(distanceFromEntity.Y, weaponY, WEAPON_AGGRO_SPD);
            return (newX, newY);
        }

        private static int newPosition(float vectorPos, int weaponPos, int SPD)
        {
            if (Math.Abs(vectorPos) <= CONTACT_POINT) return weaponPos;
            int mod = vectorPos > 0 ? 1 : -1;
            return weaponPos = weaponPos + ((SPD + Random.RandomEntitySPDPositiveOnly()) * mod);
        }
    }
}
