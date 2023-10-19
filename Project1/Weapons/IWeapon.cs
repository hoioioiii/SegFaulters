using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    public interface IWeapon
    {
        public Rectangle BoundingBox { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Attack();

        public void Load();

        public void GetUserPos();

        public void GetUserState();

        public void DetermineWeaponState();

        public void Update();

        public void Attack(int x, int y, Direction direct);
        public void Draw();

        public bool finished();
    }
}