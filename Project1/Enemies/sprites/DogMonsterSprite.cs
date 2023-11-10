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
            if (!weapon[0].finished())
            {//This is soley for draw
                weapon[0].Attack(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, direction_state_manager.getDirection());
                weapon[0].Draw();
            }
        }

        }
    }





