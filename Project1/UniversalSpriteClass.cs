using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;

namespace Project1
{
    public class UniversalSpriteClass
    {
        public IDirectionStateManager direction_state_manager;
        public IAnimation animation_manager;
        public ITime time_manager;
        public IMove movement_manager;
        public IEntityState state_manager;

        private (Rectangle, Rectangle) rectangles;
        public UniversalSpriteClass(IAnimation animation, IMove movement, IEntityState state, IDirectionStateManager direction, ITime time) {
        
            direction_state_manager = direction;
            animation_manager = animation;
            movement_manager = movement;
            time_manager = time;
            state_manager = state;
        
        }


        //Keep in Sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            if (state_manager.IsAlive())
            {
                setRectangles();
                spriteBatch.Draw(animation_manager.sprite_frame, rectangles.Item2, rectangles.Item1, Color.White);
                if (state_manager.IsAttacking()) DrawAttack();
            }
        }

        //Keep in Sprite
        public virtual void DrawAttack()
        {
            //null have each enemy implement their own

        }

        /// <summary>
        //Keep in sprite
        /// </summary>
        public void setRectangles()
        {
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;
            int height = animation_manager.sprite_frame.Height;
            int width = animation_manager.sprite_frame.Width;
            rectangles.Item1 = new Rectangle(1, 1, width, height);
            rectangles.Item2 = new Rectangle(x, y, width, height);
        }



    }
}
