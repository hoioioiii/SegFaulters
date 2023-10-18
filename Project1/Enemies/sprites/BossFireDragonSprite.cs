using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class BossFireDragonSprite : ISprite
    {


        private Texture2D[] Texture;

        public static bool newAttack;
        private IDirectionStateManager direction_state_manager;
        private IAnimation animation_manager;
        private ITime time_manager;
        private IMove movement_manager;

        private (Rectangle, Rectangle) rectangles;

        public BossFireDragonSprite(Texture2D[] spriteSheet)
        {

            newAttack = true;

            Texture = spriteSheet;

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, FD_TOTAL, time_manager, direction_state_manager);


            //PARM VALUES WILL CHANGE BASED ON ROOM LOADER
            movement_manager = new Movement(direction_state_manager, this, time_manager, SPRITE_X_START, SPRITE_Y_START, 0);


        }

        /*
         * Update Boss's animation and movement
         */
        public void Update()
        {
            Move();
            UpdateFrames();

        }

        /*
         * Update Boss's frames
         */
        public void UpdateFrames()
        {
            animation_manager.Animate();
        }


        /*
         * Move the boss
         */
        public void Move()
        {
            //Movement will be fixed
            //Movement.HorizontalMovement(direction_state_manager, this, Direction.Right);
        }

        /*
         * Draw the Boss
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            setRectangles();
            spriteBatch.Draw(Texture[animation_manager.getCurrentFrame()], rectangles.Item2, rectangles.Item1, Color.White);
        }

        public void setRectangles()
        {
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;
            int height = Texture[animation_manager.getCurrentFrame()].Height;
            int width = Texture[animation_manager.getCurrentFrame()].Width;
            rectangles.Item1 = new Rectangle(1, 1, width, height);
            rectangles.Item2 = new Rectangle(x, y, width, height);
        }


        public void setPos(int x, int y)
        {
            movement_manager.setPosition(x, y);
        }

        public (int, int) getPos()
        {
            return movement_manager.getPosition();
        }

        public (Rectangle, Rectangle) GetRectangle()
        {
            return rectangles;
        }

        public Direction getDirection()
        {
            return direction_state_manager.getDirection();
        }

    }
}



//public void ChangeDirection()
//{

//    this.Direction = Direction * -1;
//}

///*
// * Moves dragon
// */
//public void Move()
//{
//    if (secondsPassed >= secTillDirChange)
//    {
//        elapsedTime -= msecPerFrame;
//        ChangeDirection();
//        secondsPassed = 0;
//    }

//    pos_x += Direction;

//    if (pos_x >= SCREEN_WIDTH_UPPER || pos_x <= SCREEN_WIDTH_LOWER)
//    {
//        ChangeDirection();
//    }

//}