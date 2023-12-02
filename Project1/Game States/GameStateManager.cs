using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.HUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

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
        public static TriforceWinningScreen TriforceWinningScreen { get; set; }
        public static GameOverScreen GameOverScreen { get; set; }
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
                case GameState.TriforceWinState:
                    TriforceWinningScreen.Draw(spritebatch);
                    break;
                case GameState.GameOverState:
                    GameOverScreen.Draw(spritebatch);
                    break;

            }
        }

        public void UpdateGameState()
        {
            switch (GameState)
            {
                
                case GameState.DefaultState:
                    checkTriforceState();
                    checkGameOverState();
                    break;
                case GameState.PausedState:
                    PausedScreen.Update();
                    break;
                case GameState.TriforceWinState:
                    TriforceWinningScreen.Update();
                    break;
                case GameState.GameOverState:
                    GameOverScreen.Update();
                    break;
            }
        }



        public void LoadContent(GraphicsDevice graphics, ContentManager content)
        {
           PausedScreen = new PausedScreen(graphics, content);
           TriforceWinningScreen = new TriforceWinningScreen(graphics, content);
            GameOverScreen = new GameOverScreen(graphics, content);


        }
        private void checkTriforceState()
        {
            if (Inventory.itemInventory[(int)ITEMS.Triforce] == 1)
            {
                new GameRestart().Execute();
                GameState = GameState.TriforceWinState;
                TriforceWinningScreen.TriForceSoundEffect();
            }
        }
        private void checkGameOverState()
        {
            if (HealthDisplay.linkHealth.IsDead())
            {
                GameState = GameState.GameOverState;

                ICommand restart = new GameRestart();
                restart.Execute();
                 
            }
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
