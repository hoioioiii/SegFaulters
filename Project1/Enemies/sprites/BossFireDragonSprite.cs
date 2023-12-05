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


        public override void Draw(SpriteBatch spriteBatch, IWeapon[] weapon)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(animation_manager.sprite_frame, base.rectangles.Item2, base.rectangles.Item1, Color.White);
            }
        }

    }
}



