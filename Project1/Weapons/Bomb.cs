﻿using System;
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



    internal class Bomb : IWeapon
    {
        public Rectangle BoundingBox { get; set; }
        public bool detected { set => throw new NotImplementedException(); }
        public WEAPON_TYPE weaponType { get; private set; }
        private ISpriteWeapon sprite;

        public bool finishEarly { private get; set; }

        public Bomb() {

            weaponType = WEAPON_TYPE.BOMB;
            sprite = WeaponSpriteFactory.Instance.CreateBombSprite();
        }

        /**
         * Attack
         */
        public void Attack()
        {
            sprite.Attack();
            AudioManager.PlaySoundEffect(bombDrop);
        }
        /*
         * Update
         */

        public void Update()
        {
            sprite.Update();
            BoundingBox = sprite.GetRectangle();
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

        public bool finished()
        {
            return sprite.finished();
        }

    

        public void Attack(int x, int y, Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public Rectangle getDetectionFieldRectangle()
        {
            throw new NotImplementedException();
        }

        public void storeTarget(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
