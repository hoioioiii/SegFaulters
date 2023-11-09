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
	public class Flame : UniversalClassEntity
	{  
        private ISprite sprite;
        public override Rectangle BoundingBox => GetPositionAndRectangle();
        /*
         * Initalize the flame
         */
        public Flame((int, int) position, (String, int)[] items): base(position, items)
        {
            sprite = EnemySpriteFactory.Instance.CreateFlameSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
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
        // * Update the flame
        // */
        //public void Update()
        //{
        //    sprite.Update();

        //}

        ///*
        // * Draw Flame Sprite
        // */
        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    sprite.Draw(spriteBatch);
        //}

        ///*
        // * Maybe not
        // */
        //public void Health()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Maybe?
        // */
        //public void Attack()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Prob not
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

