using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
namespace Project1
{



    internal class BoomerangePlayer : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }

        public int attackStat { get; private set; }

        public BoomerangePlayer()
        {
            sprite = WeaponSpriteFactory.Instance.CreateBoomerangePlayerSprite();
            attackStat = 2;
        }

        /*
         * Attack
         */
        public void Attack(int x, int y, Direction direct)
        {

            
            sprite.Attack();

        }
        /*
         * Update
         */
        public void Update()
        {
            Attack();
            sprite.Update();
            if (finished())
            {
                Game1.GameObjManager.removePlayerWeapon(this);
            }
        }
        /*
         * 
         * Draw
         */
        public void Draw()
        {

            sprite.Draw(Game1._spriteBatch);
        }

        public void GetUserPos(int x, int y)
        {
            int xPos = (int)Player.getPosition().X;
            int yPos = (int)Player.getPosition().Y;
            sprite.GetUserPos(xPos, yPos);
        }

        public void GetUserState(Direction currUserDirection)
        {
            sprite.GetUserState(currUserDirection);
        }

        /*
        * Ognore--------------------
        * 
        */
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void GetUserPos()
        {
            throw new NotImplementedException();
        }

        public void GetUserState()
        {
            throw new NotImplementedException();
        }

        public void DetermineWeaponState()
        {
            throw new NotImplementedException();
        }



        public bool finished()
        {
            return sprite.finished();
        }

        public void Attack()
        {
         
            sprite.Attack();
        }

      
       

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}