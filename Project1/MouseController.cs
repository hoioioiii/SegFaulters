using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using static Project1.ICommand;

namespace Project1
{
	public class MouseController : IController
	{
        private Game1 GAME_OBJ;
        private ICommand action;

        private ButtonState prev_state;
        bool buttonDown; 
        public MouseController(Game1 game1)
		{
            GAME_OBJ = game1;
            buttonDown = false;
        }

        public void Update()
		{


            // Update has been fixed to where if the mouse button is pressed, only one exectute is called and doesn't get called again until 
            // all mouse buttons have been realeased. 
            if(!buttonDown)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {



                    action = new RoomIterateBack();
                    action.Execute();
                    buttonDown = true;
                }
                else if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    action = new RoomIterateForward();
                    action.Execute();
                    buttonDown = true;
                }
            } else
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released && Mouse.GetState().RightButton == ButtonState.Released)
                {
                    buttonDown = false;
                }
            }
           

        }

        public void GetInputType()
        {

        }

        public void ActionBasedOnInput(Keys Cleaned_Key)
        {

        }
    }
}

