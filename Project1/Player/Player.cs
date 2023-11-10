using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using static Project1.Constants;
using System;
using Project1.HUD;

namespace Project1
{
    public class Player
    {
        public IPlayerState playerState { get; set; }
        public static Rectangle BoundingBox;
        private GraphicsDeviceManager _graphics;
        private static ContentManager Content;
        private static Vector2 position = RESPAWN_UP;

        public static int[] itemInventory = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        //this enum is used to access the invetory by item type:
        //public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12 };

        //Needed for link sprite to draw
        private static IPlayerSprite sprite;

        private static bool isMoving = false;

        public static int playerSpeed = 5;

        // cardinal direction player is facing, starts with up on 1 and progresses clockwise (e.g. 4 is left-facing)
        private static int linkDirection = (int)DIRECTION.right;
        
        // attacking metrics
        public static bool isAttacking = false;
        private static float AttackTimer;

        // weapons
        private static bool isAttackingWithSword = false;
        private static bool isAttackingWithBoomerang = false;
        private static bool isAttackingWithBow = false;
        public static bool isAttackingWithBomb = false;

        // Check damage cooldown period to get hit again
        private static bool isDamaged = false;
        private static float DamageTimer;

        // Link will flash after damaged, indicating temporary invincibility
        private static bool renderLink = true;
        private static float FlashTimer;

        // how many animation frames per second, not the framerate of the game
        private static float FrameTimer;

        // link only has two frames of animation
        private static bool isSecondFrame = false;

        private static IWeapon[] weaponsArray;
        //private static IWeapon weapon;
        private static IWeapon spriteWeapon;

        private static int onScreen;


        private static bool remainOnScreen;

        private static int damageFlash;

        //this is a temp solution
        private static bool isDeadState;

        public Player()
        {

            remainOnScreen = false;
        }

        // initialize timing metrics for attacks and damage
        public static void Initialize()
        {
            FrameTimer = Constants.FRAMETIME;
            AttackTimer = Constants.ATTACK_SECONDS;
            DamageTimer = Constants.INVINCIBILITY_SECONDS;
            FlashTimer = Constants.FLASHTIME;
            damageFlash = 0;

            sprite = PlayerSpriteFactory.Instance.CreateLinkSprite();


            BoundingBox = new Rectangle(0, 0, LINK_BOUNDING_DIMENSION, LINK_BOUNDING_DIMENSION);
        }


        public static void LoadContent(ContentManager content)
        {
            //Try getting rid of this and use only sprite factory stuff

            //update this to have only sword
            IWeapon[] temp = { new Bomb(), new Arrow2(), new Boomerange(), new Sword() };
            weaponsArray = temp;

        }


        //change the current frame to the next frame
        public static void Update(GameTime gameTime)
        {
            // update timers for attack, damage, flash
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            AttackTimer -= elapsedSeconds;
            DamageTimer -= elapsedSeconds;
            FlashTimer -= elapsedSeconds;

            // set bounding box position to link position
            BoundingBox.Location = new Point((int)position.X + 5, (int)position.Y + 20);
            // move link to bounding box
            // call collision and pass in link

            if (isDamaged)
            {
                DamageInvincibility();
            }

            

            KeyboardState keystate = Keyboard.GetState();


            #region Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var key in keystate.GetPressedKeys())
                sb.Append("Key: ").Append(key).Append(" pressed ");

            if (sb.Length > 0)
            {
                //System.Diagnostics.Debug.WriteLine(sb.ToString());
            }
            else
                isMoving = false;
            #endregion

            // Move our sprite based on arrow keys being pressed:

            if (isAttacking)
            {
                WaitForAttack();
            }


            // Link can't move when attacking
            if (!isAttacking)
            {
                if (keystate.IsKeyDown(Keys.Z) || keystate.IsKeyDown(Keys.N))
                {
                    // attack using his sword
                    isAttacking = true;
                    isAttackingWithSword = true;

                    
                    //currentWeaponIndex = (int)WEAPONS.sword;
                    //sprite.Update(linkDirection, position);
                }
                else if (keystate.IsKeyDown(Keys.I))
                {
                    // attack using his 
                    isAttacking = true;
                    isAttackingWithBoomerang = true;

                    //currentWeaponIndex = (int)WEAPONS.boom;
                }
                else if (keystate.IsKeyDown(Keys.U))
                {
                    // attack using his 
                    isAttacking = true;
                    isAttackingWithBow = true;
                    //currentWeaponIndex = (int)WEAPONS.bow;
                }
                else if (keystate.IsKeyDown(Keys.T))
                {
                    // attack using his sword
                    isAttacking = true;
                    isAttackingWithBomb = true;
                    //currentWeaponIndex = (int)WEAPONS.bomb;

                    isAttackingWithSword = false;
                    isAttackingWithBoomerang = false;
                    isAttackingWithBow = false;

                }

            }

            //Is not always returning to display state at end
            if (keystate.IsKeyDown(Keys.E))
            {
                isDamaged = true;
                DamageInvincibility();
            }



            //if (remainOnScreen)
            //{
            //    spriteWeapon.Update();
            //}

        }

        public static Rectangle getPositionAndRectangle()
        {
            return sprite.getRectangle();
        }
        public static void CheckTime()
        {
            onScreen += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            damageFlash += Game1.deltaTime.ElapsedGameTime.Milliseconds;
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

            //manage non persistent weapon
            //if (remainOnScreen)
            //{
            //    spriteWeapon.Draw();
            //}
            //else
            //{
            //    onScreen = 0;
            //    remainOnScreen = false;
            //}

            if (renderLink)
            {
                if (isAttacking)
                {
                    DrawBasedOnAttackType(spriteBatch);

                }
                else
                {
                    DrawBasedOnMovementType(spriteBatch);
                }
            }

        }

        //decide which method of drawing link should be used based on his current state
        private static void DrawBasedOnMovementType(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                CheckFrameTimer();
                if (isSecondFrame)
                {
                    //tell sprite how to draw
                    sprite.Draw(spriteBatch, "move", linkDirection, position);

                }
                else
                {
                    //tell sprite how to draw
                    sprite.Draw(spriteBatch, "still", linkDirection, position);
                }

            }
            else
            {
                //tell sprite how to draw
                sprite.Draw(spriteBatch, "still", linkDirection, position);

            }


        }

        //Decide which way to go about drawing based on which weapon needs to be drawn
        //on the screen
        private static void DrawBasedOnAttackType(SpriteBatch spriteBatch)
        {
            
            
            //draw link with attack frames
            sprite.Draw(spriteBatch, "attack", linkDirection, position);
        }


        






        // if 1 second has passed since attacking, revert attack keystate to false (allowing for other actions)
        public static void WaitForAttack()
        {
            if (AttackTimer <= 0)
            {
                if(isAttackingWithSword)
                {
                   
              
                }
                
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
            if (damageFlash <= 50)
            {
                CheckTime();
                renderLink = false;

            }
            else if (damageFlash > 10)
            {
                renderLink = true;
                isDamaged = false;
                damageFlash = 0;
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

        //Command Functions
        public static void attackSword()
        {
            isAttacking = true;
            isAttackingWithSword = true;
            spriteWeapon = new Sword();
            Game1.GameObjManager.addNewPlayerWeapon(spriteWeapon);
        }

        public static void attackBoom()
        {
            isAttacking = true;
            isAttackingWithBoomerang = true;
            IWeapon boom = new BoomerangePlayer();
            Game1.GameObjManager.addNewPlayerWeapon(boom);
        }

        public static void attackBow()
        {
            isAttacking = true;
            isAttackingWithBow = true;
            IWeapon arrow = new Arrow2();
            Game1.GameObjManager.addNewPlayerWeapon(arrow);
        }

        public static void attackBomb()
        {
            isAttacking = true;
            isAttackingWithBomb = true;
            IWeapon bomb = new Bomb();
            Game1.GameObjManager.addNewPlayerWeapon(bomb);
        }

        public static void left()
        {
            position.X -= playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
            isMoving = true;
            linkDirection = (int)DIRECTION.left;

        }

        public static void down()
        {
            position.Y += playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
            isMoving = true;
            linkDirection = (int)DIRECTION.down;
        }

        public static void up()
        {
            position.Y -= playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
            isMoving = true;
            linkDirection = (int)DIRECTION.up;
           
        }

        public static void right()
        {
            position.X += playerSpeed;
            //room boundary controller, roomBounds var may need to be changed to new values
            position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
            isMoving = true;
            linkDirection = (int)DIRECTION.right;
           
        }

        public static void damage()
        {
            isDamaged = true;
            DamageInvincibility();

            AudioManager.PlaySoundEffect(linkHurt);
        }

        public static Vector2 getUserPos()
        {

            return new Vector2(position.X, position.Y);
        }

        private static int CleanDirection()
        {
            int direction = linkDirection;
            switch (linkDirection)
            {
                case 2:
                    direction = 0;

                    break;
                case 0:
                    direction = 1;
                    break;

                case 3:
                    direction = 2;

                    break;
                case 1:
                    direction = 3;

                    break;

            }
            return direction;
        }
        public static int getUserDirection()
        {
            
            return CleanDirection();
        }




        //inventory stuff -> did not add yet 
        //TODO
        public static void PickUpItem(ITEMS itemToAdd)
        {
            itemInventory[(int)itemToAdd]++;
        }

        public static bool UseItem(ITEMS itemToDelete)
        {
            bool didItemGetUsed;
            if (itemInventory[(int)itemToDelete] > 0)
            {
                itemInventory[(int)itemToDelete]--;
                didItemGetUsed = true; //if player has item, it got used.
            }
            else
            {
                didItemGetUsed = false; //if player does not have item, it did not get used.
            }

            return didItemGetUsed;
        }

        //got
        public static void setPosition(Vector2 newPostion)
        {
            position = newPostion;
        }

        //got
        public static Vector2 getPosition()
        {
            return position;
        }

        //got
        public static bool getPlayerAttackingState()
        {
            return isAttacking;
        }

    }
}


