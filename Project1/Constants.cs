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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Project1
{
    public class Constants
    {
        public static Song BGM, gameOver, gameOverStateSound;

        //Change this later to be all caps
        public static SoundEffect winningStateSound, addUI , bombBlow, bombDrop, boomerang, cling, death, doorUnlock, puzzleSolved, dragon, dragon2, dragon3, enemyDie, enemyHit, fire, flame, bigItemGet, smallItemGet, heartGet, rupeeGet, linkHurt, lowHealth, plus, plusPlus, secret, stairs, subtractUI, sword;

        //Directions->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public enum DIRECTION { right = 0, left = 1, up = 2, down = 3, none = -1 };

        public static int UP_DIRECTION_SPRITE = 2;
        public static int DOWN_DIRECTION_SPRITE = 0;

        public static int UP = 0;
        public static int RIGHT = 1;
        public static int DOWN = 2;
        public static int LEFT = 3;
        public static int NONE = -1;

        public enum ENEMY_DIRECTION { up = 0, right = 1, down = 2, left = 3 };

        //Windows and frames metrics->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int ROOM_FRAME_HEIGHT = 0;
        public static int ROOM_FRAME_WIDTH = 0;

        public static int FRAME_BUFFER_Y = 320;
        public static int FRAME_BUFFER_X = 0;

        public static int SCREEN_WIDTH_UPPER = 600;
        //*
        public static int SCREEN_WIDTH = 800;
        public static int SCREEN_WIDTH_LOWER = 0;
        public static int SCREEN_HEIGHT_UPPER = 400;
        public static int SCREEN_HEIGHT_LOWER = 0;
        public static int PAUSED_STATE_YCOORD = ((SCREEN_HEIGHT / 3) * 2);
        //*
        public static int SCREEN_HEIGHT = (int)(480 * 1.75);
        //*
        public static int HUD_HEIGHT = SCREEN_HEIGHT / 3;
        //*
        public static int HUD_SECTION_WIDTH = SCREEN_WIDTH / 3;
        //*

        public static int HEALTH_HUD_WIDTH = HUD_SECTION_WIDTH * 2;
        public static int HEALTH_HUD_HEIGHT = (HUD_HEIGHT / 3);
        public static float HEALTH_ROW = 30f;
        public static int ENTITY_HEARTS = 5;
        public static int DAMAGE_HALF_HEART = 1;
        public static int DAMAGE_FULL_HEART = 3;
        public static int MAX_FRAGMENTS = 4;

        public enum USABLE_ITEM { boomerang = 0, bomb = 1, key = 2, bow = 3};

        public static int START_FRAME = 0;
        public static double FRAME_SPD = .5 / 4;
        public static int ENTITY_SPD = 2;

        public const float FRAMES_PER_SECOND = 10;
        public const float FRAMETIME = 1 / 10;

        //public static Game1 GameObj = Game1.Game;

        public static int WEAPON_OFFSET_X = 20;
        public static int WEAPON_OFFSET_Y = 30;
        //Collision metrics->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int roomBoundsMaxX = 660 + FRAME_BUFFER_X, roomBoundsMaxY = 365 + FRAME_BUFFER_Y, roomBoundsMinX = 90 + FRAME_BUFFER_X, roomBoundsMinY = 53 + FRAME_BUFFER_Y;

        public static int blockRows = 7, blockColumns = 12;
        // used for spawn and respawn after travelling through doors
        public static Vector2 RESPAWN_LEFT = new Vector2(roomBoundsMaxX - 20, (roomBoundsMaxY - roomBoundsMinY) / 2 + roomBoundsMinY + 10);
        public static Vector2 RESPAWN_RIGHT = new Vector2(roomBoundsMinX + 20, (roomBoundsMaxY - roomBoundsMinY) / 2 + roomBoundsMinY + 10);
        public static Vector2 RESPAWN_UP = new Vector2((roomBoundsMaxX - roomBoundsMinX) / 2 + roomBoundsMinX + 5, roomBoundsMaxY - 10);
        public static Vector2 RESPAWN_DOWN = new Vector2((roomBoundsMaxX - roomBoundsMinX) / 2 + roomBoundsMinX + 5, roomBoundsMinY + 10);
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

        //Enemies metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int ENEMY_SPEED = 11;

        public static int BAT_TOTAL = 2;
        public static int BAT_C = 1;
        public static int BAT_FRAMES_U = 2;
        public static int BAT_FRAMES_R = 2;
        public static int BAT_FRAMES_L = 2;
        public static int BAT_FRAMES_D = 2;
        public static int BAT_FRAMES_DEATH = 1;

        public static int AQUA_TOTAL = 2;
        public static int AQUA_FRAMES_U = 4;
        public static int AQUA_FRAMES_R = 2;
        public static int AQUA_FRAMES_L = 2;
        public static int AQUA_FRAMES_D = 4;
        public static int AQUA_FRAMES_DEATH = 1;

        public static int DINO_TOTAL = 4;
        public static int DINO_FRAMES_U = 3;
        public static int DINO_FRAMES_R = 3;
        public static int DINO_FRAMES_L = 3;
        public static int DINO_FRAMES_D = 3;
        public static int DINO_FRAMES_DEATH = 1;
        public static int DINO_C = 1;

        public static int DM_TOTAL = 8;
        public static int DM_FRAMES_U = 2;
        public static int DM_FRAMES_R = 2;
        public static int DM_FRAMES_L = 2;
        public static int DM_FRAMES_D = 2;
        public static int DM_FRAMES_DEATH = 1;
        public static int DM_C = 1;

        public static int JELLY_R = 1;
        public static int JELLY_FRAMES_U = 3;
        public static int JELLY_FRAMES_R = 3;
        public static int JELLY_FRAMES_L = 3;
        public static int JELLY_FRAMES_D = 3;
        public static int JELLY_FRAMES_DEATH = 1;
        public static int JELLY_TOTAL = 3;


        public static int MERCHANT_TOTAL = 1;
        public static int MERCHANT_FRAMES_U = 1;
        public static int MERCHANT_FRAMES_R = 1;
        public static int MERCHANT_FRAMES_L = 1;
        public static int MERCHANT_FRAMES_D = 1;
        public static int MERCHANT_FRAMES_DEATH = 1;
        public static int MERCHANT_C = 1;


        public static int OLDMAN_TOTAL = 1;
        public static int OLDMAN_FRAMES_U = 1;
        public static int OLDMAN_FRAMES_R = 1;
        public static int OLDMAN_FRAMES_L = 1;
        public static int OLDMAN_FRAMES_D = 1;
        public static int OLDMAN_FRAMES_DEATH = 1;
        public static int OLDMAN_C = 1;

        public static int SKELETON_TOTAL = 2;
        public static int SKEL_FRAMES_U = 2;
        public static int SKEL_FRAMES_R = 2;
        public static int SKEL_FRAMES_L = 2;
        public static int SKEL_FRAMES_D = 2;
        public static int SKEL_FRAMES_DEATH = 1;
        public static int SKELETON_C = 1;

        public static int SNAKE_TOTAL = 4;
        public static int SNAKE_FRAMES_U = 4;
        public static int SNAKE_FRAMES_R = 2;
        public static int SNAKE_FRAMES_L = 2;
        public static int SNAKE_FRAMES_D = 4;
        public static int SNAKE_FRAMES_DEATH = 1;
        public static int SNAKE_C = 1;

        public static int SPIKE_TOTAL = 7;
        public static int SPIKE_FRAMES_U = 1;
        public static int SPIKE_FRAMES_R = 1;
        public static int SPIKE_FRAMES_L = 1;
        public static int SPIKE_FRAMES_D = 1;
        public static int SPIKE_FRAMES_DEATH = 1;
        public static int SPIKE_C = 1;


        //Player metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int LINK_R = 1;
        public static int LINK_C = 4;
        public static int PLAYER_FRAMES_U = 2;
        public static int PLAYER_FRAMES_R = 2;
        public static int PLAYER_FRAMES_L = 2;
        public static int PLAYER_FRAMES_D = 2;
        public static int BOUNDING_OFFSET_X = 5;
        public static int BOUNDING_OFFSET_Y = 20;
        public const int LINK_HEARTS = 3;
        public const int LINK_HEARTS_WIDTH = 30;

        //Attacking metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public const float ATTACK_SECONDS = 0.5f;

        //Sprite metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int SPRITE_X = 350;
        public static int SPRITE_Y = 200;

        public static int SPRITE_X_START = 400;
        public static int SPRITE_Y_START = 200;

        public static int SCREEN_THRESHOLD = 1000;
        public static int RENDER_THRESHOLD = 50;
        public static int DAMAGE_THRESHOLD = 10;

        public const string STILL = "still";
        public const string MOVE = "move";
        public const string ATTACK = "attack";

        //Player metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public const float FLASHES_PER_SECOND = 8; //link flashes after damage
        public const float FLASHTIME = 1 / FLASHES_PER_SECOND;
        public const float INVINCIBILITY_SECONDS = 1; // after damage it goes invisible

        //Items metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12 };
        public static int NUM_ITEMS = 13;

        public static int FAIRY_TOTAL = 2;
        public static int HEART_TOTAL = 2;
        public static int RUPEE_TOTAL = 2;
        public static int TRIFORCE_TOTAL = 2;
        public static int ARROW_TOTAL = 1;
        public static int BOMB_TOTAL = 1;
        public static int BOOM_TOTAL = 1;
        public static int BOW_TOTAL = 1;
        public static int CLOCK_TOTAL = 1;
        public static int HEART_CONTAINER_TOTAL = 1;
        public static int KEY_TOTAL = 1;
        public static int MAP_TOTAL = 1;
        public static int SWORD_TOTAL = 1;

        public static int ARROW_R = 1;
        public static int ARROW_C = 4;

        public static int BOMB_R = 1;
        public static int BOMB_C = 1;
        public static int BOMB_ARRAY = 2;

        public static int AD_C = 1;

        public static int BOOM_R = 1;
        public static int BOOM_C = 1;

        public static int BOW_R = 1;
        public static int BOW_C = 1;

        public static int FD_TOTAL = 4;
        public static int FD_FRAMES_U = 8;
        public static int FD_FRAMES_R = 4;
        public static int FD_FRAMES_L = 4;
        public static int FD_FRAMES_D = 8;
        public static int FD_FRAMES_DEATH = 1;

        public static int CLOCK_R = 1;
        public static int CLOCK_C = 1;

        public static int FAIRY_R = 1;
        public static int FAIRY_C = 2;

        public static int FLAME_TOTAL = 2;
        public static int FLAME_FRAMES_U = 2;
        public static int FLAME_FRAMES_R = 2;
        public static int FLAME_FRAMES_L = 2;
        public static int FLAME_FRAMES_D = 2;
        public static int FLAME_FRAMES_DEATH = 1;
        public static int FLAME_C = 1;

        public static int HAND_TOTAL = 4;
        public static int HAND_FRAMES_U = 8;
        public static int HAND_FRAMES_R = 4;
        public static int HAND_FRAMES_L = 4;
        public static int HAND_FRAMES_D = 8;
        public static int HAND_FRAMES_DEATH = 1;
        public static int HAND_C = 1;

        public static int HEART_R = 1;
        public static int HEART_C = 2;

        public static int SKELETON_ARRAY = 2;

        public static int HEART_CONTAINER_R = 1;
        public static int HEART_CONTAINER_C = 1;

        public static int KEY_R = 1;
        public static int KEY_C = 1;

        public static int MAP_R = 1;
        public static int MAP_C = 1;

        public static int RUPEE_R = 1;
        public static int RUPEE_C = 2;

        public static int SWORD_R = 1;
        public static int SWORD_C = 4;
        public static int SWORD_SCALE = 3;

        public static int BOOMERANG_R = 1;
        public static int BOOMERANG_C = 4;

        public static int ORB_R = 1;
        public static int ORB_C = 3;


        public static int LINK_X = 300;
        public static int LINK_Y = 300;

        public static int BLOCK_DIMENSION = 48;
        public static int LINK_BOUNDING_DIMENSION = 30;


        public static int PLAYER_FRAMES = 4;
        public static int PLAYER_R = 1;

        public enum WEAPONS { bomb = 0, bow = 1, boom = 2, sword = 3 };

        //items vars


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


        //
        public const float BOOMERANG_RANGE = 50;
        public static int TRIFORCE_R = 1;
        public static int TRIFORCE_C = 2;



        //Enemy Sprite Sizes 
        public static int LARGER_SIZE = 2;
        public static int SMALLER_SIZE = 4;


        //Game Over Screen
        public static Vector2 CENTER = new Vector2(325, 400);
        public static Vector2 RETRY_POSITION = new Vector2(325, 400);
        public static Vector2 QUIT_POSITION = new Vector2(325, 500);
        public static int SELECTION_OFFSET = 300;


        //Option selection
        public enum OPTION
        {
            RETRY,
            QUIT

        }


        //For orbs

        public enum ORB_DIRECTION
        {
            TOP,
            MIDDLE,
           BOTTOM
        }

        // Room Transitioning
        public static float CAMERA_TRANSITION_SECONDS = 1.5f;
        public static int TRANSITION_OFFSET_X = 17;
        public static int TRANSITION_OFFSET_Y = -231;
    }
}

