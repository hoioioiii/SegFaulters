using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Project1.HUD;
using static Project1.Constants;

namespace Project1
{
    public class PlayerFullReset
    {

        public static void ResetEntireGame()
        {

            Game1.GameObjManager.clearAll();
            Player.Initialize();
            RoomManager.Load();
            //GameStateManager.GameState = GameState.DefaultState;
            
            Game1.gameStatePlaying = true;
            Game1.timer = 60 * 3;

            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(BGM);           
            
            Game1.hudDisplay = new HeadsUpDisplay(Game1.graphics,Game1.contentLoader);
        }
    }
}
