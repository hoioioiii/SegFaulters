using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{



    internal class Arrow2 : IWeaponMelee
    {
        private ISpriteWeapon sprite;
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
