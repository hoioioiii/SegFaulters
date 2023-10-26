using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using static Project1.ICommand;

namespace Project1
{
    internal class KeyBoardController : IController
    {
        private Game1 GAME_OBJ;
        private KeyboardState CURR_KEYBOARD_STATE;
        private KeyboardState PREV_KEYBOARD_STATE;

        private Dictionary<Keys, ICommand> MOVE_MAP { get; set; }
        private Dictionary<Keys, Keys> KEY_TO_KEY { get; set; }

        private Dictionary<Keys, ICommand> ITERATE_MAP { get; set; }

        ArraySegment<Keys> GET_PRESSED;

        public KeyBoardController(Game1 game1)
        {
            //Generate maps for directions of player based off key input:
            GenerateKeyToKeyMap();
            GenerateMOVEMap();
            IteratorMap();
            GAME_OBJ = game1;
                
        }

        // Call execute function of command registered to key
        public void ActionBasedOnInput(Keys CLEAN_KEY)
        {

            if (MOVE_MAP.ContainsKey(CLEAN_KEY) && CURR_KEYBOARD_STATE.IsKeyDown(CLEAN_KEY) && PREV_KEYBOARD_STATE.IsKeyUp(CLEAN_KEY))
            {
                MOVE_MAP.GetValueOrDefault(CLEAN_KEY).Execute();

            }
            else if (ITERATE_MAP.ContainsKey(CLEAN_KEY) && CURR_KEYBOARD_STATE.IsKeyDown(CLEAN_KEY) && PREV_KEYBOARD_STATE.IsKeyUp(CLEAN_KEY))
            {
                ITERATE_MAP.GetValueOrDefault(CLEAN_KEY).Execute();
            }
        }


        //Iterate over pressed keys and calls their command
        public void GetInputType()
        {
            GET_PRESSED = CURR_KEYBOARD_STATE.GetPressedKeys();
            foreach (Keys key in GET_PRESSED)
            {
                Keys CLEAN_KEY = CleanInput(key);
                ActionBasedOnInput(CLEAN_KEY);
            }

    
        }

        //Generates key map where every key will be mapped to a unique type of input
        public void GenerateKeyToKeyMap()
        {
            KEY_TO_KEY = new Dictionary<Keys, Keys>();

            
            KEY_TO_KEY.Add(Keys.A, Keys.Left);
            KEY_TO_KEY.Add(Keys.W, Keys.Up);
            KEY_TO_KEY.Add(Keys.S, Keys.Down);
            KEY_TO_KEY.Add(Keys.D, Keys.Right);
            
            KEY_TO_KEY.Add(Keys.N, Keys.Z);
            KEY_TO_KEY.Add(Keys.Q, Keys.R);
            KEY_TO_KEY.Add(Keys.NumPad0, Keys.D0);
            KEY_TO_KEY.Add(Keys.NumPad1, Keys.D1);
            KEY_TO_KEY.Add(Keys.NumPad2, Keys.D2);
            KEY_TO_KEY.Add(Keys.NumPad3, Keys.D3);
            KEY_TO_KEY.Add(Keys.NumPad4, Keys.D4);
            KEY_TO_KEY.Add(Keys.NumPad5, Keys.D5);
            KEY_TO_KEY.Add(Keys.NumPad6, Keys.D6);
            KEY_TO_KEY.Add(Keys.NumPad7, Keys.D7);
            KEY_TO_KEY.Add(Keys.NumPad8, Keys.D8);
            KEY_TO_KEY.Add(Keys.NumPad9, Keys.D9);
        }

        //Returns the unique type of input mapped to the input key
        public Keys CleanInput(Keys input)
        {
            if (!KEY_TO_KEY.ContainsKey(input))
            {
                return input;
            }

            foreach (KeyValuePair<Keys, Keys> KEY in KEY_TO_KEY)
            {
                if (KEY.Key == input)
                {
                    return KEY.Value;
                }
            }
           return input;
        }

        //Generates map where every move is mapped to a key
        public void GenerateMOVEMap()
        {
            MOVE_MAP = new Dictionary<Keys, ICommand>();

            /*
             *The functionality for this has been moved to KeyboardControllerPLayer
            //doesnt work
            //directions
            MOVE_MAP.Add(Keys.Up, new MoveUp());
            MOVE_MAP.Add(Keys.Left, new MoveLeft());
            MOVE_MAP.Add(Keys.Right, new MoveRight());
            MOVE_MAP.Add(Keys.Down, new MoveDown());

            //neither does this one
            //directions
            MOVE_MAP.Add(Keys.W, new MoveUp());
            MOVE_MAP.Add(Keys.A, new MoveLeft());
            MOVE_MAP.Add(Keys.D, new MoveRight());
            MOVE_MAP.Add(Keys.S, new MoveDown());
            */

            //damage
            MOVE_MAP.Add(Keys.E, new TakeDamage());
            MOVE_MAP.Add(Keys.R, new QuitGame());
            //weapon attacks
            MOVE_MAP.Add(Keys.I, new attackBoomerang());
            MOVE_MAP.Add(Keys.U, new attackBow());

            //list of items to be displayed
            MOVE_MAP.Add(Keys.D0, new displayArrow());
            MOVE_MAP.Add(Keys.D1, new displayBomb());
            MOVE_MAP.Add(Keys.D2, new displayBow());
            MOVE_MAP.Add(Keys.D3, new displayClock());
            MOVE_MAP.Add(Keys.D4, new displayFairy());
            MOVE_MAP.Add(Keys.D5, new displayHeartContainer());
            MOVE_MAP.Add(Keys.D6, new displayHeart());
            MOVE_MAP.Add(Keys.D7, new displayKey());
            MOVE_MAP.Add(Keys.D8, new displayMap());
            MOVE_MAP.Add(Keys.D9, new displayRupee());
            MOVE_MAP.Add(Keys.OemMinus, new displaySword());
            MOVE_MAP.Add(Keys.OemPlus, new displayTriforce());
        }

        public void IteratorMap()
        {
            ITERATE_MAP = new Dictionary<Keys, ICommand>();
            
            ITERATE_MAP.Add(Keys.T, new BlockPrevious());
            ITERATE_MAP.Add(Keys.Y, new BlockNext());
            ITERATE_MAP.Add(Keys.O, new EntityIterateBackCommand());
            ITERATE_MAP.Add(Keys.P, new EntityIterateForwardCommand());

            ITERATE_MAP.Add(Keys.B, new RoomIterateBack());
            ITERATE_MAP.Add(Keys.M, new RoomIterateForward());

        }

        //Updates keyboard state
        public void Update()
        {
            PREV_KEYBOARD_STATE = CURR_KEYBOARD_STATE;

            CURR_KEYBOARD_STATE = Keyboard.GetState();
            
            GetInputType();
        }
    }
}