using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Project1.Constants;
using Project1.Enemies;

namespace Project1
{
	public class Bat : UniversalClassEntity
    {
       

        public override Rectangle BoundingBox => GetPositionAndRectangle();

        private ISprite sprite;
        
        /*
         * Initalize Bat Features
         */
        public Bat((int, int) position, (String, int)[] items): base(position, items)
        {

            sprite = EnemySpriteFactory.Instance.CreateBatSprite(animation_manager,movement_manager,direction_state_manager,state_manager,time_manager);

        }

        public override void MovementType()
        {
            this.movement_manager.circularMovement(Direction.Right);
        }

        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }

    }
}

