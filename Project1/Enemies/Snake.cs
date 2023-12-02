using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Project1.Constants;
using Project1.Enemies;

namespace Project1
{
	public class Snake : UniversalClassEntity
	{
        public override Rectangle BoundingBox => GetPositionAndRectangle();
       
        private ISprite sprite;


     
        public Snake((int, int) position, (String, int)[] items): base(position, items)
        {
         
            sprite = EnemySpriteFactory.Instance.CreateSnakeSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
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

            movement_manager.WanderMove();
            
        }


    }
}

