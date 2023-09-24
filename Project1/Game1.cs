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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            contentLoader = Content;
            IsMouseVisible = true;
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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            HealthBarSprite.Update();
            HealthBarSprite.HealthDamage(1);

            HealthBarSprite.Update();



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            HealthBarSprite.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}