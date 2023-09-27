using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    internal class KeyBoardController : IController
    {
        private Game1 GAME_OBJ;
        private KeyboardState CURR_KEYBOARD_STATE;
        private KeyboardState PREV_KEYBOARD_STATE;

        //This is what we will end up using when we implement ICOMMAND
        //private Dictionary<Keys, ICommand> MOVE_MAP { get; set; }
        private Dictionary<Keys, ICommand> MOVE_MAP { get; set; }
        private Dictionary<Keys, Keys> KEY_TO_KEY { get; set; }

        private Dictionary<Keys, ICommand> ITERATE_MAP { get; set; }

        ArraySegment<Keys> GET_PRESSED;
        public KeyBoardController(Game1 game1) { 
        

              //Generate teh Double linked lists




              //GENERATE MAPS:
              GenerateKeyToKeyMap();
              GenerateMOVEMap();
              IteratorMap();

                GAME_OBJ = game1;
                
        }
        public void ActionBasedOnInput(Keys CLEAN_KEY)
        {


           
            if (MOVE_MAP.ContainsKey(CLEAN_KEY) && CURR_KEYBOARD_STATE.IsKeyDown(CLEAN_KEY) && PREV_KEYBOARD_STATE.IsKeyUp(CLEAN_KEY))
            {
                MOVE_MAP.GetValueOrDefault(CLEAN_KEY).Execute();

            }else if (ITERATE_MAP.ContainsKey(CLEAN_KEY) && CURR_KEYBOARD_STATE.IsKeyDown(CLEAN_KEY) && PREV_KEYBOARD_STATE.IsKeyUp(CLEAN_KEY))
            {
                ITERATE_MAP.GetValueOrDefault(CLEAN_KEY).Execute();
            }

        }

        public void GetInputType()
        {
            GET_PRESSED = CURR_KEYBOARD_STATE.GetPressedKeys();
            foreach (Keys key in GET_PRESSED)
            {
                Keys CLEAN_KEY = CleanInput(key);
                ActionBasedOnInput( CLEAN_KEY);
            }

    
        }

        /*
         * When there are multiple keys that produce the same input, reduce those keys to 1 tyoe of input when checking
         */
        public void GenerateKeyToKeyMap()
        {
            KEY_TO_KEY = new Dictionary <Keys, Keys>();
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

        public Keys CleanInput(Keys input)
        {
            if (!KEY_TO_KEY.ContainsKey(input))
            {
                return input;
            }

           foreach (KeyValuePair<Keys, Keys> KEY  in KEY_TO_KEY)
            {
                if (KEY.Key == input)
                {
                    return KEY.Value;
                }
            }
           return input;
        }


        public void GenerateMOVEMap()
        {
            MOVE_MAP = new Dictionary<Keys, ICommand>();
            //MOVE_MAP.Add(Keys.Down, //Call Command State);
            //MOVE_MAP.Add(Keys.Up, //Call Command State);
            //MOVE_MAP.Add(Keys.Left, //Call Command State);
            //MOVE_MAP.Add(Keys.Right, //Call Command State);
            //MOVE_MAP.Add(Keys.E, //Call Command State);
            //MOVE_MAP.Add(Keys.R, //Call Command State);
            //MOVE_MAP.Add(Keys.D0, //Call Command State);
            //MOVE_MAP.Add(Keys.D1, //Call Command State);
            //MOVE_MAP.Add(Keys.D2, //Call Command State);
            //MOVE_MAP.Add(Keys.D3, //Call Command State);
            //MOVE_MAP.Add(Keys.D4, //Call Command State);
            //MOVE_MAP.Add(Keys.D5, //Call Command State);
            //MOVE_MAP.Add(Keys.D6, //Call Command State);
            //MOVE_MAP.Add(Keys.D7, //Call Command State);
            //MOVE_MAP.Add(Keys.D8, //Call Command State);
            //MOVE_MAP.Add(Keys.D9, //Call Command State);
            //MOVE_MAP.Add(Keys.Tab, //Call Command State);

        }


        public void IteratorMap()
        {
           ITERATE_MAP = new Dictionary<Keys, ICommand>();
            //ITERATE_MAP.Add(Keys.T, //Call Command State);)
            //ITERATE_MAP.Add(Keys.Y, //Call Command State);)
            //ITERATE_MAP.Add(Keys.U, //Call Command State);)
            //ITERATE_MAP.Add(Keys.I, //Call Command State);)
            ITERATE_MAP.Add(Keys.U, new EntityIterateBackCommand());
            ITERATE_MAP.Add(Keys.I, new EntityIterateForwardCommand());

        }

        public void Update()
        {
            PREV_KEYBOARD_STATE = CURR_KEYBOARD_STATE;

            CURR_KEYBOARD_STATE = Keyboard.GetState();
            GetInputType();
        }
    }
}
