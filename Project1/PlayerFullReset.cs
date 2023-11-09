using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class PlayerFullReset
    {


        public static void ResetEntireGame()
        {

            Game1.GameObjManager.clearAll();
            Player.Initialize();
            RoomManager.Load();
            Game1.gameStatePlaying = true;

        }
    }
}
