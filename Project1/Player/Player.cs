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

        //this enum is used to access the inventory by item type:
        //public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12 };
        public static int[] itemInventory = { 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0};

        //Needed for link sprite to draw
        private static IPlayerSprite sprite;

        public static bool isMoving = false;

        public static bool isAttacking = false;

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

        private static int onScreen;

        private static bool remainOnScreen;

        private static int damageFlash;

        //this is a temp solution
        //private static bool isDeadState;

        public Player()
        {

            remainOnScreen = false;
        }

        // initialize timing metrics for attacks and damage
        public static void Initialize()
        {
            FrameTimer = Constants.FRAMETIME;

            PlayerAttack.setAttackTimer(Constants.ATTACK_SECONDS);
            DamageTimer = Constants.INVINCIBILITY_SECONDS;
            FlashTimer = Constants.FLASHTIME;
            damageFlash = 0;

            sprite = PlayerSpriteFactory.Instance.CreateLinkSprite();


            BoundingBox = new Rectangle(0, 0, LINK_BOUNDING_DIMENSION, LINK_BOUNDING_DIMENSION);
        }


        public static void LoadContent(ContentManager content)
        {

            //update this to have only sword
            IWeapon[] temp = { new Bomb(), new Arrow2(), new Boomerange(), new Sword() };
            weaponsArray = temp;

        }


        //change the current frame to the next frame
        public static void Update(GameTime gameTime)
        {
            // update timers for attack, damage, flash
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            PlayerAttack.setAttackTimer(PlayerAttack.getAttackTimer() - elapsedSeconds);
            DamageTimer -= elapsedSeconds;
            FlashTimer -= elapsedSeconds;

            // set bounding box position to link position
            BoundingBox.Location = new Point((int)PlayerMovement.getPosition().X + 5, (int)PlayerMovement.getPosition().Y + 20);
            // move link to bounding box
            // call collision and pass in link

            if (isDamaged)
            {
                DamageInvincibility();
            }


            // Move our sprite based on arrow keys being pressed:

            if (Player.isAttacking)
            {
                PlayerAttack.WaitForAttack();
            }

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

            if (renderLink)
            {
                if (Player.isAttacking)
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
                    sprite.Draw(spriteBatch, "move", PlayerMovement.getLinkDirection(), PlayerMovement.getPosition());

                }
                else
                {
                    //tell sprite how to draw
                    sprite.Draw(spriteBatch, "still", PlayerMovement.getLinkDirection(), PlayerMovement.getPosition());
                }

            }
            else
            {
                //tell sprite how to draw
                sprite.Draw(spriteBatch, "still", PlayerMovement.getLinkDirection(), PlayerMovement.getPosition());

            }


        }

        //Decide which way to go about drawing based on which weapon needs to be drawn
        //on the screen
        private static void DrawBasedOnAttackType(SpriteBatch spriteBatch)
        {
            
            
            //draw link with attack frames
            sprite.Draw(spriteBatch, "attack", PlayerMovement.getLinkDirection(), PlayerMovement.getPosition());
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

        public static void damage()
        {
            isDamaged = true;
            DamageInvincibility();

            AudioManager.PlaySoundEffect(linkHurt);
        }
        
        //duplicate??
        public static Vector2 getUserPos()
        {

            return new Vector2(PlayerMovement.getPosition().X, PlayerMovement.getPosition().Y);
        }
        

        private static int CleanDirection()
        {
            int direction = PlayerMovement.getLinkDirection();
            switch (PlayerMovement.getLinkDirection())
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


        //got
        public static void setPosition(Vector2 newPostion)
        {
            PlayerMovement.setPosition(newPostion);
        }

        //got
        //duplicate needed
        public static Vector2 getPosition()
        {
            return PlayerMovement.getPosition();
        }

        //got
        public static bool getPlayerAttackingState()
        {
            return Player.isAttacking;
        }

        public static int getDirection()
        {
            return PlayerMovement.getLinkDirection();
        }

    }
}


