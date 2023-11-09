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
using Microsoft.Xna.Framework.Audio;

namespace Project1
{
    public class DogMonster : UniversalClassEntity
    {
        public override Rectangle BoundingBox => GetPositionAndRectangle();
        //Texture stores the texture alias for our animation


        private ISprite sprite;
        private IWeapon[] weapon;
        private bool ended;
        private SoundEffectInstance tempBoomerangSFX;

        /*
         * Initalize Dog Monster
         */
        public DogMonster((int, int) position, (String, int)[] items) : base(position, items)
        {

            sprite = EnemySpriteFactory.Instance.CreateDogMonsterSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
            weapon = new IWeapon[1];
            weapon[0] = new Boomerange();
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
                weapon[0].Update();

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
                weapon[0] = new Boomerange();
                state_manager.setNewAttack(false);
                ended = false;
                Game1.GameObjManager.addNewWeapon(weapon[0]);

                
                tempBoomerangSFX = boomerang.CreateInstance();
                tempBoomerangSFX.IsLooped = true;
                tempBoomerangSFX.Play();
                
            }

        }

        private void EndAttack()
        {
            // means the entity is waiting for the weapon to comeback
            //get weapon obj status of returned/finished) : place holder using state_isAttacking for now
            //get weapon status of "finished" which means we need to be able to get access to the weapon obj
            if (weapon[0].finished())
            {//if weapon is finished and returned to enetity
                state_manager.setIsAttacking(false);
                //set move to true
                state_manager.setIsMoving(true);
                //set isAttacking to false;
                time_manager.enableMoveTime();

                direction_state_manager.getRandomDirection();
                ended = true;
                //TODO:remove the item from the active object list
                Game1.GameObjManager.removeWeapon(weapon[0]);

                tempBoomerangSFX.Stop();
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


    }
}

