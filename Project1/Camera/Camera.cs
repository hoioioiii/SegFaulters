using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;
using static Project1.Constants;

namespace Project1
{
    public class Camera
    {
        public Matrix Transform { get; set; }

        private float _timer;

        public void Initialize()
        {
            Transform = Matrix.CreateTranslation(0, 0, 0);
            _timer = 0;
        }

        /*
         * Used to test the camera following the player
         */
        /*
        public void Follow(Rectangle target)
        {
            var position = Matrix.CreateTranslation(
                -target.Center.X - (target.Width / 2),
                -target.Center.Y - (target.Height / 2),
                0);

            // TODO: replace with constants!!
            var offset = Matrix.CreateTranslation(
                800 / 2,
                480 / 2,
                0);

            Transform = position * offset;
        }
        */

        /*
         * Calculates the camera transition
         */
        public void RoomTransitionCalculate(DIRECTION direction)
        {
            //var position = Matrix.CreateTranslation(0,0,0);

            switch (direction)
            {
                case DIRECTION.left:
                    Transform = Matrix.CreateTranslation(
                        -800,
                        0,
                        0);
                    break;
                case DIRECTION.right:
                    Transform = Matrix.CreateTranslation(
                        800,
                        0,
                        0);
                    break;
                case DIRECTION.down:
                    Transform = Matrix.CreateTranslation(
                        0,
                        -480,
                        0);
                    break;
                case DIRECTION.up:
                    Transform = Matrix.CreateTranslation(
                        0,
                        480,
                        0);
                    break;
            }

            _timer = 0;
        }

        /*
         * Should be called in update
         */
        private void TransitionRoom(GameTime gametime)
        {
            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (_timer > ROOM_TRANSITION_SPEED)
            {
                _timer = 0;
            }
        }

    }
}
