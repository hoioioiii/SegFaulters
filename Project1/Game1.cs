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

namespace Project1
{
    public class Game1 : Game
    {

        public static GameTime deltaTime;
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;

        public static IActiveObjects GameObjManager;
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

        //Example code for how to create a item in the environment:
        //public static IItem testItem;
        //public static Vector2 testLoc = new Vector2((float)SPRITE_X, (float)SPRITE_Y);

        //remove later
        public static GameTime timeProj;
        private ArrayList ControllerList;

        public Game1()
        {


            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = (int)(480 * 1.75);
            Content.RootDirectory = "Content";
            contentLoader = Content;
            IsMouseVisible = true;

            //remove this later
            ContentManager1 = Content;
            Game = this;

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

            timeProj = new GameTime();
            //keep
            GameObjManager = new ActiveObjects();


            player = new Player();
            Player.Initialize();

            base.Initialize();
        }

        //clean
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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



            //Sword.LoadContent(Content);
            //Arrow.LoadContent(Content);
            //Boomerang.LoadContent(Content);

            
            Player.LoadContent(Content);

            //Load background
            EnvironmentLoader.LoadContent(Content);

            //Load Music and start the BGM
            AudioManager.LoadContent(Content);
            AudioManager.PlayMusic(BGM);
            //AudioManager.PlaySoundEffect();

            //Load XML File
            //LevelLoader.Load("D:\\CSE3902\\Projects\\SegFaulters\\Project1\\xmlTest2.xml");
            LevelLoader.Load("C:\\Users\\tinal\\Source\\Repos\\3.7\\Project1\\xmlTest2.xml");
        }


        //clean up
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in ControllerList)
            {
                controller.Update();
            }
            
         

            //fix later
            deltaTime = gameTime;
            // Add your update logic here
            Player.Update(gameTime);
            //HealthBarSprite.Update();
            //HealthBarSprite.HealthDamage(1);
            //HealthBarSprite.Update();

            //Example code for how to create an item in the environment:
            //testItem.Update();

            Item.Update();
            ENEMY.Update();
            EnvironmentLoader.Update();

            GameObjManager.Update();
            AllCollisionDetection.DetectCollision(GameObjManager);

            /*
            #region Print to debug console
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("Player pos" + Player.getPosition());
            //sb.Append((char)Player.getPosition().Item1, (char)Player.getPosition().Item2);

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion
            */

            base.Update(gameTime);
        }


        //fix later
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            EnvironmentLoader.Draw(_spriteBatch);

            Player.Draw(gameTime, _spriteBatch);

            /*
            #region Debug Draw Link's bounding box
            // Create the single-pixel texture
            Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });

            _spriteBatch.Draw(pixel, Player.BoundingBox, Color.White);
            #endregion
            */

            //ENEMY.Draw(_spriteBatch);
            Item.Draw(_spriteBatch);
            //CurrentEnvironment.Draw(_spriteBatch);
            GameObjManager.Draw();


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
