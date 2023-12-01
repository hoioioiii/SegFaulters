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



    public class Orb : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }
        public int attackStat { get; private set; }

        public Orb((int,int) pos, ORB_DIRECTION positionDirection)
        {
            sprite = WeaponSpriteFactory.Instance.CreateOrbSprite((pos.Item1,pos.Item2),positionDirection);
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
            if (sprite.finished())
            {
                Game1.GameObjManager.removeWeapon(this);
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
    }
}
