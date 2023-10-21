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
    public class Constants
    {

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        // used for clamping Link's position and keeping him contained in the level
        public static int roomBoundsMaxX = 660, roomBoundsMaxY = 360, roomBoundsMinX = 90, roomBoundsMinY = 53;
        
        // used for spawn and respawn after travelling through doors
        public static Vector2 RESPAWN_LEFT = new Vector2(roomBoundsMaxX * 7/8, roomBoundsMaxY/2);
        public static Vector2 RESPAWN_RIGHT = new Vector2(roomBoundsMaxX * 1/ 8, roomBoundsMaxY / 2);
        public static Vector2 RESPAWN_UP = new Vector2(roomBoundsMaxX /2, roomBoundsMaxY  * 7/ 8);
        public static Vector2 RESPAWN_DOWN = new Vector2(roomBoundsMaxX / 2, roomBoundsMaxY * 1 / 8);
        
        public static int ENEMY_SPEED = 1;

        public static int SCREEN_WIDTH_UPPER = 600;
        public static int SCREEN_WIDTH_LOWER = 0;
        public static int SCREEN_HEIGHT_UPPER = 400;
        public static int SCREEN_HEIGHT_LOWER = 0;
        public static Game1 GameObj = Game1.Game;

        // attacking
        public const float ATTACK_SECONDS = 0.5f;

        public static int SPRITE_X = 350;
        public static int SPRITE_Y = 200;

        public static int SPRITE_X_START = 400;
        public static int SPRITE_Y_START = 200;
        // damage
        public const float INVINCIBILITY_SECONDS = 1;

        // Link will flash after damaged, indicating temporary invincibility
        public const float FLASHES_PER_SECOND = 8;
        public const float FLASHTIME = 1 / FLASHES_PER_SECOND;

        /*
         * Animations----------------------
         * Link sprite constants:
         */
        public static int START_FRAME = 0;
        public static double FRAME_SPD = .5/4;
        public static int ENTITY_SPD = 2;

        /*
         * Bat sprite frames:
         */

        public static int ARROW_R = 1;
        public static int ARROW_C = 4;


        public static int BAT_TOTAL = 2;
        public static int BAT_C = 1;//remove

        public static int BOMB_R = 1;
        public static int BOMB_C = 1;
        public static int BOMB_ARRAY = 2;
        public static int AQUA_TOTAL = 2;
        public static int AD_C = 1;

        public static int BOOM_R = 1;
        public static int BOOM_C = 1;
        public static int DINO_TOTAL = 4;
        public static int DINO_C = 1;

        public static int BOW_R = 1;
        public static int BOW_C = 1;
        public static int FD_TOTAL = 4;
        public static int FD_C = 1;

        public static int CLOCK_R = 1;
        public static int CLOCK_C = 1;
        public static int DM_TOTAL = 8;
        public static int DM_C = 1;


        public static int FAIRY_R = 1;
        public static int FAIRY_C = 2;
        public static int FLAME_TOTAL = 1;
        public static int FLAME_C = 1;


        public static int HAND_TOTAL = 4;
        public static int HAND_C = 1;


        public static int JELLY_R = 1;
        public static int JELLY_TOTAL = 3;


        public static int MERCHANT_TOTAL = 1;
        public static int MERCHANT_C = 1;


        public static int OLDMAN_TOTAL = 1;
        public static int OLDMAN_C = 1;

        public static int SKELETON_TOTAL = 2;
        public static int SKELETON_C = 1;
        public static int HEART_R = 1;
        public static int HEART_C = 2;

        public static int SKELETON_ARRAY = 2;

        public static int HEART_CONTAINER_R = 1;
        public static int HEART_CONTAINER_C = 1;

        public static int SNAKE_TOTAL = 4;
        public static int SNAKE_C = 1;

        public static int SPIKE_TOTAL = 7;
        public static int SPIKE_C = 1;
        public static int KEY_R = 1;
        public static int KEY_C = 1;


        public static int LINK_R = 1;
        public static int LINK_C = 4;
        public static int MAP_R = 1;
        public static int MAP_C = 1;

        //public static int BOMB_R = 1;
        //public static int BOMB_C = 4;
        public static int RUPEE_R = 1;
        public static int RUPEE_C = 2;

        public static int SWORD_R = 1;
        public static int SWORD_C = 4;

        //public static int ARROW_R = 1;
        //public static int ARROW_C = 4;

        //public static int BOW_R = 1;
        //public static int BOW_C = 4;

        public static int BOOMERANG_R = 1;
        public static int BOOMERANG_C = 4;

        public static int ORB_R = 1;
        public static int ORB_C = 3;


        public static int LINK_X = 300;
        public static int LINK_Y = 300;

        public static int BLOCK_DIMENSION = 48;
        public static int LINK_BOUNDING_DIMENSION = 40;


        public enum DIRECTION {right = 0, left = 1, up = 2, down = 3};

        public static int UP_DIRECTION_SPRITE = 2;
        public static int DOWN_DIRECTION_SPRITE = 0;
        public static int PLAYER_FRAMES = 4;
        public static int PLAYER_R = 1;

        //items vars
        public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12 };
        public static int NUM_ITEMS = 13;

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

        //public enum DIRECTION {right = 0, left = 1, up = 2, down = 3};

        //public static int PLAYER_FRAMES = 4;
        //public static int PLAYER_R = 1;

        //
        //public const float INVINCIBILITY_SECONDS = 1;
        //public const float ATTACK_SECONDS = 0.5f;
        //public const float FLASHES_PER_SECOND = 8;
        //public const float FLASHTIME = 1 / FLASHES_PER_SECOND;
        public const float FRAMES_PER_SECOND = 10;
        public const float FRAMETIME = 1 / FRAMES_PER_SECOND;

        //
        public const float BOOMERANG_RANGE = 50;
        public static int TRIFORCE_R = 1;
        public static int TRIFORCE_C = 2;

        public enum CollisionType
        {
            // Link only
            ITEM,
            DOOR,
            // Link & enemies
            BOUNDARY,
            DAMAGE
        }

        // Knockback distance is used for collisions with enemies
        // How far should it be?
        public const int KNOCKBACK_DISTANCE = 30, knockbackDuration = 1, invincibilityDuration = 1;
    }
}

