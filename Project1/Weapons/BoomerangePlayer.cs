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



    internal class BoomerangePlayer : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }
        public WEAPON_TYPE weaponType { get; private set; }
        public int attackStat { get; private set; }
        public bool detected { set => throw new NotImplementedException(); }
        public bool finishEarly { private get; set; }

        public BoomerangePlayer()
        {
            weaponType = WEAPON_TYPE.BOOMERANGE;
            sprite = WeaponSpriteFactory.Instance.CreateBoomerangePlayerSprite();
            attackStat = 2;
        }

        /*
         * Attack
         */
        public void Attack(int x, int y, Direction direct)
        {

            
            sprite.Attack();
            AudioManager.PlaySoundEffect(boomerang);
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
                Game1.GameObjManager.removePlayerWeapon(this);
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