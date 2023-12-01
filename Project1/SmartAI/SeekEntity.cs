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

        public static void Move(Vector2 entity, Direction direction, IMove move_manager)
        {

            Vector2 playerVector = Player.getPosition();
            Vector2 distanceFromPlayer = Vector2.Subtract(playerVector, entity);

            int enitityX = move_manager.getPosition().Item1;
            int enitityY = move_manager.getPosition().Item2;

            (int,int) position  = SetNewPosition(distanceFromPlayer, enitityX, enitityY);

            move_manager.setPosition(position.Item1,position.Item2);
        }

        private static (int,int) SetNewPosition(Vector2 distanceFromPlayer, int enitityX,int enitityY)
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
