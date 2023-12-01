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

    }
}
