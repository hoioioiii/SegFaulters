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
using System.Diagnostics;
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

            //Movement.WanderMove(direction_state_manager, this, time_manager);
            this.movement_manager.circularMovement(Direction.Right);
        }

        ///*
        //* Update the Bat
        //*/
        //public void Update()
        //{
        //    sprite.Update();

        //}

        //Might need this
        ///*
        // * Draw the Bat
        // */
        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    sprite.Draw(spriteBatch);

        //}

        ///*
        // * Have Bat Attack
        // */
        //public void Attack()
        //{
        //   //Attacks
        //}

        ///*
        // * Have the Bat drop a Item
        // */
        //public void ItemDrop()
        //{
        //    //Items they drop
        //}

        //fix later
        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }

        //public void setPosition(int x, int y)
        //{
        //   sprite.setPos(x, y);

        //}
    }
}

