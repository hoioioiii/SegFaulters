using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{



    internal class Bomb : IWeaponMelee
    {
        private ISpriteWeapon sprite;
        public Bomb() {


            sprite = WeaponSpriteFactory.Instance.CreateBombSprite();
        }
        public void Attack()
        {
            sprite.Attack();
            
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(Game1._spriteBatch);
        }

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
    }
}
