using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using static Project1.Constants;

namespace Project1
{
public class Player
{
        // BUG SOLUTION 1.0
        public IPlayerState playerState { get; set; }

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
        public static bool isAttacking = false;
        // play attack frame for ATTACK_SECONDS seconds
        private static float AttackTimer;
        
        // weapons
        private static bool isAttackingWithSword = false;
        private static bool isAttackingWithBoomerang = false;
        private static bool isAttackingWithBow = false;
        public static bool isAttackingWithBomb = false;

        // damage
        private static bool isDamaged = false;
        // Link cannot take damage for x seconds after getting hit
        private static float DamageTimer;
        
        // Link will flash after damaged, indicating temporary invincibility
        private static bool renderLink = true;
        private static float FlashTimer;
        
        // for sprite animation
        private static float FrameTimer;
        // how many animation frames per second, not the framerate of the game
        
        // link only has two frames of animation
        private static bool isSecondFrame = false;

        private static IWeaponMelee weapon;
        private static IWeaponMelee spriteWeapon;

        private static int onScreen;


        private static int posX;
        private static int posY;

        private static bool remainOnScreen;
        //private Game1 game1;

        public Player()
        {
            posX = 0;
            posY = 0;
            remainOnScreen = false;
         
        }

        public static void Initialize(SpriteBatch spriteBatch)
        {
          
            FrameTimer = Constants.FRAMETIME;
            AttackTimer = Constants.ATTACK_SECONDS;
            DamageTimer = Constants.INVINCIBILITY_SECONDS;
            FlashTimer = Constants.FLASHTIME;
            //base.Initialize();
        }

        public static void Initialize()
        {
            // still and movement
            linkRight1 = content.Load<Texture2D>("linkRight1");
            linkLeft1 = content.Load<Texture2D>("linkLeft1");
            linkUp1 = content.Load<Texture2D>("linkUp1");
            linkDown1 = content.Load<Texture2D>("linkDown1");
       
            //create the link sprite
            sprite = PlayerSpriteFactory.Instance.CreateLinkSprite();
            linkLeft2 = content.Load<Texture2D>("linkLeft2");
            spriteWeapon = new Bomb();
           
            //attack using swordd
            swordRight = content.Load<Texture2D>("swordRight");
            swordLeft = content.Load<Texture2D>("swordLeft");
            swordUp = content.Load<Texture2D>("swordUp");
            swordDown = content.Load<Texture2D>("swordDown");
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
            Move(keyState);
            
            // else ifs used so link can only move in the cardinal directions
            // Link can't move when attacking
            if (!isAttacking)
            {
                if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.N))
                {
                    // attack using his sword
                    isAttacking = true;
                    isAttackingWithSword = true;
                    //sprite.Update(linkDirection, position);
                }
                else if (state.IsKeyDown(Keys.D1))
                {
                    // attack using his 
                    isAttacking = true;
                    isAttackingWithBoomerang = true;
                }
                else if (state.IsKeyDown(Keys.D2))
                {
                    // attack using his 
                    isAttacking = true;
                    isAttackingWithBow = true;
                }
                else if (state.IsKeyDown(Keys.D3))
                {
                    // attack using his sword
                    isAttacking = true;
                    isAttackingWithBomb = true;

                    isAttackingWithSword = false;
                    isAttackingWithBoomerang = false;
                    isAttackingWithBow = false;

                }



                if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
                {
                    position.X -= playerSpeed;
                    isMoving = true;
                    linkDirection = 4;

                    posX -= playerSpeed;


                    sprite.Update(4, position);
                }
                else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                {
                    position.Y += playerSpeed;
                    isMoving = true;
                    linkDirection = 3;
                    posX += playerSpeed;
                    sprite.Update(3, position);

                }
                else if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                {
                    position.Y -= playerSpeed;
                    isMoving = true;
                    linkDirection = 1;
                    posY -= playerSpeed;
                    sprite.Update(1, position);
                   
                }
                else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                {
                    position.X += playerSpeed;
                    isMoving = true;
                    linkDirection = 2;
                    posY += playerSpeed;
                    sprite.Update(2, position);
                    
                }
            }

            if (state.IsKeyDown(Keys.E))
            {
                DamageInvincibility();
            }

            Move(keyState);

            if (keyState.IsKeyDown(Keys.E))
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

            if (remainOnScreen)
            {
                spriteWeapon.Update();
            }


        }

        public static void CheckTime()
        {
            onScreen += Game1.deltaTime.ElapsedGameTime.Milliseconds;
        }


        public static void CheckOnScreen()
        {
            CheckTime();
            if(onScreen > 1000)
            {
                remainOnScreen = false;
            }
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // timer for Draw()
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            FrameTimer -= elapsedSeconds;

            CheckOnScreen();

            if (remainOnScreen)
            {
                spriteWeapon.Draw();
            }
            else
            {
                onScreen = 0;
                remainOnScreen = false;
            }

                    if (isAttackingWithSword)
                    {
                        switch (linkDirection)
                        {
                            case 1:
                                Sword.Draw(position, linkDirection);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 2:
                                Sword.Draw(position, linkDirection);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 3:
                                Sword.Draw(position, linkDirection);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 4:
                                Sword.Draw(position, linkDirection);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                        }
                    }
                    else if (isAttackingWithBoomerang)
                    {
                        switch (linkDirection)
                        {
                            case 1:
                                Boomerang.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 2:
                                Boomerang.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 3:
                                Boomerang.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 4:
                                Boomerang.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                        }
                    }
                    else if (isAttackingWithBow)
                    {
                        switch (linkDirection)
                        {
                            case 1:
                                Arrow.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 2:
                                Arrow.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 3:
                                Arrow.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                            case 4:
                                Arrow.Draw(position, linkDirection, spriteScale);
                                sprite.Draw(spriteBatch, "attack");
                                break;
                        }
                    }
                    else if (isAttackingWithBomb)
                    {
                        spriteWeapon = new Bomb();
                        remainOnScreen = true;
                        spriteWeapon.Attack();
                        spriteWeapon.Draw();
                        sprite.Draw(spriteBatch, "attack");
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
                            sprite.Draw(spriteBatch, "move");
                                case 3:
                                    DrawLink(linkDown2);
                                    break;
                            //tell sprite how to draw
                            sprite.Draw(spriteBatch, "still");
                                    DrawLink(linkLeft2);
                                    break;
                            }
                        }
                        //tell sprite how to draw
                        sprite.Draw(spriteBatch, "still");
                        
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
        }
        

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load(ContentManager Content, string texName)
        {
            return Content.Load<Texture2D>(assetName: texName);
        }

        public static void Move(KeyboardState keyState)
        {
            // movement
            // else ifs used so link can only move in the cardinal directions
            if (!isAttacking)
            {
                if (keyState.IsKeyDown(Keys.Z) || keyState.IsKeyDown(Keys.N))
                {
                    // attack using his sword
                    isAttacking = true;
                }
            
                if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                {
                    position.X -= playerSpeed;
                    isMoving = true;
                    linkDirection = 4;
                }
                else if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                {
                    position.Y += playerSpeed;
                    isMoving = true;
                    linkDirection = 3;
                }
                else if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                {
                    position.Y -= playerSpeed;
                    isMoving = true;
                    linkDirection = 1;
        }
                {
                    position.X += playerSpeed;
                    isMoving = true;
                    linkDirection = 2;
                }
            }
        }

        public void Attack()
        {
            // Attacks

            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box

        }
                AttackTimer = ATTACK_SECONDS;
                isAttackingWithBoomerang = false;
                isAttackingWithBow = false;
                isAttackingWithSword = false;
        // if 1 second has passed since attacking, revert attack state to false (allowing for other actions)
        public static void WaitForAttack()
        {
            if (AttackTimer <= 0)
            {
                isAttacking = false;
                AttackTimer = Constants.ATTACK_SECONDS;
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

        public static void attackSword()
        {
            isAttacking = true;
            isAttackingWithSword = true;
        }

        public static void attackBoom()
        {
            isAttacking = true;
            isAttackingWithBoomerang = true;
        }

        public static void attackBow()
        {
            isAttacking = true;
            isAttackingWithBow = true;
        }

        public static void left() {
            position.X -= playerSpeed;
            isMoving = true;
            linkDirection = 4;
            sprite.Update(4, position);
        }

        public static void down() {
            position.Y += playerSpeed;
            isMoving = true;
            linkDirection = 3;
            sprite.Update(3, position);
        }

        public static void up() {
            position.Y -= playerSpeed;
            isMoving = true;
            linkDirection = 1;
            sprite.Update(1, position);
        }

        public static void right() {
            position.X += playerSpeed;
            isMoving = true;
            linkDirection = 2;
            sprite.Update(2, position);
        }

        public static void damage()
        {
            isDamaged = true;
            DamageInvincibility();
        }

//        }

        public static Vector2 getUserPos()
        {

            return new Vector2(position.X, position.Y);
        }

        public static int getUserDirection()
        {
            return linkDirection;
        }

    }
}

//            sprite.Update();
//        }
//    }
//}


