using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public interface ISpriteWeapon
    {
        //public void Draw(SpriteBatch spriteBatch);

        //public void Attack();

        //public void Load();

        public void GetUserPos(int x, int y);

        public void GetUserState(Direction direct);

        //public void DetermineWeaponState();

        //public void Update();

        public void Attack();

        public void Update();

        public void Draw(SpriteBatch sprite);

        public bool finished();


    }
}
