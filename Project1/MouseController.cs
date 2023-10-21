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
        public MouseController(Game1 game1)
		{
            GAME_OBJ = game1;
        }

        public void Update()
		{




            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {

                

                action = new RoomIterateBack();
                action.Execute();
            }
            else if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                action = new RoomIterateForward();
                action.Execute();
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

