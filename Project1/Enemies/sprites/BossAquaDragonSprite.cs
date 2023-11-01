using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class BossAquaDragonSprite : ISprite
    {
        private List<Texture2D[]> Texture;



        private IMove movement_manager;
        private IDirectionStateManager direction_state_manager;
        private IAnimation animation_manager;
        private ITime time_manager;
        private IEntityState state_manager;
        private (String, int)[] drops;

        private (Rectangle, Rectangle) rectangles;
        /*
         * Initalize Boss Aqua Dragon
         */
        public BossAquaDragonSprite(List<Texture2D[]> spriteSheet, (int, int) position, (String, int)[] items)
        {
            Texture = spriteSheet;

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, spriteSheet, time_manager, direction_state_manager);
            state_manager = new EntityState();

            //PARM VALUES WILL CHANGE BASED ON ROOM LOADER
            movement_manager = new Movement(direction_state_manager, this, time_manager, position.Item1, position.Item2, 0);
            drops = items;

        }

        /*
         * Update Boss's animation and movement
         */
        public void Update()
        {
            //change .IS alive to {get;private set}
            if (state_manager.IsAlive())
            {
                Move();
            }
            else if (!state_manager.finished && !state_manager.IsAlive())
            {
                ItemDrop();
            }
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
            if (state_manager.isMoving()) 
            {
                //Movement will be fixed
                movement_manager.HorizontalMovement(Direction.Left);
            }
        }

        /*
         * Draw the Boss
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(animation_manager.sprite_frame, rectangles.Item2, rectangles.Item1, Color.White);

            }
        }
        
        
        public void setRectangles()
        {
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;
            int height = animation_manager.sprite_frame.Height;
            int width = animation_manager.sprite_frame.Width;
            rectangles.Item1 = new Rectangle(1, 1, width , height);
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

        public void ItemDrop()
        {
            //create new item
            foreach ((String, int) itemType in drops){
                CreateNumItem(itemType);
            }
            state_manager.SetFinished();
        }

        public void CreateNumItem((String,int) item)
        {
            for (int i = 0; i < item.Item2; i++)
            {
                int x = movement_manager.getPosition().Item1;
                int y = movement_manager.getPosition().Item2;
                ItemLoader.initItems(item.Item1, (x, y));
            }
        }
    }
}

