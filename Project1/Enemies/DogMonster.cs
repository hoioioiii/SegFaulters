using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
using Project1.Enemies;

namespace Project1
{
	public class DogMonster : UniversalClassEntity
	{
        public override Rectangle BoundingBox => GetPositionAndRectangle();
        //Texture stores the texture alias for our animation
        

        private ISprite sprite;
        private IWeapon weapon;
        private bool ended;
        /*
         * Initalize Dog Monster
         */
        public DogMonster((int, int) position, (String, int)[] items): base(position, items)
        {

            sprite = EnemySpriteFactory.Instance.CreateDogMonsterSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
            weapon = new Boomerange();
            ended = false;
        }
        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, weapon);

        }


        public override void Attack()
        {
            //Check if enemy is currently attacking:

            if (state_manager.IsAttacking())
            {
                int x = movement_manager.getPosition().Item1;
                int y = movement_manager.getPosition().Item2;
                weapon.Update();
                
            }
            else
            {
                PrepareAttack();
                StartAttack();
            }

            //this will fix the issue that im having, figure out hte correct placement to remove the need for this conditional.
            if (!ended)
            {
                EndAttack();
            }
             
            

        }
        private void StartAttack()
        {
            if (state_manager.startNewAttack())
            {
                //create weapons
                direction_state_manager.changeDirection();
                //direction_state_manager.NeedDirectionUpdate(true);
                weapon = new Boomerange();
                state_manager.setNewAttack(false);
            }
            
        }

        private void EndAttack()
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
                ended = true;
                //TODO:remove the item from the active object list
            }
        }

        private void PrepareAttack()
        {
            if (time_manager.checkIfAttackTime())
            {
                state_manager.setIsAttacking(true);
                state_manager.setIsMoving(false);
                state_manager.setNewAttack(true);
            }
        }






        ///*
        // * Update Dog Monster
        // */
        //public void Update()
        //{
        //    sprite.Update();

        //}

        ///*
        // * Draw the Sprite
        // */
        //public void Draw(SpriteBatch spriteBatch)
        //{

        //    sprite.Draw(spriteBatch);
        //}

        ///*
        // * Implement the Health
        // */
        //public void Health()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Implement the Attack
        // */
        //public void Attack()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Item the Sprite drops when it dies.
        // */
        //public void ItemDrop()
        //{
        //    throw new NotImplementedException();
        //}

        //public Rectangle getPositionAndRectangle()
        //{
        //    return sprite.GetRectangle().Item2;

        //}

        //public void setPosition(int x, int y)
        //{
        //    sprite.setPos(x, y);

        //}
    }
}

