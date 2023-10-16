using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
using System;

namespace Project1
{
    public class Game1 : Game
    {

        public static GameTime deltaTime;
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;

        public static IEnvironment CurrentEnvironment;

        private Texture2D _texture;
        //public static SpriteBatch _spriteBatch;

        // not used because I made the methods in player public static
        //public Player player

        private IHealth HealthBarSprite;


        public static ContentManager ContentManager1;
        public static Game1 Game;

        public static IEnemy ENEMY;
        public static IItem Item;

        //Example code for how to create a item in the environment:
        //public static IItem testItem;
        //public static Vector2 testLoc = new Vector2((float)SPRITE_X, (float)SPRITE_Y);

        private ArrayList ControllerList;

        public Game1()
        {
            
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            contentLoader = Content;
            IsMouseVisible = true;

            //remove this later
            ContentManager1 = Content;
            Game = this;
            


        }

        public void Quit() => Exit();


        //void Quit() => Exit();



        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
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

            //Player player = new Player();
            Player.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            /**
             * 
             * Replace all sprites with proper sprites.
             */
            IListIterate EntityList = new EnemyIterator(this);

            IListIterate ItemList = new ItemIterator(this);
            IListIterate EnvironmentList = new EnvironmentIterator(this);

            //Example code for how to create a item in the environment:
            //testItem = new Triforce();

 
            Sword.LoadContent(Content);
            Arrow.LoadContent(Content);
            Boomerang.LoadContent(Content); 

            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            Player.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in ControllerList)
            {
                controller.Update();
            }
            deltaTime = gameTime;
            // TODO: Add your update logic here
            Player.Update(gameTime);
            //HealthBarSprite.Update();
            //HealthBarSprite.HealthDamage(1);
            //HealthBarSprite.Update();

            //Example code for how to create an item in the environment:
            //testItem.Update();

            Item.Update();
            ENEMY.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            Player.Draw(gameTime, _spriteBatch);

            ENEMY.Draw(_spriteBatch);
            Item.Draw(_spriteBatch);

            //Example code for how to create an item in the environment:
            //testItem.Draw(_spriteBatch, testLoc, 2);

            CurrentEnvironment.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);



           
        }
    }
}
