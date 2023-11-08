using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    /* Game state manager should be in charge of continuously checking each case that could change the state and then
     * precisley change it.
     * 
     * Current possible game states: DefaultState, TriforceWinState, GameOverState, PausedState.
     */
    public class GameStateManager
    {
        bool paused;
        public static GameState GameState { get; set; }
        Texture2D pausebutton;
        private static Vector2 position;
        public  GameStateManager() {

            GameState = GameState.DefaultState;
            paused = false;
            //static location for pause button
            //TODO: throw into constants 
            position = new Vector2 (200, 200);
        }

/*        public void UpdateGameState() {
          //  TriforceState();
          //  PausedState();
          //  GameOverState();
        }
*/

        public void DrawGameState(SpriteBatch spritebatch)
        {
            switch (GameState) { 
                
                case GameState.DefaultState:
                    break;
                case GameState.PausedState:
                    DrawPausedState(spritebatch);
                    break;
            
            }
        }

        private void DrawPausedState(SpriteBatch spritebatch)
        {
            
        }

        public void LoadContent(ContentManager content)
        {
           // Texture2D pausebutton = content.Load<Texture2D>(assetName: "PAUSEICON");

        }
        private void PausedState()
        {
            
        }
        public void PauseGame() {
            paused = !paused;
            if (paused) { GameState = GameState.PausedState; } else { GameState = GameState.DefaultState; }
        }

        

        private void TriforceState()
        {
            //TODO: 
            //either make this a method that is checked in player or add a method in collision response
        }
    }
}

public enum GameState { DefaultState, TriforceWinState, GameOverState, PausedState } 
