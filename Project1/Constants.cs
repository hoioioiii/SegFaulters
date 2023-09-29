using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Game1;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    internal class Constants
    {
        public static int SCREEN_WIDTH_UPPER = 700;
        public static int SCREEN_WIDTH_LOWER = 0;
        public static int SCREEN_HEIGHT_UPPER = 400;
        public static int SCREEN_HEIGHT_LOWER = 0;
        public static Game1 GameObj = Game1.Game;

        public static int SPRITE_X = 350;
        public static int SPRITE_Y = 200;


        /*
         * Animations----------------------
         */
        public static int START_FRAME = 0;
        public static double FRAME_SPD = .5/4;
        public static int ENTITY_SPD = 2;

        /*
         * Bat sprite frames:
         */

        public static int BAT_R = 1;
        public static int BAT_C = 2;

        public static int AD_R = 1;
        public static int AD_C = 2;

        public static int DINO_R = 1;
        public static int DINO_C = 4;

        public static int FD_R = 1;
        public static int FD_C = 4;

        public static int DM_R = 1;
        public static int DM_C = 4;


        public static int FLAME_R = 1;
        public static int FLAME_C = 1;


        public static int HAND_R = 1;
        public static int HAND_C = 4;


        public static int JELLY_R = 1;
        public static int JELLY_C = 3;


        public static int MERCHANT_R = 1;
        public static int MERCHANT_C = 1;


        public static int OLDMAN_R = 1;
        public static int OLDMAN_C = 1;

        public static int SKELETON_R = 1;
        public static int SKELETON_C = 2;

        public static int SNAKE_R = 1;
        public static int SNAKE_C = 4;

        public static int SPIKE_R = 1;
        public static int SPIKE_C = 7;
    }
}
