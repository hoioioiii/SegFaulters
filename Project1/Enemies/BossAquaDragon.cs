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
    public class BossAquaDragon : IEnemy
	{
        public Rectangle BoundingBox { get; set; }
        //Texture stores the texture alias for our animation
        private Texture2D Texture { get; set; }

        
        //Remove later-------
        private Game1 GameObject;
        private ContentManager ContentLoad;

        private ISprite sprite;

        //Remove later above--------------



        //Later create a animation tracker class:
        private int WIDTH;
        private int HEIGHT;
        private int ROW;
        private int COL;

        //Movement:
        private int POS_X;
        private int POS_Y;

        public BossAquaDragon()
		{
          
            sprite = EnemySpriteFactory.Instance.CreateBossAquaDragonSprite();
        }

        /*
        * 
        * Update
        */
        public void Update()
        {
            sprite.Update();
            
          
           
            
        }

        /*
        * 
        * Ignore
        */
        private void Animate()
        {

        }

        /*
        * 
        * Draw
        */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Ignore
         */
        private void setFrames()
        {
       
        }

        /*
         * ignore
         */
        public Texture2D Load()
        {
            /*
            setFrames();
            */
            return ContentLoad.Load<Texture2D>(assetName: "AD");
            
        }
        /*
        * 
        * ignore
        */
        public void Move()
        {
      

        }

        /*
        * health
        * 
        */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
        * 
        * ignore
        */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
        * 
        * ignore
        */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

