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
    public class Clock : IItem
    {
        public Rectangle BoundingBox { get; set; }


        //Remove later-------
        private Game1 GameObject;
        private ContentManager ContentLoad;

        private ISprite sprite;

        //Remove later above--------------




        public Clock()
        {
            //remove later:
            sprite = ItemSpriteFactory.Instance.CreateClockSprite();


        }
        //change the current frame to the next frame
        public void Update()
        {
            sprite.Update();

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);


        }






    }
}



