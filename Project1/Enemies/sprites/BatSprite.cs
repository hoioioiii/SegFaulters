using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1.Enemies.sprites
{
    public class BatSprite : ISprite
    {

        //Gets the sprite frames: CHANGE LATER
        private Texture2D[] Texture;

        //Sprite position
        private int pos_x;
        private int pos_y;

        //Width and Height of sprite frames:change later
        private int width;
        private int height;

       
        private IDirectionStateManager direction_state_manager;
        private IAnimation animation_manager;
        private ITime time_manager;

        private (Rectangle, Rectangle) rectangles;

        public BatSprite(Texture2D[] spriteSheet)
        {
            Texture = spriteSheet;

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0,BAT_TOTAL,time_manager,direction_state_manager);

            //this will be given by the room manager
            setPos(SPRITE_X_START, SPRITE_Y_START);

            //factor out later
            width = Texture[animation_manager.getCurrentFrame()].Width;
            height = Texture[animation_manager.getCurrentFrame()].Height;
        }

        public void Update()
        {
            Move();
            UpdateFrames();
        }

        public void UpdateFrames()
        {
            animation_manager.Animate();
        }

        public void Move()
        {
           //testing purposes-> remove later
           // Movement.VerticalMovement(direction_state_manager,this, Direction.Up);
            Movement.HorizontalMovement(direction_state_manager, this, Direction.Left);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            setRectangles();
            spriteBatch.Draw(Texture[animation_manager.getCurrentFrame()], rectangles.Item2, rectangles.Item1, Color.White);
        }

        public void setPos(int x, int y)
        {
            pos_x = x; pos_y = y;
        }

        public (int,int) getPos() {
            return (pos_x, pos_y);
        }

        public void setRectangles()
        {
            rectangles.Item1 = new Rectangle(1, 1, width, height);
            rectangles.Item2 = new Rectangle(pos_x, pos_y, width, height);

        }

        public (Rectangle,Rectangle) GetRectangle()
        {
            return rectangles;
        }
    }
}

