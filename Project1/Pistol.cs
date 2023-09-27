using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
   
    public class Pistol : Weapon
    {
        public Pistol(Player character) : base(character) { }

        public override void WeaponStartFire()
        {
            base.WeaponStartFire();
        }
    }
}
