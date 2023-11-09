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
        public static PausedScreen PausedScreen { get; set; }
        public  GameStateManager() {

            GameState = GameState.DefaultState;
            paused = false;
        }

        public void DrawGameState(SpriteBatch spritebatch)
        {
            switch (GameState) { 
                
                case GameState.DefaultState:
                    break;
                case GameState.PausedState:
                    PausedScreen.Draw(spritebatch);
                    break;
            
            }
        }

        public void UpdateGameState(SpriteBatch spritebatch)
        {
            switch (GameState)
            {

                case GameState.DefaultState:
                    break;
                case GameState.PausedState:
                    //UpdatePausedState();
                    break;

            }
        }

        public void LoadContent(GraphicsDevice graphics, ContentManager content)
        {
           PausedScreen = new PausedScreen(graphics, content);
           

        }
        private void PausedState()
        {
            
        }
        public void PauseGame() {
            paused = !paused;
            if (paused) { GameState = GameState.PausedState; } else { GameState = GameState.DefaultState; }
        }


        #region triforce
        private void TriforceState()
        {
            //TODO: 
            //either make this a method that is checked in player or add a method in collision response
        }
        #endregion
    }
}

public enum GameState { DefaultState, TriforceWinState, GameOverState, PausedState } 
