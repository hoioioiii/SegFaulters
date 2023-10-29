using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Project1
{
    public class AudioConstants
    {
        public static Song BGM;

        public static SoundEffect addUI, boomerang, cling, death, zeldaSound, dragon, dragon2, dragon3, enemyDie, fire, flame, item,
            lowHealth,
            plus,
            plusPlus,
            secret,
            stairs,
            subtractUI,
            sword;

        public enum AudioFile
        {
            addUI,
            boomerang,
            cling,
            death,
            zeldaSound,
            dragon,
            dragon2,
            dragon3,
            enemyDie,
            fire,
            flame,
            item,
            lowHealth,
            plus,
            plusPlus,
            secret,
            stairs,
            subtractUI,
            sword
        }
    }
}
