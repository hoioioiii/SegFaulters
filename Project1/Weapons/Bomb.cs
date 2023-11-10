﻿using System;
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

            if (finished())
            {
                Game1.GameObjManager.removePlayerWeapon(this);
            }


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

        public void Update(int x, int y, Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public bool finished()
        {
            return sprite.finished();
        }

        public void Draw(int x, int y, Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public void Attack(int x, int y, Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
