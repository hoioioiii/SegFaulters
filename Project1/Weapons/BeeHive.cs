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



    public class BeeHive : IWeapon
    {
        private ISpriteWeapon sprite;
        public Rectangle BoundingBox { get; set; }
        public int attackStat { get; private set; }
        public bool detected { set => throw new NotImplementedException(); }
        public WEAPON_TYPE weaponType { get; private set; }
        public bool finishEarly { private get; set; }

        public BeeHive()
        {
            weaponType = WEAPON_TYPE.BEES;
            sprite = WeaponSpriteFactory.Instance.CreateBeeHiveSprite();
            
            attackStat = 4;
        }
        public void Attack()
        {
            sprite.Attack();
        }

        public void Update()
        {
            sprite.Update();
            BoundingBox = sprite.GetRectangle();
            if (finished())
            {
               
                Game1.GameObjManager.removePlayerWeapon(this);
            }
        }

       

        public void Draw()
        {
            sprite.Draw(Game1._spriteBatch);
        }

        public void Attack(int x, int y, Direction direct)
        {
            throw new NotImplementedException();
        }

        public bool finished()
        {

            return sprite.finished();
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
