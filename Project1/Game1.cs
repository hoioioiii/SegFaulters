using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections;

namespace Project1
{
    public class Game1 : Game
    {

        public static GameTime deltaTime;
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;
        //public static SpriteBatch _spriteBatch;

        // not used because I made the methods in player public static
        //public Player player

        private IHealth HealthBarSprite;


        public static ContentManager ContentManager1;
        public static Game1 Game;

        public static IEnemy ENEMY;

        private Texture2D _texture;
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


        //void Quit() => Exit();



        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            KeyboardState state = Keyboard.GetState();
            ControllerList = new ArrayList();
            ControllerList.Add(new KeyBoardController(this));

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
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            /**
             * 
             * Replace all sprites with proper sprites.
             */
            IListIterate EntityList = new EnemyIterator(this);

            
            //ENEMY = new Bat();
            //ENEMY = new BossAquaDragon();
            //ENEMY = new BossDino();
            //ENEMY = new BossFireDragon();
            //ENEMY = new DogMonster();
            //ENEMY = new Flame();
            //ENEMY = new Jelly();
            //ENEMY = new Merchant();
            //ENEMY = new OldMan();
            //ENEMY = new Skeleton();
            //ENEMY = new Snake();
            //ENEMY = new SpikeCross();




            // TODO: use this.Content to load your game content here
            //Content content = this.Content;
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

            

            ENEMY.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            //HealthBarSprite.Draw();

           
         
           

            Player.Draw(gameTime, _spriteBatch);

            


            ENEMY.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);



           
        }
    }
}
