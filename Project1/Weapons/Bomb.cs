using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{



    internal class Bomb : IWeapon
    {
        public Rectangle BoundingBox { get; set; }

        private ISpriteWeapon sprite;
        public Bomb() {


            sprite = WeaponSpriteFactory.Instance.CreateBombSprite();
        }

        /**
         * Attack
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
        }

        /*
         * Draw
         */
        public void Draw()
        {
            sprite.Draw(Game1._spriteBatch);
        }


        //Ignore-----------------------------fix later
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

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
