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



    public class Rocket : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }
        public int attackStat { get; private set; }

        public bool detected { private get; set; }
        private IEntity target;
        public WEAPON_TYPE weaponType { get; private set; }
        public bool finishEarly { private get; set; }

        public Rocket((int, int) pos, ORB_DIRECTION positionDirection)
        {
            weaponType = WEAPON_TYPE.ROCKET;
            sprite = WeaponSpriteFactory.Instance.CreateRocketSprite((pos.Item1, pos.Item2), positionDirection);
            attackStat = 4;
        }
        public void Attack()
        {
            sprite.Attack();
        }

        public void Update()
        {
            sprite.Update();
            if (detected) checkIfTargetIsAlive();

            BoundingBox = sprite.GetRectangle();
            if (sprite.finished() || finishEarly)
            {
                Game1.GameObjManager.removeDetectionWeapon(this);
                Game1.GameObjManager.removePlayerWeapon(this);
                
            }
        }

        private void checkIfTargetIsAlive()
        {
            
            List<IEntity> existingEntites = Game1.GameObjManager.getEntityList();
            if (!existingEntites.Contains(target))
            {
                sprite.setTarget(null) ;
                detected = false;
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
            return sprite.getDetectionFieldRectangle();
        }

        public void storeTarget(IEntity entity)
        {
            if (!detected)
            {
                target = entity;
                sprite.setTarget(entity);
            }
        }
    }
}
