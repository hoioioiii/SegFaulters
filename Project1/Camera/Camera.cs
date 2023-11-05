using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static Project1.Constants;

namespace Project1
{
    public class Camera
    {
        public Matrix Transform { get; set; }

        public void RoomTransitionCamera(Vector2 camPos, DIRECTION direction)
        {
            //var position = Matrix.CreateTranslation(0,0,0);

            switch (direction)
            {
                case DIRECTION.left:
                    Transform = Matrix.CreateTranslation(
                        -SCREEN_WIDTH_UPPER,
                        0,
                        0);
                    break;
                case DIRECTION.right:
                    Transform = Matrix.CreateTranslation(
                        SCREEN_WIDTH_UPPER,
                        0,
                        0);
                    break;
                case DIRECTION.down:
                    Transform = Matrix.CreateTranslation(
                        0,
                        -SCREEN_HEIGHT_UPPER,
                        0);
                    break;
                case DIRECTION.up:
                    Transform = Matrix.CreateTranslation(
                        0,
                        SCREEN_HEIGHT_UPPER,
                        0);
                    break;
            }
            
            /*
            var offset = Matrix.CreateTranslation(
                SCREEN_WIDTH_UPPER / 2,
                SCREEN_HEIGHT_UPPER / 2,
                0);
            */

            //Transform = position * offset;
        }
    }
}
