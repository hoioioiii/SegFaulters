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


        //Width and Height of sprite frames:change later
        private int width;
        private int height;

      
        private IDirectionStateManager direction_state_manager;
        private IAnimation animation_manager;
        private ITime time_manager;
        private IMove movement_manager;
        private IEntityState state_manager;

        private (Rectangle, Rectangle) rectangles;

        public BatSprite(Texture2D[] spriteSheet, (int, int)position, (String, int) items)
        {
            Texture = spriteSheet;

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0,BAT_TOTAL,time_manager,direction_state_manager);
            state_manager = new EntityState();


            //PARM VALUES WILL CHANGE BASED ON ROOM LOADER
            movement_manager = new Movement(direction_state_manager,this,time_manager, position.Item1, position.Item2,0);
            
            //factor out later
            width = Texture[animation_manager.getCurrentFrame()].Width;
            height = Texture[animation_manager.getCurrentFrame()].Height;
           
        }

        public void Update()
        {
            if (state_manager.IsAlive()) {
                Attack();
                Move();
            }

            UpdateFrames();
        }

        public void Attack()
        {
            //Check if enemy is currently attacking:

            //No:
            //We need to check the attack timer to see if we need to attack now
            //Set isAttack to true
            //set isMoving to false
        }
        public void UpdateFrames()
        {
            if (state_manager.IsAlive()) {
                animation_manager.Animate();
            }
            else
            {
                //Do Item Drop
            }
        }

        public void Move()
        {
            if(state_manager.isMoving()) {
                //Movement.WanderMove(direction_state_manager, this, time_manager);
                movement_manager.circularMovement(Direction.Up);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(Texture[animation_manager.getCurrentFrame()], rectangles.Item2, rectangles.Item1, Color.White);
            }

        }

        public void setPos(int x, int y)
        {
            movement_manager.setPosition(x, y);
        }

        public (int,int) getPos() {
            return movement_manager.getPosition();
        }

        public void setRectangles()
        {
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;
            rectangles.Item1 = new Rectangle(1, 1, width, height);
            rectangles.Item2 = new Rectangle(x, y, width, height);
        }

        public (Rectangle,Rectangle) GetRectangle()
        {
            return rectangles;
        }
    }
}

