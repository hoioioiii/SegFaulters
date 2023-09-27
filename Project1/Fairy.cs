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
    public class Fairy : IItem
    {

        //Texture stores the texture alias for our animation
        private Texture2D Texture { get; set; }

        //rows is the number of rows i the texture alias
        private int Rows { get; set; }

        //Columns is the number of columns in the alias
        private int Columns { get; set; }

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private double CURRENT_FRAME;

        //totalFrames keeps track of how many frames there are in total
        private int TOTAL_FRAME;

        //Remove later-------
        private Game1 GameObject;
        private ContentManager ContentLoad;

        private ISprite sprite;

        //Remove later above--------------




        public Fairy()
        {
            //remove later:
            sprite = ItemSpriteFactory.Instance.CreateFairySprite();


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

