using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class DirectionManager
    {
        public static Dictionary<String, int> weaponLoaderToDirection;
        

        public static void createWeaponToDirectionMap()
        {
            weaponLoaderToDirection = new Dictionary<String, int>();
            weaponLoaderToDirection.Add("left", 0);
            weaponLoaderToDirection.Add("right", 1);
            weaponLoaderToDirection.Add("up", 2);
            weaponLoaderToDirection.Add("down", 3);
        }

    }
}
