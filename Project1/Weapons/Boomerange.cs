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



    internal class Boomerange : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }

        public int attackStat { get; private set; }
        public bool detected { set => throw new NotImplementedException(); }

        public Boomerange()
        {
            sprite = WeaponSpriteFactory.Instance.CreateBoomerangeSprite();
            attackStat = 2;
        }

        /*
         * Attack
         */
        public void Attack(int x, int y, Direction direct)
        {
            GetUserPos(x, y);
            GetUserState(direct);
            sprite.Attack();
        }


        /*
         * Update
         */
        public void Update()
        {
            Attack();
            BoundingBox = sprite.GetRectangle();
            sprite.Update();

            if (finished())
            {
                Game1.GameObjManager.removeWeapon(this);
            }
        }
        /*
         * 
         * Draw
         */
        public void Draw()
        {

            sprite.Draw(Game1._spriteBatch);
        }

        private void GetUserPos(int x, int y)
        {
            sprite.GetUserPos(x, y);
        }

        private void GetUserState(Direction currUserDirection)
        {
            sprite.GetUserState(currUserDirection);
        }

        public bool finished()
        {
            return sprite.finished();
        }

        public void Attack()
        {
            sprite.Attack();

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