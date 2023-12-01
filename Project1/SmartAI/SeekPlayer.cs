using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Project1.SmartAI
{
    public class SeekPlayer
    {
        //this can be dino attack

        public static void Move(Vector2 entity, IMove move_manager, SMARTAI_USER type)
        {

            Vector2 playerVector = Player.getPosition();
            Vector2 distanceFromPlayer = Vector2.Subtract(playerVector, entity);

            int userX = move_manager.getPosition().Item1;
            int userY = move_manager.getPosition().Item2;

            (int,int) newPos = MovementDependentOnUser(distanceFromPlayer, userX, userY,type);
            move_manager.setPosition(newPos.Item1, newPos.Item2);
        }

        private static (int,int) MovementDependentOnUser(Vector2 distanceFromPlayer, int userX, int userY, SMARTAI_USER type)
        {
            if (type == SMARTAI_USER.ENTITY)
            {
                return SetNewPosition(distanceFromPlayer, userX, userY);
            }
            else
            {
                return WeaponMovement(distanceFromPlayer, userX, userY);
            }

        }
        private static (int, int) WeaponMovement(Vector2 distanceFromPlayer, int weaponX, int weaponY)
        {
            int newX = newPosition(distanceFromPlayer.X, weaponX, WEAPON_AGGRO_SPD);
            int newY = newPosition(distanceFromPlayer.Y, weaponY, WEAPON_AGGRO_SPD);
            return (newX, newY);
        }

        private static (int, int) SetNewPosition(Vector2 distanceFromPlayer, int enitityX, int enitityY)
        {

            if ((Math.Abs(distanceFromPlayer.X) - Math.Abs(distanceFromPlayer.Y)) > 0)
            {
                enitityX = newPosition(distanceFromPlayer.X, enitityX, AGGRO_SPD);
            }
            else
            {
                enitityY = newPosition(distanceFromPlayer.Y, enitityY, AGGRO_SPD);
            }
            return (enitityX, enitityY);
        }

        private static int newPosition(float vectorPos, int entityPos, int SPD)
        {
            if (Math.Abs(vectorPos) <= CONTACT_POINT) return entityPos;
            int mod = vectorPos > 0 ? 1 : -1;
            return entityPos = entityPos + (SPD * mod);
        }
    }
}
