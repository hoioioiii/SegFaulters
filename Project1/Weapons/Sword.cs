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



    internal class Sword : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }
        public bool isAttacking {private get; set; }

        public Sword()
        {
           
            sprite = WeaponSpriteFactory.Instance.CreateSwordSprite();

        }

        /*
         * Attack
         */
        public void Attack()
        {
            sprite.Attack();
            AudioManager.PlaySoundEffect(sword);
        }
        /*
         * Update
         */
        public void Update()
        {

            sprite.Update();
            BoundingBox = sprite.GetRectangle();
            finished();
        }
        /*
         * 
         * Draw
         */
        public void Draw()
        {
            
            sprite.Draw(Game1._spriteBatch);
        }

        public bool finished()
        {
            if (sprite.finished()) {
                Game1.GameObjManager.removePlayerWeapon(this);

            }
            return sprite.finished();
        }

        public void Attack(int x, int y, Direction direct)
        {
            throw new NotImplementedException();
        }
    }
}
