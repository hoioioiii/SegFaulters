using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
using System.Collections.Generic;

namespace Project1.Enemies
{
    public class UniversalClassEntity :IEntity
    {
        public virtual Rectangle BoundingBox => throw new NotImplementedException();
        public IDirectionStateManager direction_state_manager;
        public IAnimation animation_manager;
        public ITime time_manager;
        public IMove movement_manager;
        public IEntityState state_manager;

        private (Rectangle, Rectangle) rectangles;

        //Rectangle IEntity.BoundingBox => throw new NotImplementedException();


        //testing death and item drop->remove later
        private int elaspedTime;

        public UniversalClassEntity((int, int) position, (string, int)[] items)
        {
            
            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, time_manager, direction_state_manager);
            state_manager = new EntityState();
            movement_manager = new Movement(direction_state_manager, this, time_manager, position.Item1, position.Item2, 0);

        }

    

        public void Update()
        {
            testDeath();
            if (state_manager.IsAlive())
            {
                Attack();
                Move();

            }
            else if (!state_manager.finished)
            {
                ItemDrop();
            }
            UpdateFrames();
        }

        public virtual void Attack()
        {
            //Check if enemy is currently attacking:

            //No:
            //We need to check the attack timer to see if we need to attack now
            //Set isAttack to true
            //set isMoving to false

            //this is going to be for collision damage attack i think
        }
        public void UpdateFrames()
        {
            if (state_manager.IsAlive())
            {
                //sprite.animationManager
                animation_manager.Animate();
            }
            else
            {
                //Do Item Drop
            }
        }

        
        public void Move()
        {
            if (state_manager.isMoving())
            {
                //Movement.WanderMove(direction_state_manager, this, time_manager);
                MovementType();
            }

        }

        public virtual void MovementType()
        {
            movement_manager.WanderMove();
        }

        ////Keep in Sprite
        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    if (state_manager.IsAlive())
        //    {
        //        setRectangles();
        //        spriteBatch.Draw(animation_manager.sprite_frame, rectangles.Item2, rectangles.Item1, Color.White);
        //        if (state_manager.IsAttacking()) DrawAttack();
        //    }
        //}

        ////Keep in Sprite
        //public virtual void DrawAttack()
        //{
        //    //null have each enemy implement their own
           
        //}


        /// <summary>
        //Keep in sprite
        /// </summary>
        //public void setRectangles()
        //{
        //    int x = movement_manager.getPosition().Item1;
        //    int y = movement_manager.getPosition().Item2;
        //    int height = animation_manager.sprite_frame.Height;
        //    int width = animation_manager.sprite_frame.Width;
        //    rectangles.Item1 = new Rectangle(1, 1, width, height);
        //    rectangles.Item2 = new Rectangle(x, y, width, height);
        //}

        public void setPosition(int x, int y)
        {
            movement_manager.setPosition(x, y);
        }

        public (int, int) getPos()
        {
            return movement_manager.getPosition();
        }

        //public virtual (Rectangle, Rectangle) GetRectangle()
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public virtual Rectangle GetPositionAndRectangle() { throw new NotImplementedException(); }

        public void ItemDrop()
        {

            System.Diagnostics.Debug.WriteLine("in item drop: ");
            //create new item

            //this is for testing purposes
            CreateNumItem(("fairy", 1));

            //this is actual--------------------------
            //foreach ((String, int) itemType in drops)
            //{
            //    CreateNumItem(itemType);
            //}
            state_manager.SetFinished();
        }


        public void CreateNumItem((String, int) item)
        {

            for (int i = 0; i < item.Item2; i++)
            {
                int x = movement_manager.getPosition().Item1;
                int y = movement_manager.getPosition().Item2;
                ItemLoader.LoadAndInitializeItems(item.Item1, (x, y), Game1.GameObjManager);
            }

        }

        //this is only for testing purposes
        private void testDeath()
        {
            elaspedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

            if (elaspedTime >= 500)
            {
                state_manager.setIsAlive(false);
            }
        }
    }
}
