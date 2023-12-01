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



    public class InitalRocket : IWeapon
    {
        private ISpriteWeapon sprite;
        public Rectangle BoundingBox { get; set; }
        public int attackStat { get; private set; }

     
       

        public InitalRocket()
        {
          
            sprite = WeaponSpriteFactory.Instance.CreateInitalRocketSprite();
            
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
    }
}