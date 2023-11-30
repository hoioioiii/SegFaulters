using System;
using Project1.HUD;
using static Project1.Constants;

namespace Project1
{
    public class PauseGame : ICommand
    {
        public void Execute()
        {
            Game1.GameStateManager.PauseGame();

            //check if not paused
            if (GameStateManager.GameState == GameState.DefaultState)
            {
                //Not sure if I switched the directions
                HeadsUpDisplay.StartScrolling(DIRECTION.up);
            }
            //check if paused
            else if (GameStateManager.GameState == GameState.PausedState)
            {
                HeadsUpDisplay.StartScrolling(DIRECTION.down);
            }
           
        }
    }
}

