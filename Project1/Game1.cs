<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
=======
﻿using Microsoft.Xna.Framework;
>>>>>>> parent of ff86808 (Added factory and modified concrete classes to use it)
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
<<<<<<< HEAD
        Vector2 position;

        private int positionX = 300;
        private int positionY = 300;

        private bool isMoving = false;
        
        private int playerSpeed = 5;

        // scales the size of the sprite on screen
        private int spriteScale = 4;

        // cardinal direction player is facing, starts with up on 1 and progresses clockwise (e.g. 4 is left-facing)
        private int linkDirection = 2;

        // frames used for still and animation
        public Texture2D linkRight1;
        public Texture2D linkLeft1;
        public Texture2D linkUp1;
        public Texture2D linkDown1;

        // frames used for animation only
        public Texture2D linkRight2;
        public Texture2D linkLeft2;
        public Texture2D linkUp2;
        public Texture2D linkDown2;

        // frames used for attacking
        public Texture2D linkAttackRight;
        public Texture2D linkAttackLeft;
        public Texture2D linkAttackUp;
        public Texture2D linkAttackDown;

        // attacking
        private bool isAttacking = false;
        // play attack frame for ATTACK_SECONDS seconds
        private float AttackTimer;
        const float ATTACK_SECONDS = 0.5f;

        // for sprite animation
        private float FrameTimer;
        // how many animation frames per second, not the framerate of the game
        const float FRAMES_PER_SECOND = 10;
        const float FRAMETIME = 1 / FRAMES_PER_SECOND;
        // link only has two frames of animation
        private bool isSecondFrame = false;

        private int totalSteps;
        private int currentStep;

        public Player player;
        
=======
>>>>>>> parent of ff86808 (Added factory and modified concrete classes to use it)

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

<<<<<<< HEAD
        public void Quit() => Exit();

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //player = new Player();
            FrameTimer = FRAMETIME;
            AttackTimer = ATTACK_SECONDS;
            
=======
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

>>>>>>> parent of ff86808 (Added factory and modified concrete classes to use it)
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
<<<<<<< HEAD

            // TODO: use this.Content to load your game content here

            // still and movement
            linkRight1 = Content.Load<Texture2D>("linkRight1");
            linkLeft1 = Content.Load<Texture2D>("linkLeft1");
            linkUp1 = Content.Load<Texture2D>("linkUp1");
            linkDown1 = Content.Load<Texture2D>("linkDown1");

            // movement only
            linkRight2 = Content.Load<Texture2D>("linkRight2");
            linkLeft2 = Content.Load<Texture2D>("linkLeft2");
            linkUp2 = Content.Load<Texture2D>("linkUp2");
            linkDown2 = Content.Load<Texture2D>("linkDown2");

            // Attack using weapon or item
            linkAttackRight = Content.Load<Texture2D>("linkAttackRight");
            linkAttackLeft = Content.Load<Texture2D>("linkAttackLeft");
            linkAttackUp = Content.Load<Texture2D>("linkAttackUp");
            linkAttackDown = Content.Load<Texture2D>("linkAttackDown");
=======

            // TODO: use this.Content to load your game content here
>>>>>>> parent of ff86808 (Added factory and modified concrete classes to use it)
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

<<<<<<< HEAD
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            AttackTimer -= elapsedSeconds;

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

            if (isAttacking)
            {
                WaitForAttack();
            }

            // movement
            // else ifs used so link can only move in the cardinal directions
            if (!isAttacking)
            {
                if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.N))
                {
                    // attack using his sword
                    isAttacking = true;
                    //WaitForAttack();
                }

                if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
                {
                    position.X -= playerSpeed;
                    isMoving = true;
                    linkDirection = 4;
                }
                else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                {
                    position.Y += playerSpeed;
                    isMoving = true;
                    linkDirection = 3;
                }
                else if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                {
                    position.Y -= playerSpeed;
                    isMoving = true;
                    linkDirection = 1;
                }
                else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                {
                    position.X += playerSpeed;
                    isMoving = true;
                    linkDirection = 2;
                }
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

=======
>>>>>>> parent of ff86808 (Added factory and modified concrete classes to use it)
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
<<<<<<< HEAD
            
            _spriteBatch.Begin();

            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            FrameTimer -= elapsedSeconds;

            if (isAttacking)
            {
                switch (linkDirection)
                {
                    case 1:
                        DrawLink(linkAttackUp);
                        break;
                    case 2:
                        DrawLink(linkAttackRight);
                        break;
                    case 3:
                        DrawLink(linkAttackDown);
                        break;
                    case 4:
                        DrawLink(linkAttackLeft);
                        break;
                    default:
                        DrawLink(linkAttackRight);
                        break;
                }
            }
            else
            {
                if (isMoving)
                {
                    CheckFrameTimer();
                    if (isSecondFrame)
                    {
                        switch (linkDirection)
                        {
                            case 1:
                                DrawLink(linkUp2);
                                break;
                            case 2:
                                DrawLink(linkRight2);
                                break;
                            case 3:
                                DrawLink(linkDown2);
                                break;
                            case 4:
                                DrawLink(linkLeft2);
                                break;
                            default:
                                DrawLink(linkRight2);
                                break;
                        }
                    }
                    else
                    {
                        Link1Switch();
                    }
                }
                else
                {
                    Link1Switch();
                }
            }
            

            Debug.WriteLine(positionX);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // if 1 second has passed since attacking, revert attack state to false (allowing for other actions)
        private void WaitForAttack()
        {
            if (AttackTimer <= 0)
            {
                isAttacking = false;
                AttackTimer = ATTACK_SECONDS;
            }
        }

        // if Timer > FRAMETIME, switch the frame
        private void CheckFrameTimer()
        {
            if (FrameTimer <= 0)
            {
                isSecondFrame = !isSecondFrame;
                FrameTimer = FRAMETIME;
            }
        }

        // is seperate method to reduce duplicate code
        void DrawLink(Texture2D tex)
        {
            _spriteBatch.Draw(tex, new Rectangle((int)position.X, (int)position.Y, tex.Width * spriteScale, tex.Height * spriteScale), Color.White);
        }

        // this switch statement will be used both when link is moving and when he is still
        // preventing duplicated code (a code smell)
        void Link1Switch()
        {
            switch (linkDirection)
            {
                case 1:
                    DrawLink(linkUp1);
                    break;
                case 2:
                    DrawLink(linkRight1);
                    break;
                case 3:
                    DrawLink(linkDown1);
                    break;
                case 4:
                    DrawLink(linkLeft1);
                    break;
                default:
                    DrawLink(linkRight1);
                    break;
            }
=======

            // TODO: Add your drawing code here

            base.Draw(gameTime);
>>>>>>> parent of ff86808 (Added factory and modified concrete classes to use it)
        }
    }
}