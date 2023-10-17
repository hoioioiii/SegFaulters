using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal interface IWeaponProjectile
    {
        public Rectangle BoundingBox { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Attack();

        public void Load();

        public void GetUserPos();

        public void GetUserState();

        public void DetermineWeaponState();

        public void Update();

        public void Physics();

        //public void Draw(Vector2 position, int direction, int userScale);
    }




}

