using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    internal class ArrowSpritePlayer : ISpriteWeapon
    {

        private Texture2D[] texture = new Texture2D[4];
        private int userX;
        private int userY;
        private int weaponX;
        private int weaponY;

        private bool ArrowPlaced;
        private int direction;
        private int current_frame;
        private int total_frame;

        private int elapsedTime;
        private int fps;

        private int width;
        private int height;

        private int spd;

        private bool completed;
        private Rectangle rec;
        public static bool remainOnScreen { get; private set; }

        public ArrowSpritePlayer(Texture2D[] spriteSheet)
        {
            texture = spriteSheet;
            ArrowPlaced = false;
            total_frame = W_DEFAULT_FRAMES;
            current_frame = 0;
            fps = W_DEFAULT_FPS;

            completed = false;
            spd = W_DEFAULT_SPD;
        }


        /*
         * Arrow has been created
         */
        public void setArrow()
        {
            ArrowPlaced = true;
        }

        /*
         * To know when arrow should be removed
         */
        private void removeArrow()
        {
            ArrowPlaced = false;
            completed = true;
        }

        //ignore
        private void UpdateFrames()
        {

        }

        /*
         * Attack
         */
        public void Attack()
        {

            DetermineWeaponState();
            setArrow();

        }

        /*
         * Get info for weapon direction
         */
        private void DetermineWeaponState()
        {
            if (!ArrowPlaced)
            {
                GetUserPos();
                GetUserState();
                placeOffset();
            }
        }

        /*
         * Update movement
         */
        public void Update()
        {
            Attack();
            Move();
        }

        /*
         * inital distiance away from user
         */
        private void placeOffset()
        {
            (int, int) pos = WeaponDirectionMovement.SwordOffSetX(userX, userY, direction);

            weaponX = pos.Item1;
            weaponY = pos.Item2;
        }

        /*
         * Draw
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width * LARGER_SIZE, height * LARGER_SIZE);
            rec = DEST_REC;
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
        public Rectangle GetRectangle()
        {
            return rec;
        }
        /*
         * Get user x and y at teh momemnt of attk
         */
        private void GetUserPos()
        {
            Vector2 posVec = Player.getUserPos();
            userX = (int)posVec.X;
            userY = (int)posVec.Y;
        }

        /*
         * Get user directions
         */
        private void GetUserState()
        {
            direction = Player.getUserDirection();


            switch (direction)
            {
                case 0:
                    current_frame = FRAME_UP;

                    break;
                case 1:
                    current_frame = FRAME_RIGHT;
                    break;

                case 2:
                    current_frame = FRAME_DOWN;

                    break;
                case 3:
                    current_frame = FRAME_LEFT;

                    break;
            }
            width = texture[current_frame].Width;
            height = texture[current_frame].Height;

        }
        /*
         * Arrow moves accross screen
         */
        private void Move()
        {
           
            if (direction == UP || direction == DOWN)
            {
                weaponY = WeaponDirectionMovement.moveY(weaponY, direction,spd);
            }
            else
            {
              weaponX = WeaponDirectionMovement.moveX(weaponX, direction,spd);
            }

            if (CheckPosition())
            {
                removeArrow();
            }
        }

        private bool CheckPosition()
        {
            if (WeaponDirectionMovement.CheckBoundary(weaponX, roomBoundsMaxX, roomBoundsMinX) || WeaponDirectionMovement.CheckBoundary(weaponY, roomBoundsMaxY, roomBoundsMinY))
            {
                return true;
            }
            return false;

        }

        public void GetUserPos(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void GetUserState(Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public bool finished()
        {
            return completed;
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
