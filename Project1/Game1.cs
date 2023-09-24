using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;

        private IHealth HealthBarSprite;


        public static ContentManager ContentManager1;
        public static Game1 Game;

        private IEnemy ENEMY;

        private Texture2D _texture;
     
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
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            HealthBarSprite = new HealthSystem();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            /**
             * 
             * Replace all sprites with proper sprites.
             */


            ENEMY = new Bat();
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



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            HealthBarSprite.Update();
            HealthBarSprite.HealthDamage(1);

            HealthBarSprite.Update();



          
            ENEMY.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            HealthBarSprite.Draw();

            _spriteBatch.End();
            _spriteBatch.Begin();


            ENEMY.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);



           
        }
    }
}