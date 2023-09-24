using Microsoft.Xna.Framework;
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


        Texture2D shooter;
        private Weapon pistol;

        Game1 currentGame;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            currentGame = this;

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            
            shooter = Content.Load<Texture2D>("topdownpistol");
            pistol = new Pistol(currentGame, shooter, playerPosition);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            pistol.Update();


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


            _spriteBatch.Draw(shooter, playerPosition, Color.White);

            //_spriteBatch.Draw(pistol.weaponSprite, playerPosition, Color.White);

            pistol.Draw(gameTime, _spriteBatch);  

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}