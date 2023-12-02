using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Project1.Constants;
using Project1.Enemies;

namespace Project1
{
    public class DogMonster : UniversalClassEntity
    {
        public override Rectangle BoundingBox => GetPositionAndRectangle();
 
        private ISprite sprite;
        private IWeapon[] weapon;
        private bool ended;
        
   
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

            if (!ended)
            {
                EndAttack();
            }
        }
        private void StartAttack()
        {
            if (state_manager.startNewAttack())
            {
               
                direction_state_manager.ChangeDirection();
                weapon[0] = new Boomerange();
                state_manager.setNewAttack(false);
                ended = false;
                Game1.GameObjManager.addNewWeapon(weapon[0]);
            }

        }

        private void EndAttack()
        {
            if (weapon[0].finished())
            {
                state_manager.setIsAttacking(false);
                state_manager.setIsMoving(true);
                time_manager.enableMoveTime();
                direction_state_manager.GetRandomDirection();
                ended = true;
                Game1.GameObjManager.removeWeapon(weapon[0]);
            }
        }

        private void PrepareAttack()
        {
            if (time_manager.checkIfAttackTimeRandom())
            {
                state_manager.setIsAttacking(true);
                state_manager.setIsMoving(false);
                state_manager.setNewAttack(true);
            }
        }
    }
}

