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
	public class BossFireDragon : UniversalClassEntity
	{
       
        public override Rectangle BoundingBox => GetPositionAndRectangle();

        private IWeapon weaponTop;
        private IWeapon weaponMiddle;
        private IWeapon weaponBottom;
        private bool ended;


        //May or may not keep
        private int timeAllowed;
        private ISprite sprite;
        private bool remainOnScreen;
        private int onScreen;
        private int lastDragonSoundPlayed;

        /*
         * Initalize fire drag
         */
        public BossFireDragon((int, int) position, (String, int)[] items): base(position, items)
        {
            timeAllowed = 1000;
            onScreen = 0;
            remainOnScreen = false;
            
            sprite = EnemySpriteFactory.Instance.CreateFireDragonSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);

            weaponTop = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
            weaponMiddle = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
            weaponBottom = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);

            lastDragonSoundPlayed = 1;
        }
        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }

        private void UpdateWeapons()
        {
            weaponTop.Update();
            weaponMiddle.Update();
            weaponBottom.Update();
        }

        public override void Attack()
        {

            if (state_manager.IsAttacking())
            {
                int x = movement_manager.getPosition().Item1;
                int y = movement_manager.getPosition().Item2;             

                UpdateWeapons();
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
           // weapon = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);


        }


        private void StartAttack()
        {
            if (state_manager.startNewAttack())
            {
                #region playSound
                switch (lastDragonSoundPlayed)
                {
                    case 1:
                        AudioManager.PlaySoundEffect(dragon);
                        lastDragonSoundPlayed = 2;
                        break;
                    case 2:
                        AudioManager.PlaySoundEffect(dragon2);
                        lastDragonSoundPlayed = 3;
                        break;
                    case 3:
                        AudioManager.PlaySoundEffect(dragon3);
                        lastDragonSoundPlayed = 1;
                        break;
                    default:
                        AudioManager.PlaySoundEffect(dragon);
                        break;
                }             
                #endregion

                //direction_state_manager.NeedDirectionUpdate(true);
                weaponTop = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
                weaponMiddle = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
                weaponBottom = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
                state_manager.setNewAttack(false);
                time_manager.enableMoveTime();
            }

        }

        private bool CheckFinish()
        {
            if (weaponTop.finished() && weaponMiddle.finished() && weaponBottom.finished())
                return true;
           

            return false;
        }

        private void EndAttack()
        {
            // means the entity is waiting for the weapon to comeback
            //get weapon obj status of returned/finished) : place holder using state_isAttacking for now
            //get weapon status of "finished" which means we need to be able to get access to the weapon obj
            if (CheckFinish())
            {//if weapon is finished and returned to enetity
                state_manager.setIsAttacking(false);
                //set move to true
                state_manager.setIsMoving(true);
               
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
        // * Update Sprite
        // */
        //public void Update()
        //{
        //    sprite.Update();

        //   //May or may not keep
        //    if (remainOnScreen)
        //    {
        //        weapon.Update();
        //    }
        //}

        //public void Draw(SpriteBatch spriteBatch)
        //{

        //    sprite.Draw(spriteBatch);


        //    //Optomize this-----
        //    Attack();

        //    CheckOnScreen();

        //    if (remainOnScreen)
        //    {
        //        weapon.Draw();
        //    }
        //    else
        //    {
        //        onScreen = 0;
        //        remainOnScreen = false;
        //    }
        //    //optomize this later------

        //}

        ////May or may not keep
        //public void CheckTime()
        //{
        //    onScreen += Game1.deltaTime.ElapsedGameTime.Milliseconds;
        //}

        ////May or may not keep
        //public void CheckOnScreen()
        //{
        //    CheckTime();
        //    if (onScreen > timeAllowed)
        //    {
        //        remainOnScreen = false;
        //    }

        //}

        ///*
        // * Drag Health
        // * Might change placement later
        // */
        //public void Health()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Fire Drag Attack
        // */
        //public void Attack()
        //{
        //    //TODO:FIX LATER
        //    //change this to a state
        //    //if (BossFireDragonSprite.newAttack)
        //    //{
        //    //    remainOnScreen = true;
        //    //    weapon.Attack();
        //    //    weapon.Draw();
        //    //}
        //}

        //TODO: Fix later
        //public Direction getDirection()
        //{
        //    return sprite.get

        //}

        //public Vector2 getPosition()
        //{


        //}



        ///*
        // * Drag item drop
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

