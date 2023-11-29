using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Commands
{
    public class GameRestart : ICommand
    {
        public void Execute()
        {
            GameOverScreen.GameOverSoundEffecct();
            LevelLoader.Load();

            Player.itemInventory = new int[]{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0};
        }
    }
}
