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
        public bool detected { set => throw new NotImplementedException(); }
        public bool finishEarly { private get; set; }
        public WEAPON_TYPE weaponType { get; private set; }

        public Arrow2()
        {
            weaponType = WEAPON_TYPE.ARROW;
            sprite = WeaponSpriteFactory.Instance.CreateArrowSprite();
        }

        /*
         * Create Attack
         */
        public void Attack()
        {
            sprite.Attack();
            AudioManager.PlaySoundEffect(boomerang);
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
         * Draw the sprite
         */
        public void Draw()
        {
            sprite.Draw(Game1._spriteBatch);
        }
        

      

        public void Update(int x, int y, Direction direct)
        {
            throw new NotImplementedException();
        }

        public bool finished()
        {
            return sprite.finished();
        }

      
        public void Attack(int x, int y, Direction direct)
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
