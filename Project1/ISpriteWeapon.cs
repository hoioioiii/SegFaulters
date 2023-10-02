using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface ISpriteWeapon
    {
        //public void Draw(SpriteBatch spriteBatch);

        //public void Attack();

        //public void Load();

        //public void GetUserPos();

        //public void GetUserState();

        //public void DetermineWeaponState();

        //public void Update();

        public void Attack();

        public void Update();

        public void Draw(SpriteBatch sprite);




    }
}
