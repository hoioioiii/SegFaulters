using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IWeapon
    {
        public void WeaponFire(Texture2D player);
        public void WeaponReload();

        


    }
}
