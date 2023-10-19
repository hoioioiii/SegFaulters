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
namespace Project1
{
    public class OldMan : IEnemy
	{
        public Rectangle BoundingBox { get; set; }
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

        //Remove later above--------------



        //Later create a animation tracker class:
        private int WIDTH;
        private int HEIGHT;
        private int ROW;
        private int COL;

        //Movement:
        private int POS_X;
        private int POS_Y;

        private ISprite sprite;


        /*
         * Initalize OldMan
         */
        public OldMan()
		{
            
            sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
        }

        /*
         * Update Old man 
         */
        public void Update()
        {
            sprite.Update();
           
        }


        /*
         * Draw Old man
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Health -> implement?
         */
        public void Health()
        {
            throw new NotImplementedException();
        }


        /*
         * Attack -> implement?
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * ItemDrop -? implement?
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

