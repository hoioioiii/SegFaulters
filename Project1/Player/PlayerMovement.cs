using System;
using Microsoft.Xna.Framework;
using static Project1.Constants;
namespace Project1
{
	public static class PlayerMovement
	{
        public static int playerSpeed = 5;

        public static Vector2 position = RESPAWN_UP;

        public static int linkDirection = (int)DIRECTION.right;

        public static void left()
        {
            position.X -= playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
            Player.isMoving = true;
            linkDirection = (int)DIRECTION.left;

        }

        public static void down()
        {
            position.Y += playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
            Player.isMoving = true;
            linkDirection = (int)DIRECTION.down;
        }

        public static void up()
        {
            position.Y -= playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
            Player.isMoving = true;
            linkDirection = (int)DIRECTION.up;

        }

        public static void right()
        {
            position.X += playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
            Player.isMoving = true;
            linkDirection = (int)DIRECTION.right;

        }
    }
}

