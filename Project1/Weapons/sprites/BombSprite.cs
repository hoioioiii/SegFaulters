using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    internal class BombSprite : ISpriteWeapon
    {
        private Texture2D[] Texture { get; set; }

        private Texture2D[] texture;
        private int userX;
        private int userY;
        private int weaponX;
        private int weaponY;
        private bool bombPlaced;
        private bool explode;
        private int direction;
        private int current_frame;
        private int total_frame;

        private int elapsedTime;
        private int fps;

        private int width;
        private int height;

        private Rectangle rec;
        private bool finishAndRemove;
        private TimeSpan time;

        private static int onScreen;
        public static bool remainOnScreen { get; private set; }
        public BombSprite(Texture2D[] spriteSheet) {
            texture = spriteSheet;
            bombPlaced = false;
            explode = false;
            total_frame = W_DEFAULT_FRAMES;
            current_frame = 0;
            fps = B_DEFAULT_FPS;
            
            onScreen = 0;
            
            remainOnScreen = true;
            finishAndRemove = false;

            DetermineWeaponState();
        }

        /*
         * Place bomb
         */
        public void setBomb()
        {
            bombPlaced = true;
        }

        /*
         * When to remove bomb
         */
        private void removeBomb()
        {
            bombPlaced = false;
            finishAndRemove=true;
        }

        /*
         * Explosion is over indicator
         */
        private void removeExplode()
        {
            explode = false;
        }

        /*
         * Next frame needs to explode
         */
        private void setExplode()
        {
            explode = true;
        }

        
        /*
         * Give a wait time b4 explode animation
         */
        private bool waitExplode()
        {
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

            if (elapsedTime > fps) {
                return false;
        }
            return true;
        }




        /*
         * Update explosion
         */
        private void UpdateFrames()
        {
            if (!waitExplode())
            {
                current_frame += 1;
                setExplode();
                if (current_frame >= total_frame) {
                    current_frame = 0;
                    removeBomb();
                    removeExplode();
                }
            }
        }

        /*
         * Place the bomb
         */
        public void Attack()
        {
            setBomb();
        }

        /*
         * Get bomb info 
         */

        private void DetermineWeaponState()
        {
            if(!bombPlaced) {
                GetUserPos();
                GetUserState();
                placeOffset();
            }
        }


        /*
         * Update bomb frams=es
         */
        public void Update()
        {
            UpdateFrames();
        }


        /*
         * How far from user to place bomb
         */
        private void placeOffset()
        {
            weaponX = WeaponDirectionMovement.OffsetX(userX, direction);
            weaponY = WeaponDirectionMovement.OffsetY(userY, direction);
        }

        public void timer(GameTime gameTime)
        {
            onScreen += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
        }



        /*
         * 
         * Draw Bomb
         */
        public void Draw(SpriteBatch spriteBatch)
        {
                width = texture[current_frame].Width;
                height = texture[current_frame].Height;
                Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
                Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width *LARGER_SIZE, height * LARGER_SIZE);
            rec = DEST_REC;
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

        public Rectangle GetRectangle()
        {
            return rec;
        }
        /*
         * Get User Pos
         */
        private void GetUserPos()
        {
            Vector2 posVec = Player.getUserPos();
            userX = (int)posVec.X;
            userY = (int)posVec.Y;
        }


        /*
         * Get user direction
         */
        private void GetUserState()
        {
            direction = Player.getUserDirection();
}

        private void Load()
        {
            throw new NotImplementedException();
        }

        private void Move()
        {
            throw new NotImplementedException();
        }

        public void GetUserPos(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void GetUserState(Direction direct)
        {
            throw new NotImplementedException();
        }

        public bool finished()
        {
            return finishAndRemove;
        }

        public Rectangle getDetectionFieldRectangle()
        {
            throw new NotImplementedException();
        }

        public void MovementChange(bool detected)
        {
            throw new NotImplementedException();
        }

        public void setTarget(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
