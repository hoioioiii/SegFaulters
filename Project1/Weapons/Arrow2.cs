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

    internal class Arrow2 : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }

        public Arrow2()
        { 
            sprite = WeaponSpriteFactory.Instance.CreateArrowSprite();
        }

        /*
         * Create Attack
         */
        public void Attack()
        {
            sprite.Attack();

        }

        /*
         * Update
         */
        public void Update()
        {
            sprite.Update();
            //GetUserPos();
            //GetUserState();
        }

        /*
         * Draw the sprite
         */
        public void Draw()
        {
            sprite.Draw(Game1._spriteBatch);
        }
        

        /*
         * Load the sprite
         */
        public void Load()
        {
            throw new NotImplementedException();
        }

        
        //public void GetUserPos(int x, int y)
        //{
            
        //}

        //public void GetUserState(Direction currUserDirection)
        //{
            
        //}

        public void DetermineWeaponState()
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

        public void Update(int x, int y, Direction direct)
        {
            throw new NotImplementedException();
        }

        public bool finished()
        {
            throw new NotImplementedException();
        }

      
        public void Attack(int x, int y, Direction direct)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
