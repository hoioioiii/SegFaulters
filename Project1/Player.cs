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

        //Needed for link sprite to draw
        private static IPlayerSprite sprite;
        private static SpriteBatch sprBatch;

        private static bool isMoving = false;

        private static int playerSpeed = 5;

        // scales the size of the sprite on screen
        private static int spriteScale = 4;

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

        // attacking
        private static bool isAttacking = false;
        // play attack frame for ATTACK_SECONDS seconds
        private static float AttackTimer;
        const float ATTACK_SECONDS = 0.5f;

        // damage
        private static bool isDamaged = false;
        // Link cannot take damage for x seconds after getting hit
        private static float DamageTimer;
        const float INVINCIBILITY_SECONDS = 1;
        // Link will flash after damaged, indicating temporary invincibility
        private static bool renderLink = true;
        private static float FlashTimer;
        const float FLASHES_PER_SECOND = 8;
        const float FLASHTIME = 1 / FLASHES_PER_SECOND;

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

        public static void Initialize(SpriteBatch spriteBatch)
        {
            //ContentManager Content = new ContentManager();
            FrameTimer = FRAMETIME;
            AttackTimer = ATTACK_SECONDS;
            DamageTimer = INVINCIBILITY_SECONDS;
            FlashTimer = FLASHTIME;
            sprBatch = spriteBatch;
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

            //create the link sprite
            sprite = PlayerSpriteFactory.Instance.CreateLinkSprite();
        }

        //change the current frame to the next frame
        public static void Update(GameTime gameTime)
        {
            // timers for Update()
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            AttackTimer -= elapsedSeconds;
            DamageTimer -= elapsedSeconds;
            FlashTimer -= elapsedSeconds;
            
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

            if (isDamaged)
            {
                DamageInvincibility();
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
                    sprite.Update(4, position);
                }
                else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                {
                    position.Y += playerSpeed;
                    isMoving = true;
                    sprite.Update(3, position);
                }
                else if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                {
                    position.Y -= playerSpeed;
                    isMoving = true;
                    sprite.Update(1, position);
                }
                else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                {
                    position.X += playerSpeed;
                    isMoving = true;
                    sprite.Update(2, position);
                }
            }

            if (state.IsKeyDown(Keys.E))
            {
                isDamaged = true;
                DamageInvincibility();
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
            // timer for Draw()
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            FrameTimer -= elapsedSeconds;

            // Link will not be rendered when damaged (he will flash for INVINCIBILITY_SECONDS seconds)
            if (renderLink)
            {
                // direction & isAttacking dictates which Link sprite is drawn
                if (isAttacking)
                {
                    //tell sprite how to draw
                    sprite.Draw(sprBatch, "attack");

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
                            //tell sprite how to draw
                            sprite.Draw(sprBatch, "moving");

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
                            //tell sprite how to draw
                            sprite.Draw(sprBatch, "still");
                            //Link1Switch();
                        }
                    }
                    else
                    {
                        //tell sprite how to draw
                        sprite.Draw(sprBatch, "still");
                        //Link1Switch();
                    }
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

        // is seperate method to reduce duplicate code
        public static void DrawLink(Texture2D tex)
        {
            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X, (int)position.Y, tex.Width * spriteScale, tex.Height * spriteScale), Color.White);
        }

        // movement goes here
        public void Move()
        {

        }

        public void Health()
        {
            // Check health
            // doesn't need to be implemented in sprint 2
        }

        public void Attack()
        {
            // Attacks

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

        // Link cannot take damage for x seconds after getting hit
        public static void DamageInvincibility()
        {
            if (DamageTimer <= 0)
            {
                renderLink = true;
                isDamaged = false;
                DamageTimer = INVINCIBILITY_SECONDS;
            }
            else
            {
                if (FlashTimer <= 0)
                {
                    renderLink = !renderLink;
                    FlashTimer = FLASHTIME;
                }
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

        // this switch statement will be used both when link is moving and when he is still
        // direction dictates which sprite is drawn
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
