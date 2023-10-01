using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class BoomerangeSprite : ISpriteWeapon
    {

        private Texture2D[] texture;
        private int userX;
        private int userY;
        private int weaponX;
        private int weaponY;

        private bool BangPlaced;
        private int direction;
        private int current_frame;
        private int total_frame;

        private int elapsedTime;
        private int fps;

        private int width;
        private int height;

        private int offsetX;
        private int offsetY;

        private int onScreen;
        private int onWayTime;
        private int awayfps;
        public BoomerangeSprite(Texture2D[] spriteSheet)
        {
            texture = spriteSheet;
            BangPlaced = false;
            total_frame = 4;
            current_frame = 0;
            fps = 300;

            onScreen = 0;
            offsetX = 0;
            offsetY = 0;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;

            awayfps = 0;
            onWayTime = 0;
        }

        public void setBang()
        {
            BangPlaced = true;
        }
        private void removeBang()
        {
            BangPlaced = false;
        }



        //private bool waitExplode()
        //{
        //    elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

        //    if (elapsedTime > fps) {
        //        return false;
        //    }
        //    return true;
        //}

        private void UpdateFrames()
        {
            current_frame += 1;

            if (current_frame >= total_frame)
            {
                current_frame = 0;
            }

        }

        public void Attack()
        {

            DetermineWeaponState();
            setBang();

        }

        private void DetermineWeaponState()
        {
            if (!BangPlaced)
            {
                GetUserPos();
                GetUserState();
                placeOffset();
            }
        }
        public void Update()
        {
            UpdateFrames();
            Move();

        }
        private void placeOffset()
        {
            weaponX = DirectionManager.OffsetX(userX, direction);
            weaponY = DirectionManager.OffsetY(userY, direction);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width, height);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
        private void GetUserPos()
        {
            Vector2 posVec = Player.getUserPos();
            userX = (int)posVec.X;
            userY = (int)posVec.Y;
        }

        private void GetUserState()
        {
            direction = Player.getUserDirection();

        }

        private void Load()
        {
            throw new NotImplementedException();
        }

        public void CheckTime()
        {
            onWayTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

        }

        private void changeDirections()
        {
            switch (direction)
            {
                case 1:

                    direction = 4;

                    break;

                case 2:
                    direction = 3;
                    break;


                case 3:
                    direction = 2;
                    break;

                case 4:
                    direction = 1;
                    break;


            }

        }

        private void Move()
        {

            //CheckTime();
            //if (onWayTime >= awayfps)
            //{
            //    changeDirections();


            //    onWayTime = 0;
            //}

            if (direction % 2 == 0)
            {
                weaponX = DirectionManager.FourDirMove(weaponX, direction);
            }
            else
            {
                weaponY = DirectionManager.FourDirMove(weaponY, direction);
            }




        }
    }
}
