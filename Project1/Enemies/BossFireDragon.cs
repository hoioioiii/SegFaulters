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
	public class BossFireDragon : IEntity
	{


        private IWeapon weapon;
        
        //May or may not keep
        private int timeAllowed;
        private ISprite sprite;
        private bool remainOnScreen;
        private int onScreen;

        /*
         * Initalize fire drag
         */
        public BossFireDragon()
		{
            timeAllowed = 1000;
            onScreen = 0;
            remainOnScreen = false;
            weapon = new Orb();
            sprite = EnemySpriteFactory.Instance.CreateFireDragonSprite();
        }

        /*
         * Update Sprite
         */
        public void Update()
        {
            sprite.Update();

           //May or may not keep
            if (remainOnScreen)
            {
                weapon.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            sprite.Draw(spriteBatch);


            //Optomize this-----
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
            //optomize this later------

        }

        //May or may not keep
        public void CheckTime()
        {
            onScreen += Game1.deltaTime.ElapsedGameTime.Milliseconds;
        }

        //May or may not keep
        public void CheckOnScreen()
        {
            CheckTime();
            if (onScreen > timeAllowed)
            {
                remainOnScreen = false;
            }

        }

        /*
         * Drag Health
         * Might change placement later
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * Fire Drag Attack
         */
        public void Attack()
        {
            //TODO:FIX LATER
            //change this to a state
            //if (BossFireDragonSprite.newAttack)
            //{
            //    remainOnScreen = true;
            //    weapon.Attack();
            //    weapon.Draw();
            //}
        }

        //TODO: Fix later
        //public Direction getDirection()
        //{
        //    return sprite.get

        //}

        //public Vector2 getPosition()
        //{


        //}



        /*
         * Drag item drop
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }


        public Rectangle getPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public void setPosition(int x, int y)
        {
            sprite.setPos(x, y);

        }






    }
  
}

