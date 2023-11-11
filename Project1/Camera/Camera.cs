using System;
using Microsoft.Xna.Framework;
using static Project1.Constants;

namespace Project1
{
    public class Camera
    {
        public Matrix Transform { get; set; }
        private Vector2 positionAdjust;

        private float _timer;

        public void Initialize()
        {
            Transform = Matrix.CreateTranslation(0, 0, 0);
            _timer = 0;
        }

        /*
         * Calculates the camera transition
         */
        public Vector2 RoomTransitionCalculate(DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.left:
                    positionAdjust.X = -800;
                    positionAdjust.Y = 0;
                    break;   
                case DIRECTION.right:
                    positionAdjust.X = 800;
                    positionAdjust.Y = 0;
                    break;   
                case DIRECTION.down:
                    positionAdjust.X = 0;
                    positionAdjust.Y = -480;
                    break;   
                case DIRECTION.up:
                    positionAdjust.X = 0;
                    positionAdjust.Y = 480;                   
                    break;
            }

            _timer = 0;
            
            return positionAdjust;
        }

        /*
         * Should be called in update
         * Smoothly transitions between rooms
         */
        public bool TransitionRoom(GameTime gametime, Vector2 finalPosition)
        {
            Boolean isFinishedTransitioning = false;
            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;

            // If true, room has finished transitioning
            // Else, keep panning the camera
            if (_timer > ROOM_TRANSITION_SPEED)
            {
                _timer = 0;

                isFinishedTransitioning = true;
            }
            else
            {
                Transform = Matrix.CreateTranslation(
                        (_timer / ROOM_TRANSITION_SPEED) * finalPosition.X,
                        (_timer / ROOM_TRANSITION_SPEED) * finalPosition.Y,
                        0);               
            }

            return isFinishedTransitioning;
        }
    }
}
