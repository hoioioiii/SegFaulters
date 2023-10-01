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
	public class BossFireDragon : IEnemy
	{

        //Remove later-------
        private Game1 GameObject;
        private ContentManager ContentLoad;

        //Remove later above--------------


        private IWeaponMelee weapon;
        //Later create a animation tracker class:
        private int WIDTH;
        private int HEIGHT;
        private int ROW;
        private int COL;

        //Movement:
        private int POS_X;
        private int POS_Y;

        private int timeAllowed;
        private ISprite sprite;
        private bool remainOnScreen;
        private int onScreen;
        public BossFireDragon()
		{
            timeAllowed = 1000;
            onScreen = 0;
            remainOnScreen = false;
            weapon = new Orb();
            sprite = EnemySpriteFactory.Instance.CreateFireDragonSprite();
        }
        public void Update()
        {
            sprite.Update();

           
            if (remainOnScreen)
            {
                weapon.Update();
            }
        }

        private void Animate()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            sprite.Draw(spriteBatch);

            Attack();

            CheckOnScreen();

            if (remainOnScreen)
            {
                weapon.Draw();
            }
            else
            {
                onScreen = 0;
                remainOnScreen = false;
            }

        }

        public void CheckTime()
        {
            onScreen += Game1.deltaTime.ElapsedGameTime.Milliseconds;
        }


        public void CheckOnScreen()
        {
            CheckTime();
            if (onScreen > timeAllowed)
            {
                remainOnScreen = false;
            }

        }

        /*
         * Responsible for setting the the frame numbers(r,c) of the sprite
         */
        private void setFrames()
        {

        }

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load()
        {
            //setFrames();
            return ContentLoad.Load<Texture2D>(assetName: "FD");
        }

        public void Move()
        {
     
        }

        public void Health()
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            if (BossFireDragonSprite.newAttack)
            {
                remainOnScreen = true;
                weapon.Attack();
                weapon.Draw();
            }
        }

        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
  
}

