using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Vector2 position;

        private int positionX = 250;
        private int positionY = 250;

        private bool isFacingRight = true;
        private bool isMoving = false;
        private int playerSpeed = 5;

        public Texture2D linkRight;
        public Texture2D linkLeft;

        public Texture2D linkRightAnimatedTex;
        public Texture2D linkLeftAnimatedTex;

        //private MASprite ManimatedSprite;
        public int Rows = 1;
        public int Columns = 2;
        private int currentFrame;
        private int totalFrames;

        private int totalSteps;
        private int currentStep;

        public Player player;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void Quit() => Exit();

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            linkRight = Content.Load<Texture2D>("ZeldaSpriteLinkRight");
            linkLeft = Content.Load<Texture2D>("ZeldaSpriteLinkLeft");

            linkRightAnimatedTex = Content.Load<Texture2D>("linkWalkRightSpritesheet");
            linkLeftAnimatedTex = Content.Load<Texture2D>("linkWalkLeftSpritesheet");

            //linkRightAnimated = new MASprite(linkRightAnimatedTex, 1, 2);
            //linkLeftAnimated = new MASprite(linkLeftAnimatedTex, 1, 2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState state = Keyboard.GetState();
            // Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var key in state.GetPressedKeys())
                sb.Append("Key: ").Append(key).Append(" pressed ");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                //System.Diagnostics.Debug.WriteLine("No Keys pressed");
                isMoving = false;
                // Move our sprite based on arrow keys being pressed:

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // animation
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;


            

            // movement
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            {
                position.X -= playerSpeed;
                isFacingRight = false;
                isMoving = true;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                position.Y += playerSpeed;
                isMoving = true;
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
            {
                position.Y -= playerSpeed;
                isMoving = true;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                position.X += playerSpeed;
                isFacingRight = true;
                isMoving = true;
            }



            if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.N))
            {
                // attack using his sword

            }
            if (state.IsKeyDown(Keys.T) || state.IsKeyDown(Keys.Y))
            {
                // cycle between which block is currently being shown
            }
            if (state.IsKeyDown(Keys.U) || state.IsKeyDown(Keys.I))
            {

            }
            if (state.IsKeyDown(Keys.O) || state.IsKeyDown(Keys.P))
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            if (isMoving)
            {
                // replace with animations
                int width = 15;
                int height = 16;
                int row = currentFrame / Columns;
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)position.X + currentStep, (int)position.Y, width, height);

                if (isFacingRight)
                {
                    _spriteBatch.Draw(linkRightAnimatedTex, new Rectangle((int)position.X, (int)position.Y, linkRight.Width * 4, linkRight.Height * 4), Color.White);
                }
                else
                {
                    _spriteBatch.Draw(linkLeftAnimatedTex, new Rectangle((int)position.X, (int)position.Y, linkLeft.Width * 4, linkLeft.Height * 4), Color.White);
                }
            }
            else
            {
                if (isFacingRight)
                {
                    _spriteBatch.Draw(linkRight, new Rectangle((int)position.X, (int)position.Y, linkRight.Width * 4, linkRight.Height * 4), Color.White);
                }
                else
                {
                    _spriteBatch.Draw(linkLeft, new Rectangle((int)position.X, (int)position.Y, linkLeft.Width * 4, linkLeft.Height * 4), Color.White);
                }
            }
            
            Debug.WriteLine(positionX);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}