using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{



    internal class Boomerange : IWeaponMelee
    {
        private ISpriteWeapon sprite;
        public Boomerange()
        {

            sprite = WeaponSpriteFactory.Instance.CreateBoomerangeSprite();
        }

        /*
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
         * 
         * Draw
         */
        public void Draw()
        {
            sprite.Draw(Game1._spriteBatch);
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
    }
}
