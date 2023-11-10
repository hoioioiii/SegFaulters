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
	public class SpikeCross : UniversalClassEntity
	{
        public override Rectangle BoundingBox => GetPositionAndRectangle();
        private ISprite sprite;

        /*
         * Initalize Spike
         */
        public SpikeCross((int, int) position, (String, int)[] items): base(position, items)
        {
            
            sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
        }

        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }

        public bool ItIsSameRow()
        {
            int playerRow = Player.getPositionAndRectangle().Location.X / 6; // Assuming rowHeight is the height of each row
            int entityRow = movement_manager.getPosition().Item1 / 6;

            return (playerRow == entityRow) ;
        }

        public bool ItIsSameCol()
        {
            int playerCol = Player.getPositionAndRectangle().Location.Y / 11; // Assuming rowHeight is the height of each row
            int entityCol = movement_manager.getPosition().Item2 / 11;

            return (playerCol == entityCol);
        }

        public override void MovementType()
        {

            //create new method with 
            //universal enemy class
        }

        ///*
        // * Update Spike
        // */
        //public void Update()
        //{
        //    sprite.Update();

        //}

        ///*
        // * Draw Spike
        // */
        //public void Draw(SpriteBatch spriteBatch)
        //{

        //    sprite.Draw(spriteBatch);
        //}


        ///*
        // * Spike Heath -> later
        // */
        //public void Health()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * 
        // * Spike aTTK -> LATER
        // */
        //public void Attack()
        //{
        //    throw new NotImplementedException();
        //}

        ///*
        // * Spike item driop -> later
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

