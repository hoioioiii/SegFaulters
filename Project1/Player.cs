using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project1
{
    public class Player
    {
        private GraphicsDeviceManager _graphics;
        //private static SpriteBatch _spriteBatch;
        private static ContentManager Content;
        private static Vector2 position;

        private int positionX = 300;
        private int positionY = 300;

        private static bool isMoving = false;

        private static int playerSpeed = 5;

        // scales the size of the sprite on screen
        private static int spriteScale = 4;
        private static int swordScale = 1;

        // cardinal direction player is facing, starts with up on 1 and progresses clockwise (e.g. 4 is left-facing)
        private static int linkDirection = 2;

        // frames used for still and animation
        public static Texture2D linkRight1;
        public static Texture2D linkLeft1;
        public static Texture2D linkUp1;
        public static Texture2D linkDown1;

        // frames used for animation only
        public static Texture2D linkRight2;
        public static Texture2D linkLeft2;
        public static Texture2D linkUp2;
        public static Texture2D linkDown2;

        // frames used for attacking
        public static Texture2D linkAttackRight;
        public static Texture2D linkAttackLeft;
        public static Texture2D linkAttackUp;
        public static Texture2D linkAttackDown;

        //sword frames
        public static Texture2D swordRight;
        public static Texture2D swordLeft;
        public static Texture2D swordUp;
        public static Texture2D swordDown;



        // attacking
        private static bool isAttacking = false;
        // play attack frame for ATTACK_SECONDS seconds
        private static float AttackTimer;
        const float ATTACK_SECONDS = 0.5f;

        // for sprite animation
        private static float FrameTimer;
        // how many animation frames per second, not the framerate of the game
        const float FRAMES_PER_SECOND = 10;
        const float FRAMETIME = 1 / FRAMES_PER_SECOND;
        // link only has two frames of animation
        private static bool isSecondFrame = false;

        //private Game1 game1;

        public Player()
        {
            //Game1 game1 = new Game1();
            //_graphics = new GraphicsDeviceManager(game1);
        }

        public static void Initialize()
        {
            //ContentManager Content = new ContentManager();
            FrameTimer = FRAMETIME;
            AttackTimer = ATTACK_SECONDS;

            //base.Initialize();

        }

        public static void LoadContent(ContentManager content)
        {
            // still and movement
            linkRight1 = content.Load<Texture2D>("linkRight1");
            linkLeft1 = content.Load<Texture2D>("linkLeft1");
            linkUp1 = content.Load<Texture2D>("linkUp1");
            linkDown1 = content.Load<Texture2D>("linkDown1");

            // movement only
            linkRight2 = content.Load<Texture2D>("linkRight2");
            linkLeft2 = content.Load<Texture2D>("linkLeft2");
            linkUp2 = content.Load<Texture2D>("linkUp2");
            linkDown2 = content.Load<Texture2D>("linkDown2");

            // Attack using weapon or item
            linkAttackRight = content.Load<Texture2D>("linkAttackRight");
            linkAttackLeft = content.Load<Texture2D>("linkAttackLeft");
            linkAttackUp = content.Load<Texture2D>("linkAttackUp");
            linkAttackDown = content.Load<Texture2D>("linkAttackDown");

            //attack using swordd
            swordRight = content.Load<Texture2D>("swordRight");
            swordLeft = content.Load<Texture2D>("swordLeft");
            swordUp = content.Load<Texture2D>("swordUp");
            swordDown = content.Load<Texture2D>("swordDown");
        }

        //change the current frame to the next frame
        public static void Update(GameTime gameTime)
        {
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            AttackTimer -= elapsedSeconds;

            // rename to keyState
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
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            FrameTimer -= elapsedSeconds;

            if (isAttacking)
            {
                switch (linkDirection)
                {
                    case 1:
                        int swordOffsetX = 5;
                        int swordOffsetY = -65;
                        DrawSword(swordUp, swordOffsetX, swordOffsetY);
                        DrawLink(linkAttackUp);
                        break;
                    case 2:
                        swordOffsetX = 55;
                        swordOffsetY = 25;
                        DrawSword(swordRight, swordOffsetX, swordOffsetY);
                        DrawLink(linkAttackRight);
                        break;
                    case 3:
                        swordOffsetX = 25;
                        swordOffsetY = 60;
                        DrawSword(swordDown, swordOffsetX, swordOffsetY);
                        DrawLink(linkAttackDown);
                        break;
                    case 4:
                        swordOffsetX = -50;
                        swordOffsetY = 25;
                        DrawSword(swordLeft, swordOffsetX, swordOffsetY);
                        DrawLink(linkAttackLeft);
                        break;
                    default:
                        swordOffsetX = 55;
                        swordOffsetY = 25;
                        DrawSword(swordRight, swordOffsetX, swordOffsetY);
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
        }
        

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load(ContentManager Content, string texName)
        {
            return Content.Load<Texture2D>(assetName: texName);
        }

        public void Move()
        {

            
        }

        public void Health()
        {
            // Check health
            // doesn't need to be implemented in sprint 2
        }

        public static void DrawSword(Texture2D tex, int offsetX, int offsetY)
        {
            // Attacks
            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X + offsetX, (int)position.Y + offsetY, tex.Width * swordScale, tex.Height * swordScale), Color.White);
            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box

        }

        // if 1 second has passed since attacking, revert attack state to false (allowing for other actions)
        public static void WaitForAttack()
        {
            if (AttackTimer <= 0)
            {
                isAttacking = false;
                AttackTimer = ATTACK_SECONDS;
            }
        }

        // if Timer > FRAMETIME, switch the frame
        public static void CheckFrameTimer()
        {
            if (FrameTimer <= 0)
            {
                isSecondFrame = !isSecondFrame;
                FrameTimer = FRAMETIME;
            }
        }

        // is seperate method to reduce duplicate code
        public static void DrawLink(Texture2D tex)
        {
            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X, (int)position.Y, tex.Width * spriteScale, tex.Height * spriteScale), Color.White);
        }

        // this switch statement will be used both when link is moving and when he is still
        // preventing duplicated code (a code smell)
        public static void Link1Switch()
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
        }
    }
}
