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
    internal class KeyboardControllerPlayer : IController
    {
        private Game1 GAME_OBJ;

        //Keyboard states
        private KeyboardState CURR_KEYBOARD_STATE;
        private KeyboardState PREV_KEYBOARD_STATE;

        // Lists to register keys with commands
        private Dictionary<Keys, ICommand> MOVE_MAP { get; set; }
        private Dictionary<Keys, Keys> KEY_TO_KEY { get; set; }

        private Dictionary<Keys, ICommand> ITERATE_MAP { get; set; }

        ArraySegment<Keys> GET_PRESSED;
        public KeyboardControllerPlayer(Game1 game1)
        {
            //Generate maps for directions of player based off key input:
            GenerateKeyToKeyMap();
            GenerateMOVEMap();

            GAME_OBJ = game1;
        }

        //Call execute function of command registered to key
        public void ActionBasedOnInput(Keys CLEAN_KEY)
        {
            if (MOVE_MAP.ContainsKey(CLEAN_KEY) && CURR_KEYBOARD_STATE.IsKeyDown(CLEAN_KEY))
            {
                MOVE_MAP.GetValueOrDefault(CLEAN_KEY).Execute();

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
            //KEY_TO_KEY.Add(Keys.N, Keys.Z); //Handled elsewhere, needs to be modified to be handled here
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
            MOVE_MAP.Add(Keys.Down, new MoveDown());
            MOVE_MAP.Add(Keys.Up, new MoveUp());
            MOVE_MAP.Add(Keys.Left, new MoveLeft());
            MOVE_MAP.Add(Keys.Right, new MoveRight());

            MOVE_MAP.Add(Keys.S, new MoveDown());
            MOVE_MAP.Add(Keys.W, new MoveUp());
            MOVE_MAP.Add(Keys.A, new MoveLeft());
            MOVE_MAP.Add(Keys.D, new MoveRight());

            MOVE_MAP.Add(Keys.Z, new attackSword());
            MOVE_MAP.Add(Keys.N, new attackSword());
            MOVE_MAP.Add(Keys.E, new Damage());
            MOVE_MAP.Add(Keys.R, new QuitGame());
            MOVE_MAP.Add(Keys.I, new attackBoomerang());
            MOVE_MAP.Add(Keys.U, new attackBow());
            MOVE_MAP.Add(Keys.D0, new displayArrow());
        }

        public void Update()
        {
            PREV_KEYBOARD_STATE = CURR_KEYBOARD_STATE;

            CURR_KEYBOARD_STATE = Keyboard.GetState();
            
            GetInputType();
        }
    }
}
