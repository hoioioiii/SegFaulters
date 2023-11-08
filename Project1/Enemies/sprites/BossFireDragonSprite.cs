using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class BossFireDragonSprite : UniversalSpriteClass
    {


       

        public static bool newAttack;
      
        public BossFireDragonSprite(List<Texture2D[]> spriteSheet, IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time) : base(spriteSheet,animation, movement, state, direction, time)
        {
            animation.frame_list = spriteSheet;
            newAttack = true;
        }

        public override (int, int) GetHeightAndWidthResized()
        {
            int height = animation_manager.sprite_frame.Height / SMALLER_SIZE;
            int width = animation_manager.sprite_frame.Width / SMALLER_SIZE;

            return (width, height);

        }

        private bool CheckFinished(IWeapon[] weapon)
        {
            

            for(int i = 0; i < weapon.Length; i++)
            {
                if (!weapon[i].finished()) return false;
               
            }
            return true;
        }

        private void LoopAttack(IWeapon[] weapon)
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                weapon[i].Attack();
                weapon[i].Draw();
            }
        }



        public override void DrawAttack(IWeapon[] weapon)
        {
            if (!CheckFinished(weapon))
            {//This is soley for draw
                LoopAttack(weapon);
            }
        }

    }
}



