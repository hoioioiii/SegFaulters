using System;
using Microsoft.Xna.Framework;
using Project1.HUD;
using static Project1.Constants;

namespace Project1
{
    public static class Camera
    {
        public static Matrix Transform { get; set; }
        private static Vector2 positionAdjust;

        private static float _timer;

        public static void Initialize()
        {
            Transform = Matrix.CreateTranslation(0, 0, 0);
            _timer = 0;

            positionAdjust = new Vector2(0,0);
        }

        /*
         * Calculates the camera transition
         */
        public static void CameraTransitionCalculate(DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.left:
                    positionAdjust.X = ROOM_FRAME_WIDTH;
                    positionAdjust.Y = 0;
                    break;
                case DIRECTION.right:
                    positionAdjust.X = -ROOM_FRAME_WIDTH;
                    positionAdjust.Y = 0;
                    break;
                case DIRECTION.down:
                    positionAdjust.X = 0;
                    positionAdjust.Y = -ROOM_FRAME_HEIGHT;
                    break;
                case DIRECTION.up:
                    positionAdjust.X = 0;
                    positionAdjust.Y = ROOM_FRAME_HEIGHT;
                    break;
            }

            _timer = 0;    
        }

        /*
         * Should be called in update
         * Smoothly transitions between rooms
         * Boolean differentiates room and HUD transitions
         */
        public static bool CameraTransition(GameTime gametime, bool isRoomTransition)
        {
            Boolean isFinishedTransitioning = false;
            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;

            // If true, room has finished transitioning
            // Else keep panning the camera
            if (_timer > CAMERA_TRANSITION_SECONDS)
            {
                _timer = 0;
                isFinishedTransitioning = true;

                if (isRoomTransition) 
                { 
                    RoomTransition.EndScrolling();
                }
                else
                {
                    HeadsUpDisplay.EndScrolling();
                }               
            }
            else
            {
                Transform = Matrix.CreateTranslation(
                        (_timer / CAMERA_TRANSITION_SECONDS) * positionAdjust.X,
                        (_timer / CAMERA_TRANSITION_SECONDS) * positionAdjust.Y,
                        0);
            }

            return isFinishedTransitioning;
        }
    }
}
