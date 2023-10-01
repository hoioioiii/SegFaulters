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
        public static int SCREEN_WIDTH_UPPER = 600;
        public static int SCREEN_WIDTH_LOWER = 0;
        public static int SCREEN_HEIGHT_UPPER = 400;
        public static int SCREEN_HEIGHT_LOWER = 0;
        //public static Game1 GameObj = Game1.Game;
        // attacking
        public const float ATTACK_SECONDS = 0.5f;

        public static int SPRITE_X = 350;
        public static int SPRITE_Y = 200;
        // damage
        public const float INVINCIBILITY_SECONDS = 1;

        // Link will flash after damaged, indicating temporary invincibility
        public const float FLASHES_PER_SECOND = 8;
        //public const float FLASHTIME = 1 / FLASHES_PER_SECOND;

        /*
         * Animations----------------------
         */
        public static int START_FRAME = 0;
        public static double FRAME_SPD = .5 / 4;
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
        public static int DM_C = 8;


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

        public static int SKELETON_ARRAY = 2;


        public static int SNAKE_R = 1;
        public static int SNAKE_C = 4;

        public static int SPIKE_R = 1;
        public static int SPIKE_C = 7;


        public static int LINK_R = 1;
        public static int LINK_C = 4;

        public static int BOMB_R = 1;
        public static int BOMB_C = 4;

        public static int SWORD_R = 1;
        public static int SWORD_C = 4;

        public static int ARROW_R = 1;
        public static int ARROW_C = 4;

        public static int BOW_R = 1;
        public static int BOW_C = 4;

        public static int BOOMERANG_R = 1;
        public static int BOOMERANG_C = 4;

        public static int ORB_R = 1;
        public static int ORB_C = 3;


        public static int LINK_X = 300;
        public static int LINK_Y = 300;






        public static int UP_DIRECTION_SPRITE = 2;
        public static int DOWN_DIRECTION_SPRITE = 0;

        // for Link's sprite animation
        // how many animation frames per second, not the framerate of the game
        //public const float FRAMES_PER_SECOND = 10;
        //public const float FRAMETIME = 1 / FRAMES_PER_SECOND;

        //public static int SCREEN_WIDTH_UPPER = 700;
        //public static int SCREEN_WIDTH_LOWER = 0;
        //public static int SCREEN_HEIGHT_UPPER = 400;
        //public static int SCREEN_HEIGHT_LOWER = 0;


        /*
         * Link sprite constants:
         */

        public enum DIRECTION {right = 0, left = 1, up = 2, down = 3};

        public static int PLAYER_FRAMES = 4;
        public static int PLAYER_R = 1;

        //
        //public const float INVINCIBILITY_SECONDS = 1;
        //public const float ATTACK_SECONDS = 0.5f;
        //public const float FLASHES_PER_SECOND = 8;
        public const float FLASHTIME = 1 / FLASHES_PER_SECOND;
        public const float FRAMES_PER_SECOND = 10;
        public const float FRAMETIME = 1 / FRAMES_PER_SECOND;

        //
        public const float BOOMERANG_RANGE = 50;
    }
}

