using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
using System;
using System.Text;
using System.Threading;
using Project1.HUD;
using Project1.Health;
using Microsoft.Xna.Framework.Media;
using System.Reflection.Metadata;

namespace Project1
{
    public class Game1 : Game
    {
        public static Game1 self;
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;
        public static GraphicsDevice graphics;

        public static IActiveObjects GameObjManager;
        private IDraw DrawManager;
        private IUpdate UpdateManager;
        public static GameStateManager GameStateManager;
        private ArrayList ControllerList;

        public static IHUD hudDisplay;
        public static IListIterate EnvironmentIterator;
        public static GameTime deltaTime;

        //these 3 need to handled by game state manager
        public static bool gameStatePlaying;
        public static OptionSelector selectionManager;
        public static int timer;


        //Zelda txt font
        private SpriteFont font;
        public static bool roomIsTransitioning;
        public static bool HUDisTransitioning;


        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            selectionManager = new OptionSelector();
            _graphics.PreferredBackBufferHeight = (int)(480 * 1.75);
            Content.RootDirectory = "Content";
            contentLoader = Content;
            IsMouseVisible = true;
            self = this;

            gameStatePlaying = true;

            //temp fix -- fix later
            timer = 60 * 3;
        }


        public void Quit() => Exit();




        protected override void Initialize()
        {
            
            KeyboardState state = Keyboard.GetState();
            ControllerList = new ArrayList();
            ControllerList.Add(new KeyBoardController(this));
            ControllerList.Add(new KeyboardControllerPlayer(this));
            ControllerList.Add(new MouseController(this));

            //move out to keyboard
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            GameObjManager = new ActiveObjects();
            UpdateManager = new UpdateManager();
            DrawManager = new DrawManager();
            GameStateManager = new GameStateManager();

            Player.Initialize();
            Camera.Initialize();


           


            base.Initialize();
        }

        //clean
        protected override void LoadContent()
        {
            PositionGrid.createMap();
            RoomTransition.LoadTextures(Content);

            graphics = GraphicsDevice;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("ZeldaFont");
            
            AudioManager.LoadContent(Content);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(BGM);

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
          
            EnvironmentIterator = new EnvironmentIterator(this);
            GameStateManager.LoadContent(GraphicsDevice, Content);

            Player.LoadContent(Content);

            //Load background
            EnvironmentLoader.LoadContent(Content);
            
            //Load XML File
            LevelLoader.Load();
            hudDisplay = new HeadsUpDisplay(GraphicsDevice, Content);

         
        }


        
        protected override void Update(GameTime gameTime)
        {
     
            deltaTime = gameTime;

            if (roomIsTransitioning)
            {
                Camera.CameraTransition(gameTime, true);
            }
            else if (HUDisTransitioning)
            {
                // if the HUD is transitioning down, use the camera transition offset
                if (GameStateManager.GameState == GameState.DefaultState)
                {
                    Camera.CameraTransitionOffset(gameTime, false, 0, ROOM_FRAME_HEIGHT);                   
                }
                else
                {
                    Camera.CameraTransition(gameTime, false);
                }             
            }
            else
            {
                foreach (IController controller in ControllerList)
                {
                    controller.Update();
                }

                GameStateManager.UpdateGameState();
                if (GameStateManager.GameState == GameState.DefaultState)
                {
                    hudDisplay.Update(false);


                    //this needs to be moved into update manager
                    Player.Update(gameTime);
                    EnvironmentLoader.Update();
                    UpdateManager.Update();


             

                }
                else if (GameStateManager.GameState == GameState.PausedState)
                {
                    hudDisplay.Update(true);
                    
                } 
                else if (GameStateManager.GameState == GameState.TriforceWinState)
                {
                    //needed for keyboard
                    Player.Update(gameTime);
                } 
                else if (GameStateManager.GameState == GameState.GameOverState)
                {
                    //needed for keyboard
                    Player.Update(gameTime);
                }

            }

            base.Update(gameTime);
        }


       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Non-HUD
            if (roomIsTransitioning)
            {
                _spriteBatch.Begin(transformMatrix: Camera.Transform);
                RoomTransition.Draw(_spriteBatch);
                EnvironmentLoader.Draw(_spriteBatch);
               
            }
            else if (HUDisTransitioning)
            {
                _spriteBatch.Begin(transformMatrix: Camera.Transform);
                EnvironmentLoader.Draw(_spriteBatch);
                Player.Draw(gameTime, _spriteBatch);
                hudDisplay.Draw(_spriteBatch);
                DrawManager.Draw();
                //PausedScreen.Draw(_spriteBatch);
            }
            else if (GameStateManager.GameState == GameState.PausedState)
            {
                _spriteBatch.Begin(transformMatrix: Camera.Transform);
                hudDisplay.Draw(_spriteBatch);
                //PausedScreen.Draw(_spriteBatch);
            }
            else
            {
                _spriteBatch.Begin();
                GameStateManager.DrawGameState(_spriteBatch);

                if (GameStateManager.GameState == GameState.DefaultState)
                {
                    EnvironmentLoader.Draw(_spriteBatch);


                    //needs to be given to draw manager
                    Player.Draw(gameTime, _spriteBatch);

                    DrawManager.Draw();

                }
                else if (GameStateManager.GameState == GameState.PausedState)
                {
                    hudDisplay.Draw(_spriteBatch);
                }
                else if (GameStateManager.GameState == GameState.TriforceWinState)
                {
                    //placeholder for future implementation
                }
                else if (GameStateManager.GameState == GameState.GameOverState)
                {
                    //placeholder for future implementation
                }
            }

            _spriteBatch.End();

            // Attach HUD to screen
            if (GameStateManager.GameState != GameState.GameOverState && GameStateManager.GameState != GameState.PausedState && !HUDisTransitioning && GameStateManager.GameState != GameState.TriforceWinState)
            {
                _spriteBatch.Begin();
                hudDisplay.Draw(_spriteBatch);
                _spriteBatch.End();
            }
            else if (GameStateManager.GameState == GameState.PausedState && !HUDisTransitioning) 
            {
                _spriteBatch.Begin();
                PausedScreen.Draw(_spriteBatch);
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }

    }
}
