using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
using Project1.Enemies;

namespace Project1
{
	public class DogMonster : UniversalClassEntity
	{
        public override Rectangle BoundingBox => GetPositionAndRectangle();
        //Texture stores the texture alias for our animation
        

        private ISprite sprite;

        /*
         * Initalize Dog Monster
         */
        public DogMonster((int, int) position, (String, int)[] items): base(position, items)
        {

            sprite = EnemySpriteFactory.Instance.CreateDogMonsterSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
        }
        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }
        ///*
        // * Update Dog Monster
        // */
        //public void Update()
        //{
        //    sprite.Update();

        //}

        ///*
        // * Draw the Sprite
        // */
        //public void Draw(SpriteBatch spriteBatch)
        //{

        //    sprite.Draw(spriteBatch);
        //}

        ///*
        // * Implement the Health
        // */
        //public void Health()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Implement the Attack
        // */
        //public void Attack()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Item the Sprite drops when it dies.
        // */
        //public void ItemDrop()
        //{
        //    throw new NotImplementedException();
        //}

        //public Rectangle getPositionAndRectangle()
        //{
        //    return sprite.GetRectangle().Item2;

        //}

        //public void setPosition(int x, int y)
        //{
        //    sprite.setPos(x, y);

        //}
    }
}

