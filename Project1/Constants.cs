using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Constants
    {
        // attacking
        public const float ATTACK_SECONDS = 0.5f;

        // damage
        public const float INVINCIBILITY_SECONDS = 1;

        // Link will flash after damaged, indicating temporary invincibility
        public const float FLASHES_PER_SECOND = 8;
        public const float FLASHTIME = 1 / FLASHES_PER_SECOND;

        // for Link's sprite animation
        // how many animation frames per second, not the framerate of the game
        public const float FRAMES_PER_SECOND = 10;
        public const float FRAMETIME = 1 / FRAMES_PER_SECOND;
    }
}
