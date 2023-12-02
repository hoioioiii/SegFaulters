using Microsoft.Xna.Framework;

using System;

using static Project1.Game1;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Project1
{
    public class Constants
    {
        public static Song BGM, gameOver, gameOverStateSound;

        //Change this later to be all caps
        public static SoundEffect winningStateSound, addUI, bombBlow, bombDrop, boomerang, cling, death, doorUnlock, puzzleSolved, dragon, dragon2, dragon3, enemyDie, enemyHit, fire, flame, bigItemGet, smallItemGet, heartGet, rupeeGet, linkHurt, lowHealth, plus, plusPlus, secret, stairs, subtractUI, sword;

        public static String XMLPATH = "..\\..\\..\\xmlTest2.xml";

        //MISC ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int OPTION_ARRAY_SIZE = 2;
        public static int RESET_TIME = 60 * 3;
        public static int COL_TOTAL_MAP = 12;
        public static int ROW_TOTAL_MAP = 7;

        //Directions->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public enum DIRECTION { right = 0, left = 1, up = 2, down = 3, none = -1 };

        public enum DOORTEXTURES { DOORWEST = 0, DOOREAST = 1, DOORSOUTH = 2, DOORNORTH = 3, LOCKDOORNORTH = 4, LOCKDOORSOUTH = 5, LOCKDOORWEST = 6, LOCKDOOREAST = 7, TUNNELDOORNORTH = 8, TUNNELDOORSOUTH = 9 };

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

        public static int BG_START_X = 17;
        public static int BG_START_Y = -22;
        
        public static int SCREEN_WIDTH = 800;
        public static int SCREEN_WIDTH_LOWER = 0;
        public static int SCREEN_HEIGHT_UPPER = 400;
        public static int SCREEN_HEIGHT_LOWER = 0;
        public static int PAUSED_STATE_YCOORD = ((SCREEN_HEIGHT / 3) * 2);
        //DOOR INFO
        public static int DOOR_NORTH_X = 350;
        public static int DOOR_NORTH_Y = 14;
        public static int DOOR_SOUTH_X = 352;
        public static int DOOR_SOUTH_Y = 409;
        public static int DOOR_WEST_X = 53;
        public static int DOOR_WEST_Y = 190;
        public static int DOOR_EAST_X = 688;
        public static int DOOR_EAST_Y = 190;

        public static int HORIZONTAL_DOOR_WIDTH = 100;
        public static int HORIZONTAL_DOOR_HEIGHT = 60;
        public static int VERTICAL_DOOR_WIDTH = HORIZONTAL_DOOR_HEIGHT;
        public static int VERTICAL_DOOR_HEIGHT = HORIZONTAL_DOOR_WIDTH;

        public static int VERTICAL_EAST_WIDTH = 63;
        public static int VERTICAL_EAST_HEIGHT = 107;

        //HUD STUFF ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int SCREEN_HEIGHT = (int)(480 * 1.75);
        public static int HUD_HEIGHT = SCREEN_HEIGHT / 3;
        public static int HUD_SECTION_WIDTH = SCREEN_WIDTH / 3;
        public static int SCROLL_OFFSET = 17;
        public enum PAUSE_STATE { active = 0, paused = 1 };

        public static float FULL_MENU_OFFSET = (SCREEN_HEIGHT / 3) * 2;
        public static int HUD_COUNT_OFFSET = HUD_HEIGHT / 4;
        public static int ITEM_SPRITE_OFFSET = HUD_SECTION_WIDTH / 9;
        public static int INNER_OFFSET_SLICE_X = 48;
        public static int INNER_OFFSET_SLICE_Y = 36;
        public static int INNER_WIDTH_SLICE = 24;
        public static int INNER_HEIGHT_SLICE = 18;

        public static int MAP_ROW_HEIGHT = (HUD_HEIGHT - 100) / 6;
        public static int MAP_START_Y = 103;
        public static int ROOM_WIDTH = 42;
        public static int STARTING_ROOM_X = (HUD_SECTION_WIDTH / 3) + 5;
        public static int TOTAL_ROOMS = 18;
        public static int STARTING_ROOM_Y = MAP_START_Y + (5 * MAP_ROW_HEIGHT);

        public static int POSITION_INDICATOR_SLICE_X = 8;
        public static int POSITION_INDICATOR_SLICE_Y = 10;
        public static int HUD_SECTION_THIRD = HUD_SECTION_WIDTH / 3;
        public static int HUD_SECTION_FOURTH = HUD_SECTION_WIDTH / 4;
        public static int HUD_HEIGHT_THIRD = HUD_HEIGHT / 3;
        public static int KEY_OFFSET = 5;
        public static int SPRITE_SIZE = 2;
        //paused inventory STUFF ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int[] ITEM_INVENTORY = { 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 };

        public static int MAPOFFSET = 70;
        public static int inventoryTextOffsetX = 130;
        public static int inventoryTextOffsetY = 500;
        public static int useBtextOffsetX = 100;
        public static int useBtextOffsetY = 300;
        public static int smallItemBoxTextOffsetX = 190;
        public static int smallItemBoxTextOffsetY = 430;
        public static int itemInventoryBoxTextOffsetX = 400;
        public static int itemInventoryBoxTextOffsetY = 450;

        public static int itemInventoryBoxOffSet = 18;
        public static int itemInventoryBoxOffSet2 = 4;
        public static int itemInventoryBoxOffSet3 = 16;
        public static int itemInventoryBoxScaleOffSet = 10;

        public static int inventoryboxWidth;
        public static int inventoryboxHeight;


        public static int currentItemIndex = 0;
        public static int trueTotalItemCount = 0;

        public static int inventoryRows = 2;
        public static int inventoryCols = 4;
        public static int selectorSmoother = 0;
        //Stats display->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int STATS_WIDTH_OFFSET1 = 4;
        public static int STATS_WIDTH_OFFSET2 = 3;
        public static int STATS_WIDTH_MULTIPLIER = 2;
        //paused map STUFF ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int compassPauseTextX = 130;
        public static int compassPauseTextY = 100;
        public static int mapItemX = 210;
        public static int mapItemY = 180;
        public static int mapPauseTextX = 180;
        public static int mapPauseTextY = 230;
        public static int pausedMapX = 410;
        public static int pausedMapY = 230 + MAPOFFSET;
        public static int spriteScaleOffset1 = 100;
        public static int greenBoxOffset = 3;
        public static int locationDisplayOffSetX = 470;
        public static int locationDisplayOffSetY = 280 - MAPOFFSET;
        public static int totalRooms = 18;
        //HEALTH STUFF ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int HEALTH_HUD_WIDTH = HUD_SECTION_WIDTH * 2;
        public static int HEALTH_HUD_HEIGHT = (HUD_HEIGHT / 3);
        public static float HEALTH_ROW = 30f;
        public static int ENTITY_HEARTS = 5;
        public static int DAMAGE_HALF_HEART = 2;
        public static int DAMAGE_FULL_HEART = 4;
        public static int MAX_FRAGMENTS = 4;
        public static int ATTACK_INCREASE = 1;
        public static int DEFAULT_FULL_HEART = 4;
        public static int DEFAULT_HALF_HEART = 2;
        public static int PAUSED_STATE_OFFSET = 3;
        public static int PAUSED_STATE_MULT = 2;

        //STATS metrics->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int STATS_HEIGHT = HUD_HEIGHT / 2;
        public static int STATS_WIDTH = HUD_SECTION_WIDTH;
        public static int COOL_DOWN = 10;
        
        public enum USABLE_ITEM { boomerang = 0, bomb = 1, beehive = 2, bow = 3 };

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
        public static string ATTACK = "ATK";
        public static string SPEED = "SPD";
        public static string CRITICAL_HIT = "CRIT";
        public static string DEFENSE = "DEF";
        public static string STAMINA = "SMNA";
        public static int STATS_TOTAL = 3;
        public static int DEFAULT_SPEED = 5;
        public enum WEAPON_ATTACK_AMOUNT { swordAmount = 2, bombAmount = 3, bowAmount = 1, boomerangAmount = 1, beehiveAmount = 1 };
        //Attacking metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public const float ATTACK_SECONDS = 0.5f;

        //Boomerang Sprite Player Metrics->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static int ON_WAY_TIME = 2000;
        public static int DISTANCE_OFFSET = 10;
        public static int TOT_FRAME_DEFAULT = 4;
        public static int TOT_FPS_DEFAULT = 30;

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
        public const string ATTACK_LINK = "attack";

        //Player metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public const float FLASHES_PER_SECOND = 8; //link flashes after damage
        public const float FLASHTIME = 1 / FLASHES_PER_SECOND;
        public const float INVINCIBILITY_SECONDS = 1; // after damage it goes invisible

        //Items metrics ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12, Beehive = 13 };
        public static int NUM_ITEMS = 14;

        public static (int, int) INVALID_ITEM = (-1, -1);

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

        public static int BEEHIVE_TOTAL = 1;
        public static int BEEHIVE_ARRAY = 1;
        public static int BEE_ARRAY = 4;
        public static int HONEYCOMB_ARRAY = 5;


        public static int LINK_X = 300;
        public static int LINK_Y = 300;

        public static int BLOCK_DIMENSION = 48;
        public static int LINK_BOUNDING_DIMENSION = 30;


        public static int PLAYER_FRAMES = 4;
        public static int PLAYER_R = 1;

        public enum WEAPONS { bomb = 0, bow = 1, boom = 2, sword = 3 };

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

        //SMART AI-------------------------------------
        public enum SMARTAI_USER
        {
            ENTITY,
            WEAPON,
            SPIKE
        }


        //Enemy Smart AI Range Detection---------------------
        public enum RangeTypeToMovement
        {
            //Seek if the player is inside or on the circle
            SEEK,
            PASSIVE //if player is outside of the circle
        }

        public static int RANGE_RADIUS = 150;
        public static int AGGRO_SPD = 2;
        public static int CONTACT_POINT = 10;
        public static int RADIUS_FORMULA_POWER_OF_2 = 2;

        //WEAPON MOVEMENT TYPE SMART AI--------------------
        public static int WEAPON_AGGRO_SPD = 2;

        //New Weapons--BEES Laucher:
        public static int WEAPON_INITAL_SPD = 2;
        public static int ROCKET_FIELD = 100;
        public static int BEES_DETECTION_FEILD_WIDTH = 200;
        public static int BEES_DETECTION_FEILD_HEIGHT = 200;
        public static int CENTER_RATIO = 2;
        //Weapons Enums:
        public enum WEAPON_TYPE
        {
            SWORD,
            ORBS,
            ARROW,
            BOMB,
            BOOMERANGE,
            BEES
        }



        public enum SPIKE_ID
        {
            TOP_LEFT,
            TOP_RIGHT,
            BOTTOM_LEFT,
            BOTTOM_RIGHT
        }

        public static (int, int) TL_SPIKE = (0, 0);
        public static (int, int) TR_SPIKE = (0, 11);
        public static (int, int) BL_SPIKE = (6, 0);
        public static (int, int) BR_SPIKE = (6,11);

        public static int SPIKE_WIDTH = 50;
        public static int SPIKE_HEIGHT = 50;
        public static int DOUBLE = 2;

        public static int SPIKE_AXIS_X = 0;
        public static int SPIKE_AXIS_Y = 1;

        public static int BEE_WIDTH = 15;
        public static int BEE_HEIGHT = 15;
        public static int ITEM_DROP_OFFSET = 50;


        public static int ORB_TIME_ALLOWED = 1000;
        public static int MAX_ORBS = 3;
        public static int TOP_ORB = 0;
        public static int MID_ORB = 1;
        public static int BOT_ORB = 2;
        public static int SPRITE_SCALE = 3;
        public static int MAX_INVENTORY_SLOTS = 9;
        public static int ROOMS_ENTERED = 19;
        public static int BOOMERANG_LOC = 0;
        public static int BEEHIVE_LOC = 2;
        public static int BOW_LOC = 3;

        public static int DUMMY_NUMBER = 200;
        public static int ENVIRONMENT_START = 2;
        public static int DRAGON_POSITION = 11;
        public static int FISH_POS = 12;
        public static int CARPET_POS = 7;
        public static int BRICK_POS = 2;
        public static int WATER_POS = 13;
        public static int STARICASE_POS = 6;
        public static int BLACKROOM_POS = 14;
        public static int DEFAULT_POS = 10;
        public static int ROOMTEXURE_TOTAL = 17;


        public static string RETRY = "RETRY";
        public static string QUIT = "QUIT";
        public static string GAMEOVER = "Game Over";
        public static string ZELDAFONT = "ZeldaFont";
        public static string WINNER = "You Win!";



        public static string ROOM = "Room";
        public static string ENEMIES = "Enemies";
        public static string ENVIRONMENT = "Environment";
        public static string ITEMS_STRING = "Items";
        public static string XLOC = "xLoc";

        public static string YLOC = "yLoc";
        public static string DROPS = "Drops";
        public static string NAME = "Name";
        public static string QUANITY = "quantity";
        public static string WALLS = "Walls";
        public static string DOORS = "Doors";
        public static string BLOCKS = "Blocks";
        public static string ID = "id";
        public static string DESTINATION_ROOM = "DestinationRoom";
        public static string LOCKED = "Locked";
        public static string IS_TUNNEL = "isTunnel";
        public static string DEAD = "DEAD";
     
    }
}

