using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    public class WeaponCollisionResponse
    {

        public static void WeaponResponse(IWeapon weapon)
        {
            if (weapon.weaponType == WEAPON_TYPE.ORBS || weapon.weaponType == WEAPON_TYPE.BEES)
            {
                weapon.finishEarly = true;
            }
        }
    }
}
