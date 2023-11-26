using System;
using Microsoft.Xna.Framework;
using static Project1.Constants;
namespace Project1
{
	public static class PlayerMovement
	{
        private static int playerSpeed = 5;

        private static Vector2 position = RESPAWN_UP;

        private static int linkDirection = (int)DIRECTION.right;

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

        public static int getLinkDirection()
        {
            return linkDirection;
        }

        public static void setLinkDirection(int dir)
        {
            linkDirection = dir;
        }

        public static Vector2 getPosition()
        {
            //return position;
            return new Vector2(position.X, position.Y);
        }

        public static void setPosition(Vector2 newPos)
        {
            position = newPos;
        }

        public static void setPositionX(float newValue)
        {
            position.X = newValue;
        }

        public static void setPositionY(float newValue)
        {
            position.Y = newValue;
        }

        public static int getPlayerSpeed()
        {
            return playerSpeed;
        }
    }
}

