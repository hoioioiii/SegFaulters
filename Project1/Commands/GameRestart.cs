using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1.Commands
{
    public class GameRestart : ICommand
    {
        public void Execute()
        {
            GameOverScreen.GameOverSoundEffecct(); //game over sound
            LevelLoader.Load(); //re-parse the XML sheet

            //temporary solution
            Inventory.itemInventory = new int[]{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0};

            //respawn the player at the bottom
            Player.setPosition(RESPAWN_UP);
        }
    }
}
