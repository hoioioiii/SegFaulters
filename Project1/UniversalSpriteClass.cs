using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class UniversalSpriteClass: ISprite
    {
        public IDirectionStateManager direction_state_manager;
        public IAnimation animation_manager;
        public ITime time_manager;
        public IMove movement_manager;
        public IEntityState state_manager;

        private (Rectangle, Rectangle) rectangles;
        public UniversalSpriteClass(List<Texture2D[]> spriteSheet,IAnimation animation, IMove movement, IEntityState state, IDirectionStateManager direction, ITime time) {
        
            direction_state_manager = direction;
            animation_manager = animation;
            animation_manager.frame_list = spriteSheet;
            animation_manager.PopulateFrames();
            movement_manager = movement;
            time_manager = time;
            state_manager = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(animation_manager.sprite_frame, rectangles.Item2, rectangles.Item1, Color.White);
            }
        }

        //used for entity's that have some sort of weapon/projectile
        public void Draw(SpriteBatch spriteBatch, IWeapon[] weapon)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(animation_manager.sprite_frame, rectangles.Item2, rectangles.Item1, Color.White);
                if (state_manager.IsAttacking()) DrawAttack(weapon);
            }
        }


        public virtual void DrawAttack(IWeapon[] weapon)
        {
            //null have each enemy implement their own

        }

        //needed if another sprint needs a specific refacor for size
        public virtual (int,int) GetHeightAndWidthResized()
        {
            int height = animation_manager.sprite_frame.Height * LARGER_SIZE;
            int width = animation_manager.sprite_frame.Width * LARGER_SIZE;

            return(width,height);
        }

        public void setRectangles()
        {
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;

            int height = animation_manager.sprite_frame.Height;
            int width = animation_manager.sprite_frame.Width;
            rectangles.Item1 = new Rectangle(1, 1, width, height);
            width = GetHeightAndWidthResized().Item1;
            height = GetHeightAndWidthResized().Item2;
            rectangles.Item2 = new Rectangle(x, y, width, height);
        }

        public (Rectangle, Rectangle) GetRectangle()
        {
            return rectangles;
        }
    }
}
