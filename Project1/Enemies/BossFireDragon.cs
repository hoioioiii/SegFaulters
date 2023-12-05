using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Project1.Constants;
using Project1.Enemies;
using Microsoft.Xna.Framework.Audio;

namespace Project1
{
    public class BossFireDragon : UniversalClassEntity
    {

        public override Rectangle BoundingBox => GetPositionAndRectangle();


        private bool ended;
        private IWeapon[] weapon;

      
        private int timeAllowed;
        private ISprite sprite;
        private bool remainOnScreen;
        private int onScreen;

        private SoundEffectInstance dragonSFX;

    
        public BossFireDragon((int, int) position, (String, int)[] items) : base(position, items)
        {
            ORB_TIME_ALLOWED = 1000;
            onScreen = 0;
            remainOnScreen = false;

            sprite = EnemySpriteFactory.Instance.CreateFireDragonSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);

            weapon = new IWeapon[MAX_ORBS];
            CreateOrbs();
            ended = false;

            dragonSFX = dragon.CreateInstance();
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
                PrepareAttack();
                StartAttack();
            }

        }


        private void StartAttack()
        {
            if (state_manager.startNewAttack())
            {
                dragonSFX.Play();

                CreateOrbs();
                
                state_manager.setNewAttack(false);
                time_manager.EnableMoveTime();

                foreach (IWeapon orb in weapon)
                {
                    Game1.GameObjManager.addNewWeapon(orb);
                }

                state_manager.setIsAttacking(false);
            }

        }

        private void CreateOrbs()
        {

            weapon[TOP_ORB] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.TOP);
            weapon[MID_ORB] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.MIDDLE);
            weapon[BOT_ORB] = new Orb((movement_manager.getPosition().Item1, movement_manager.getPosition().Item2), ORB_DIRECTION.BOTTOM);
        }

        private void PrepareAttack()
        {
            if (time_manager.CheckIfAttackTime()) 
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

