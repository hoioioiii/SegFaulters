using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        Microsoft.Xna.Framework.Vector2 playerPosition = new Microsoft.Xna.Framework.Vector2(100, 100);

        Player player;
        Texture2D shooter;
        Game1 currentGame;
        public static ContentManager contentLoader;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            contentLoader = Content;
            //_spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Initialize()
        {
            currentGame = this;
            player = new Player();

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            //_spriteBatch = new SpriteBatch(GraphicsDevice);
            //shooter = Content.Load<Texture2D>("topdownpistol");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                //Weapon.WeaponFire(this);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            //_spriteBatch.Draw(shooter, playerPosition, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}