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
        //public static Game1 GameObj = Game1.Game;

        public static int SPRITE_X = 350;
        public static int SPRITE_Y = 200;


        /*
         * Animations----------------------
         */
        public static int START_FRAME = 0;
        public static double FRAME_SPD = .5 / 4;
        public static int ENTITY_SPD = 2;

        /*
         * Bat sprite frames:
         */

        public enum DIRECTION {right = 0, left = 1, up = 2, down = 3};

        public static int PLAYER_FRAMES = 4;
        public static int PLAYER_R = 1;

    }
}

