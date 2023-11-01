using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class DogMonsterSprite : UniversalClassEntity
    {
        
        public static bool newAttack;
        private IWeapon weapon;

        public DogMonsterSprite(List<Texture2D[]> spriteSheet, (int, int) position, (String, int)[] items): base(spriteSheet, position, items)
        {
            newAttack = true;
            weapon = new Boomerange();
        }

        
        public override void Attack()
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

        public override void DrawAttack()
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
                }
                else
                {
                    weapon.Attack(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, direction_state_manager.getDirection());
                    weapon.Draw();
                }
            }
        }


        
    }
}




