using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
namespace Project1
{
    public class ExecuteSelection : ICommand
    {
        public void Execute()
        {
            Game1.selectionManager.SelectOption();
            switch (Game1.selectionManager.selected)
            {
                case OPTION.RETRY:
                    Player.UseItem(ITEMS.Triforce);
                    new ResetLink().Execute();
                    GameStateManager.GameState = GameState.DefaultState;
                    MediaPlayer.Resume();
                    break;

                case OPTION.QUIT:
                    new QuitGame().Execute();
                    break;
            }


        }
    }
}
