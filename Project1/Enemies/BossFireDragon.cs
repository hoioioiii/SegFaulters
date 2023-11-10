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

            weapon = new IWeapon[3];
            CreateOrbs();
            ended = false;

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

        public override void MovementType()
        {
            movement_manager.LeftAndRight();
        }


        public override void Attack()
        {
            if (!state_manager.IsAttacking())
            {
                // The dragon's sound effect is overlapping itself!!!
                /*
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
                */

                /*
                //direction_state_manager.NeedDirectionUpdate(true);
                weaponTop = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
                weaponMiddle = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
                weaponBottom = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
                      
                }             

                //direction_state_manager.NeedDirectionUpdate(true);
                weaponTop = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
                weaponMiddle = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
                weaponBottom = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
                */
                state_manager.setNewAttack(false);
                time_manager.enableMoveTime();

                foreach (IWeapon orb in weapon)
                {
                    Game1.GameObjManager.addNewWeapon(orb);
                }

                state_manager.setIsAttacking(false);
            }
        }

        private void CreateOrbs()
        {
            
            weapon[0] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
            weapon[1] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
            weapon[2] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
        }


        //this needs to be handled by a execute.


        private void PrepareAttack()
        {
            if (time_manager.checkIfAttackTime()) //time_manager.checkIfAttackTime())
            {
                state_manager.setIsAttacking(true);
                state_manager.setNewAttack(true);
            }
            else
            {
                state_manager.setNewAttack(false);
            }
        }
    }
  
}

