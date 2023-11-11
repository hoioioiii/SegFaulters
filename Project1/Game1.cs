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

namespace Project1
{
    public class Game1 : Game
    {

        public static GameTime deltaTime;
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;
        public static GraphicsDevice graphics;
        public static IActiveObjects GameObjManager;
        public static IDraw DrawManager;
        public static IUpdate UpdateManager;



        public static GameStateManager GameStateManager;
        private Texture2D _texture;
        //public static SpriteBatch _spriteBatch;

        // not used because I made the methods in player public static
        public static Player player;

        //private IHealth HealthBarSprite;
        public static IListIterate EnvironmentIterator;

        public static ContentManager ContentManager1;
        public static Game1 Game;


        public static IEntity ENEMY;
        public static IItem Item;

        public static IHUD hudDisplay;

        //Example code for how to create a item in the environment:
        //public static IItem testItem;
        //public static Vector2 testLoc = new Vector2((float)SPRITE_X, (float)SPRITE_Y);

        //remove later
        public static GameTime timeProj;
        private ArrayList ControllerList;

        Vector2 finalPostion;

        //Manages game over or playing
        public static bool gameStatePlaying;
        public static OptionSelector selectionManager;
        private SpriteFont font;
        public static int timer;

        public static bool roomIsTransitioning;

        public Game1()
        {


            _graphics = new GraphicsDeviceManager(this);
            selectionManager = new OptionSelector();
            _graphics.PreferredBackBufferHeight = (int)(480 * 1.75);
            Content.RootDirectory = "Content";
            contentLoader = Content;
            IsMouseVisible = true;

            //remove this later
            ContentManager1 = Content;
            Game = this;
            gameStatePlaying = true;

            //temp fix
            timer = 60 * 3;
        }


        public void Quit() => Exit();



        //optomize, clean and fix
        protected override void Initialize()
        {
            // Add your initialization logic here
            KeyboardState state = Keyboard.GetState();
            ControllerList = new ArrayList();
            ControllerList.Add(new KeyBoardController(this));
            ControllerList.Add(new KeyboardControllerPlayer(this));
            ControllerList.Add(new MouseController(this));

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

            //keep
            GameObjManager = new ActiveObjects();
            UpdateManager = new UpdateManager();
            DrawManager = new DrawManager();
            GameStateManager = new GameStateManager();


            timeProj = new GameTime();
            
            Player.Initialize();

            Camera.Initialize();

            //hudDisplay = new HeadsUpDisplay();

            base.Initialize();
        }

        //clean
        protected override void LoadContent()
        {
            //make the grid
            PositionGrid.createMap();

            RoomTransition.LoadTextures(Content);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("ZeldaFont");
            graphics = GraphicsDevice;
            AudioManager.LoadContent(Content);
            AudioManager.PlayMusic(BGM);

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            /**
             * 
             * Replace all sprites with proper sprites.
             */
            IListIterate EntityList = new EnemyIterator(this);

            IListIterate ItemList = new ItemIterator(this);
            EnvironmentIterator = new EnvironmentIterator(this);

            //pause icon
            GameStateManager.LoadContent(GraphicsDevice, Content);

            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            Player.LoadContent(Content);

            //Load background
            EnvironmentLoader.LoadContent(Content);

            //Load Music and start the BGM
            
            //AudioManager.PlaySoundEffect();


            
            //Load XML File
            LevelLoader.Load("D:\\CSE3902\\Projects\\SegFaulters\\Project1\\xmlTest2.xml");
            hudDisplay = new HeadsUpDisplay(GraphicsDevice, Content);
            //LevelLoader.Load("C:\\Users\\tinal\\source\\repos\\Seg3.4\\Project1\\xmlTest2.xml");
        }


        //clean up
        protected override void Update(GameTime gameTime)
        {
            //fix later
            deltaTime = gameTime;

            if (roomIsTransitioning)
            {
                Camera.TransitionRoom(gameTime);
            }
            else if (gameStatePlaying)
            {

                if (HealthDisplay.linkHealth.IsDead())
                {
                    // GameStateManager.GameState = GameState.GameOverState;
                    gameStatePlaying = false;

                }

                if (GameStateManager.GameState == GameState.DefaultState)
                {
                    // Add your update logic here
                    hudDisplay.Update(false);
                    Player.Update(gameTime);

                    //HealthBarSprite.Update();
                    //HealthBarSprite.HealthDamage(1);
                    //HealthBarSprite.Update();

                    //Example code for how to create an item in the environment:
                    //testItem.Update();

                    Item.Update();
                    ENEMY.Update();
                    EnvironmentLoader.Update();

                    //GameObjManager.Update();
                    AllCollisionDetection.DetectCollision(GameObjManager);
                    /*GameObjManager.Update()*/
                    ;

                    UpdateManager.Update();
                    AllCollisionDetection.DetectCollision(GameObjManager);

                    //if it's paused, HUDdisplay needs to move down


                    /*
                    #region Print to debug console
                    System.Text.StringBuilder sb = new StringBuilder();
                    sb.Append("Player pos" + Player.getPosition());
                    //sb.Append((char)Player.getPosition().Item1, (char)Player.getPosition().Item2);

                    if (sb.Length > 0)
                        System.Diagnostics.Debug.WriteLine(sb.ToString());
                    #endregion
                    */

                }
                else if (GameStateManager.GameState == GameState.PausedState)
                {
                    hudDisplay.Update(true);
                    GameStateManager.UpdateGameState();
                }


                //else if (GameStateManager.GameState == GameState.GameOverState)
                //{
                //    timer--;
                //}
            }
            else
            {
                timer--;
            }
            
            
            foreach (IController controller in ControllerList)
            {
                controller.Update();
            }

           


            
            

            


            base.Update(gameTime);
        }


        //fix later
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
          
            if (roomIsTransitioning)
            {
                _spriteBatch.Begin(transformMatrix: Camera.Transform);
                RoomTransition.Draw(_spriteBatch);
                EnvironmentLoader.Draw(_spriteBatch);
                // HUD doesn't move with camera yet, it has many small draw calls
                //hudDisplay.DrawFollowCamera(_spriteBatch);
            }
            else if (gameStatePlaying)
            {
                _spriteBatch.Begin();
                if (GameStateManager.GameState == GameState.DefaultState)
                {

                    EnvironmentLoader.Draw(_spriteBatch);
                
                
                


                    Player.Draw(gameTime, _spriteBatch);

                    DrawManager.Draw();


                    /*
                    #region Debug Draw Link's bounding box
                    // Create the single-pixel texture
                    Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
                    pixel.SetData<Color>(new Color[] { Color.White });

                    _spriteBatch.Draw(pixel, Player.BoundingBox, Color.White);
                    #endregion
                    */

                    //ENEMY.Draw(_spriteBatch);
                    //Item.Draw(_spriteBatch);
                    //CurrentEnvironment.Draw(_spriteBatch);
                    //GameObjManager.Draw();
                    
                }
                else if (GameStateManager.GameState == GameState.PausedState)
                {
                    GameStateManager.DrawGameState(_spriteBatch);
                    
                }
                hudDisplay.Draw(_spriteBatch);
                //else if (GameStateManager.GameState == GameState.GameOverState)
                //{
                //    if (timer <= 0)
                //    {
                //        GameOverScreens.DrawOptionsScreen(_spriteBatch, font);
                //    }
                //    else
                //    {

                //        GameOverScreens.DrawGameOverScreen(_spriteBatch, font);
                //    }
                //}
            }
            else
            {
                _spriteBatch.Begin();
                if (timer <= 0)
                {
                    GameOverScreens.DrawOptionsScreen(_spriteBatch, font);
                }
                else
                {

                    GameOverScreens.DrawGameOverScreen(_spriteBatch, font);
                }
            }

            //ENEMY.Draw(_spriteBatch);
            //Item.Draw(_spriteBatch);
            //CurrentEnvironment.Draw(_spriteBatch);
            //GameObjManager.Draw();

            _spriteBatch.End();
            base.Draw(gameTime);
        }



    }
}
