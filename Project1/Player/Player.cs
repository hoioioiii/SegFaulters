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

        //Item inventory map
        public static int[] itemInventory = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        //Dictionary<string, int> itemInventory = new Dictionary<string, int>() { {"arrow", 0}, { "bomb", 0 }, { "boomerang", 0 }, { "bow", 0 }, { "clock", 0 }, { "fairy", 0 }, { "heart", 0 }, { "heartContainer", 0 }, { "key", 0 }, { "map", 0 }, { "rupee", 0 }, { "sword", 0 }, { "triforce", 0 }};

        //had to move this out of constants file due to it being an internal class
        //public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12 };

        //Needed for link sprite to draw
        private static IPlayerSprite sprite;
        private static SpriteBatch sprBatch;

        public Rectangle BoundingBox { get; set; }

        private static bool isMoving = false;

        public static int playerSpeed = 5;

        #region Sprites
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
        #endregion

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

        private static IWeapon weapon;
        private static IWeapon spriteWeapon;

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

        public static void Initialize()
        {
            FrameTimer = Constants.FRAMETIME;
            AttackTimer = Constants.ATTACK_SECONDS;
            DamageTimer = Constants.INVINCIBILITY_SECONDS;
            FlashTimer = Constants.FLASHTIME;

            //create the link sprite
            sprite = PlayerSpriteFactory.Instance.CreateLinkSprite();

            weapon = new Bomb();


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

        }
       

        //change the current frame to the next frame
        public static void Update(GameTime gameTime)
        {
            // timers for Update()
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            AttackTimer -= elapsedSeconds;
            DamageTimer -= elapsedSeconds;
            FlashTimer -= elapsedSeconds;

            KeyboardState keystate = Keyboard.GetState();

            #region Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var key in keystate.GetPressedKeys())
                sb.Append("Key: ").Append(key).Append(" pressed ");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                //System.Diagnostics.Debug.WriteLine("No Keys pressed");
                isMoving = false;
            #endregion

            // Move our sprite based on arrow keys being pressed:

            if (isAttacking)
            {
                WaitForAttack();
            }

           // Move(keyState);

            // else ifs used so link can only move in the cardinal directions
            // Link can't move when attacking
            if (!isAttacking)
            {
                if (keystate.IsKeyDown(Keys.Z) || keystate.IsKeyDown(Keys.N))
                {
                    // attack using his sword
                    isAttacking = true;
                    isAttackingWithSword = true;
                    //sprite.Update(linkDirection, position);
                }
                else if (keystate.IsKeyDown(Keys.I))
                {
                    // attack using his 
                    isAttacking = true;
                    isAttackingWithBoomerang = true;
                }
                else if (keystate.IsKeyDown(Keys.U))
                {
                    // attack using his 
                    isAttacking = true;
                    isAttackingWithBow = true;
                }
                else if (keystate.IsKeyDown(Keys.B))
                {
                    // attack using his sword
                    isAttacking = true;
                    isAttackingWithBomb = true;

                    isAttackingWithSword = false;
                    isAttackingWithBoomerang = false;
                    isAttackingWithBow = false;

                }



                if (keystate.IsKeyDown(Keys.Left) || keystate.IsKeyDown(Keys.A))
                {
                    position.X -= playerSpeed;
                    isMoving = true;
                    linkDirection = 4;

                    posX -= playerSpeed;


                    sprite.Update(4, position);
                }
                else if (keystate.IsKeyDown(Keys.Down) || keystate.IsKeyDown(Keys.S))
                {
                    position.Y += playerSpeed;
                    isMoving = true;
                    linkDirection = 3;
                    posX += playerSpeed;
                    sprite.Update(3, position);

                }
                else if (keystate.IsKeyDown(Keys.Up) || keystate.IsKeyDown(Keys.W))
                {
                    position.Y -= playerSpeed;
                    isMoving = true;
                    linkDirection = 1;
                    posY -= playerSpeed;
                    sprite.Update(1, position);

                }
                else if (keystate.IsKeyDown(Keys.Right) || keystate.IsKeyDown(Keys.D))
                {
                    position.X += playerSpeed;
                    isMoving = true;
                    linkDirection = 2;
                    posY += playerSpeed;
                    sprite.Update(2, position);

                }
            }

            /*
            if (keystate.IsKeyDown(Keys.E))
            {
                DamageInvincibility();
            }
            */
            //Move(keystate);

            if (keystate.IsKeyDown(Keys.E))
            {
                isDamaged = true;
                DamageInvincibility();
            }
            if (keystate.IsKeyDown(Keys.T) || keystate.IsKeyDown(Keys.Y))
            {
                // cycle between which block is currently being shown
            }
            if (keystate.IsKeyDown(Keys.U) || keystate.IsKeyDown(Keys.I))
            {

            }
            if (keystate.IsKeyDown(Keys.O) || keystate.IsKeyDown(Keys.P))
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
            if (onScreen > 1000)
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
            if (renderLink)
            {
                if (isAttacking)
                {
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

                        Attack("boomerange");

                        sprite.Draw(spriteBatch, "attack");
                    }
                    else if (isAttackingWithBow)
                    {
                        
                        Attack("bow");
                    
                        sprite.Draw(spriteBatch, "attack");
                    }
                    else if (isAttackingWithBomb)
                    {
                        Attack("bomb");
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

                        }
                        else
                        {
                            //tell sprite how to draw
                            sprite.Draw(spriteBatch, "still");

                        }
                    }
                    else
                    {
                        //tell sprite how to draw
                        sprite.Draw(spriteBatch, "still");

                    }
                }
            }
        }

        public static void Attack(string weaponType)
        {
            switch (weaponType)
            {
                case "bomb":
                    weapon = new Bomb();
                    spriteWeapon = weapon;
                    break;

                case "bow":
                    weapon = new Arrow2();
                    spriteWeapon = weapon;
                    break;

                case "boomerange":
                    weapon = new Boomerange();
                    spriteWeapon = weapon;
                    break;
                case "orb":
                    weapon = new Orb();
                    spriteWeapon = weapon;
                    break;

            }
            remainOnScreen = true;
            spriteWeapon.Attack();
            spriteWeapon.Draw();
        }






        // if 1 second has passed since attacking, revert attack keystate to false (allowing for other actions)
        public static void WaitForAttack()
        {
            if (AttackTimer <= 0)
            {
                isAttacking = false;
                AttackTimer = Constants.ATTACK_SECONDS;
                isAttackingWithBoomerang = false;
                isAttackingWithBow = false;
                isAttackingWithSword = false;
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

        public static void left()
        {
            position.X -= playerSpeed;
            isMoving = true;
            linkDirection = 4;
            sprite.Update(4, position);
        }

        public static void down()
        {
            position.Y += playerSpeed;
            isMoving = true;
            linkDirection = 3;
            sprite.Update(3, position);
        }

        public static void up()
        {
            position.Y -= playerSpeed;
            isMoving = true;
            linkDirection = 1;
            sprite.Update(1, position);
        }

        public static void right()
        {
            position.X += playerSpeed;
            isMoving = true;
            linkDirection = 2;
            sprite.Update(2, position);
        }

        public static void damage()
        {
            //isDamaged = true;
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

        public static void PickUpItem(ITEMS itemToAdd)
        {
            itemInventory[(int)itemToAdd]++;
        }

        public static void UseItem(ITEMS itemToDelete)
        {
            if(itemInventory[(int)itemToDelete] > 0) {
                itemInventory[(int)itemToDelete]--;
            }
        }

    }
}
