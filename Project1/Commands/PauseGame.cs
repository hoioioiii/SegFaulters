using System;
using static Project1.Constants;

namespace Project1
{
    public class PauseGame : ICommand
    {
        public void Execute()
        {
            Game1.GameStateManager.PauseGame();

            /*
            if (Game1.GameStateManager.)
            {

            }
            */
        }
    }
}

