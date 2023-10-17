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



    internal class Orb : IWeaponMelee
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }

        public Orb()
        {
            sprite = WeaponSpriteFactory.Instance.CreateOrbSprite();
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

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
