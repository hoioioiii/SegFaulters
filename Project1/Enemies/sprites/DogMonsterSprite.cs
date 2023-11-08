using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class DogMonsterSprite : UniversalSpriteClass
    {

        //public static bool newAttack;
        //private IWeapon weapon;

        public DogMonsterSprite(List<Texture2D[]> spriteSheet, IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time) : base(spriteSheet, animation, movement, state, direction, time)

        {
            //newAttack = true;
            //weapon = new Boomerange();
            //animation.frame_list = spriteSheet;
        }

        public override void DrawAttack(IWeapon[] weapon)
        {


            //if (state_manager.startNewAttack())
            //{
            //    //create weapons
            //    direction_state_manager.changeDirection();
            //    //direction_state_manager.NeedDirectionUpdate(true);
            //    weapon = new Boomerange();
            //    state_manager.setNewAttack(false);

            //    //TODO:add item to active object list
            //}
            //else
            //{
            //    // means the entity is waiting for the weapon to comeback
            //    //get weapon obj status of returned/finished) : place holder using state_isAttacking for now
            //    //get weapon status of "finished" which means we need to be able to get access to the weapon obj
            //    if (weapon.finished())
            //    {//if weapon is finished and returned to enetity
            //        state_manager.setIsAttacking(false);
            //        //set move to true
            //        state_manager.setIsMoving(true);
            //        //set isAttacking to false;
            //        time_manager.enableMoveTime();
            //        direction_state_manager.getRandomDirection();
            //        //TODO:remove the item from the active object list
            //    }
            //    else
            //    {
            //        weapon.Attack(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, direction_state_manager.getDirection());
            //        weapon.Draw();
            //    }


            //if (!weapon[0].finished())
            //{//This is soley for draw
            //    weapon[0].Attack(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, direction_state_manager.getDirection());
            //    weapon[0].Draw();
            //}


            if (!weapon[0].finished())
            {//This is soley for draw
                weapon[0].Attack(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, direction_state_manager.getDirection());
                weapon[0].Draw();
            }
        }

        }
    }





