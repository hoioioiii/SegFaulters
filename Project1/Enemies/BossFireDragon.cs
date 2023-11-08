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

       
        private bool ended;
        private IWeapon[] weapon;

        //May or may not keep
        private int timeAllowed;
        private ISprite sprite;
        private bool remainOnScreen;
        private int onScreen;

        /*
         * Initalize fire drag
         */
        public BossFireDragon((int, int) position, (String, int)[] items): base(position, items)
        {
            timeAllowed = 1000;
            onScreen = 0;
            remainOnScreen = false;
            
            sprite = EnemySpriteFactory.Instance.CreateFireDragonSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);

            weapon = new IWeapon[3];
            weapon[0] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
            weapon[1] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
            weapon[2]= new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
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

        public override void MovementType()
        {
            movement_manager.LeftAndRight();
        }


        private void UpdateWeapons()
        {
            foreach (IWeapon orb in weapon)
            {
                orb.Update();
            }

        }

        public override void Attack()
        {

            if (state_manager.IsAttacking())
            {
                UpdateWeapons();
            }
            else
            {
                PrepareAttack();
                state_manager.setIsAttacking(true);
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
                //direction_state_manager.NeedDirectionUpdate(true);
                weapon[0] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
                weapon[1] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
                weapon[2] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
                state_manager.setNewAttack(false);
                //time_manager.enableMoveTime();
                ended = false;
            }

        }

        private bool CheckFinish()
        {
           foreach( IWeapon orb in weapon)
            {
                if (!orb.finished()) { return false; }
            }

            return true;
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
    }
  
}

