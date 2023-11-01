﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
using System.Collections.Generic;

namespace Project1.Enemies
{
    public class UniversalClassEntity :ISprite
    {

        public IDirectionStateManager direction_state_manager;
        public IAnimation animation_manager;
        public ITime time_manager;
        public IMove movement_manager;
        public IEntityState state_manager;

        private (Rectangle, Rectangle) rectangles;

        public UniversalClassEntity(List<Texture2D[]> spriteSheet, (int, int) position, (string, int)[] items)
        {
            

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, spriteSheet, time_manager, direction_state_manager);
            state_manager = new EntityState();

            movement_manager = new Movement(direction_state_manager, this, time_manager, position.Item1, position.Item2, 0);

        }

        public void Update()
        {
            if (state_manager.IsAlive())
            {
                Attack();
                Move();
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

        //Keep in Sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(animation_manager.sprite_frame, rectangles.Item2, rectangles.Item1, Color.White);
                if (state_manager.IsAttacking()) DrawAttack();
            }
        }

        //Keep in Sprite
        public virtual void DrawAttack()
        {
            //null have each enemy implement their own
           
        }


        /// <summary>
        //Keep in sprite
        /// </summary>
        public void setRectangles()
        {
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;
            int height = animation_manager.sprite_frame.Height;
            int width = animation_manager.sprite_frame.Width;
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
    }
}
