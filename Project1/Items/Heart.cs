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

namespace Project1
{
    public class Heart : IItem
    {
        private IItemSprite sprite;
        public Rectangle BoundingBox => getRectangle();

        public bool drawState { get; set; }
        public Heart((int, int) pos)
        {
            drawState = true;
         
            sprite = ItemSpriteFactory.Instance.CreateHeartSprite(pos);
        }

        //Update Frames of the Item
        public void Update()
        {
            sprite.Update();
        }

        // Sprite for item in Link's inventory. Displaying link inventory
        public void Draw(SpriteBatch spriteBatch)
        {
           
            sprite.Draw(spriteBatch);
        }

        // Sprite for items to be put into the level loader
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int spriteScale)
        {
           
            sprite.Draw(spriteBatch, location, spriteScale);
            

        }

        //Return bounding box of the item
        private Rectangle getRectangle()
        {
            return sprite.getRect();
        }
    }
}


