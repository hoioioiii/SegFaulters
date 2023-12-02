using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static Project1.Constants;

namespace Project1.SmartAI
{
    public class SeekPlayerOnOneAxis
    {
        public static void Move(Vector2 user, IMove move_manager, bool xAxis,Vector2 targetPos)
        {
            Vector2 playerVector = targetPos;
            if (targetPos.X == 0 || targetPos.Y == 0)
            {
                playerVector = Player.getPosition();
            }
            
            Vector2 distanceFromPlayer = Vector2.Subtract(playerVector, user);

            int userX = move_manager.getPosition().Item1;
            int userY = move_manager.getPosition().Item2;

            
            (int, int) newPos = FollowOnOneAxis(xAxis, distanceFromPlayer, userX, userY);
            move_manager.setPosition(newPos.Item1, newPos.Item2);
        }

        private static (int, int) FollowOnOneAxis(bool xAxis, Vector2 distanceFromPlayer, int enitityX, int enitityY)
        {

            if (xAxis && (Math.Abs(distanceFromPlayer.X)) > 0)
            {
                enitityX = newPositionOneAxis(distanceFromPlayer.X, enitityX, AGGRO_SPD);
            }
            else if (!xAxis && (Math.Abs(distanceFromPlayer.Y)) > 0)
            {
                enitityY = newPositionOneAxis(distanceFromPlayer.Y, enitityY, AGGRO_SPD);
            }

            return (enitityX, enitityY);
        }
        private static int newPositionOneAxis(float vectorPos, int entityPos, int SPD)
        {
            if (Math.Abs(vectorPos) <= CONTACT_POINT) return entityPos;
            int mod = vectorPos > 0 ? 1 : -1;
            return entityPos = entityPos + (SPD * mod);
        }


    }
}
