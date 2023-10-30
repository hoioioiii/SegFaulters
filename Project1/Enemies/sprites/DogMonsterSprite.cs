using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class DogMonsterSprite : ISprite
    {
        private List<Texture2D[]> Texture;

        public static bool newAttack;
        private IDirectionStateManager direction_state_manager;
        private IAnimation animation_manager;
        private ITime time_manager;
        private IMove movement_manager;

        private (Rectangle, Rectangle) rectangles;
        private IEntityState state_manager;

        private IWeapon weapon;

        public DogMonsterSprite(List<Texture2D[]> spriteSheet, (int, int) position, (String, int)[] items)
        {
            newAttack = true;

            Texture = spriteSheet;

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionStateEnemy(Direction.Down);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, spriteSheet, time_manager, direction_state_manager);
            state_manager = new EntityState();
            //PARM VALUES WILL CHANGE BASED ON ROOM LOADER
            movement_manager = new Movement(direction_state_manager, this, time_manager, position.Item1, position.Item2, 0);
        }

        /*
         * Update Boss's animation and movement
         */
        public void Update()
        {
            if (state_manager.IsAlive())
            {
                AttackUpdate();
                Move();
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

        public void AttackUpdate()
        {
            //Check if enemy is currently attacking:

            if (state_manager.IsAttacking())
            {
                int x = movement_manager.getPosition().Item1;
                int y = movement_manager.getPosition().Item2;

                if (weapon!= null) //REMOVE LATER
                {
                    weapon.Update();
                }
                
            }
            else
            {
                if (time_manager.checkIfAttackTime())
                {
                    state_manager.setIsAttacking(true);
                    state_manager.setIsMoving(false);
                    state_manager.setNewAttack(true);
                }
            }
        }

        private void EntityAttackAction()
        {
            //we can assume that we are here bc it is attacking
            //Boomerange
            //check if we need to start a new attack

            if (state_manager.startNewAttack())
            {
                //create weapons
                direction_state_manager.changeDirection();
                //direction_state_manager.NeedDirectionUpdate(true);
                weapon = new Boomerange();
                state_manager.setNewAttack(false);

                //TODO:add item to active object list
                Game1.GameObjManager.addNewWeapon(weapon);
            }
            else
            {
                // means the entity is waiting for the weapon to comeback
                //get weapon obj status of returned/finished) : place holder using state_isAttacking for now
                //get weapon status of "finished" which means we need to be able to get access to the weapon obj
                if (weapon.finished())
                {//if weapon is finished and returned to enetity
                    state_manager.setIsAttacking(false);
                    //set move to true
                    state_manager.setIsMoving(true);
                    //set isAttacking to false;
                    time_manager.enableMoveTime();
                    direction_state_manager.getRandomDirection();
                    //TODO:remove the item from the active object list
                    Game1.GameObjManager.removeWeapon(weapon);
                }
                else
                {
                    weapon.Attack(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, direction_state_manager.getDirection());
                    weapon.Draw();
                }
            }
        }


        /*
         * Move the boss
         */
        public void Move()
        {
            if (state_manager.isMoving())
            {
                //Movement will be fixed
                movement_manager.WanderMove();
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
                if (state_manager.IsAttacking()) EntityAttackAction();
            }
        }


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




////Factor out into Manager manager
//public void ChangeDirectionX()
//{
//    this.Direction = Direction * -1;
//    if (WalkLeft)
//    {
//        WalkLeft = false;
//        START_FRAME = 4;
//        total_frame = 6;
//    }
//    else
//    {
//        WalkLeft = true;
//        START_FRAME = 6;
//        total_frame = 8;
//    }

//    current_frame = START_FRAME;
//}

////Factor out into Direction Manager
//public void ChangeDirectionY()
//{
//    this.Direction = Direction * -1;
//    if (WalkDown)
//    {
//        WalkDown = false;
//        START_FRAME = UP_DIRECTION_SPRITE;
//        total_frame = 4;
//    }
//    else
//    {
//        WalkDown = true;
//        START_FRAME = DOWN_DIRECTION_SPRITE;
//        total_frame = 2;
//    }

//    current_frame = START_FRAME;
//}