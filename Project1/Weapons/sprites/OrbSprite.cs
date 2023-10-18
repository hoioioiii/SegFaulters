using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class OrbSprite : ISpriteWeapon
    {

        private Texture2D[] texture;
        private int userX;
        private int userY;

        private int weaponX_1;
        private int weaponY_1;

        private int weaponX_2;
        private int weaponY_2;

        private int weaponX_3;
        private int weaponY_3;

        private bool orbPlaced;
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

        public OrbSprite(Texture2D[] spriteSheet)
        {
            texture = spriteSheet;
            orbPlaced = false;
            total_frame = 1;
            current_frame = 0;
            fps = 300;

            onScreen = 0;
            offsetX = 0;
            offsetY = 0;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;

        }

        public void setOrb()
        {
            orbPlaced = true;
        }
        private void removeOrb()
        {
            orbPlaced = false;
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
            //if (!waitExplode())
            //{
            //    current_frame += 1;
            //    setExplode();
            //    if (current_frame >= total_frame) {
            //        current_frame = 0;
            //        removeBomb();
            //        removeExplode();
            //    }
            //}
        }

        public void Attack()
        {

            DetermineWeaponState();
            setOrb();

        }

        private void DetermineWeaponState()
        {
            if (!orbPlaced)
            {
                GetUserPos();
                GetUserState();
                placeOffset();
            }
        }




        public void Update()
        {
            Move();

        }
        private void placeOffset()
        {
            weaponX_3 = DirectionManager.DirectionOffsetX(userX, 4);
            weaponY_3 = DirectionManager.DirectionOffsetY(userY, 3);

            weaponX_2 = DirectionManager.DirectionOffsetX(userX, 4);
            weaponY_2 = DirectionManager.DirectionOffsetY(userY, 0);
            weaponX_1 = DirectionManager.DirectionOffsetX(userX, 4);
            weaponY_1 = DirectionManager.DirectionOffsetY(userY, 1);

        }

        public void drawItem(int x, int y, SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(x, y, width, height);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
                drawItem(weaponX_1, weaponY_1, spriteBatch);
                drawItem(weaponX_2, weaponY_2, spriteBatch);
                drawItem(weaponX_3, weaponY_3, spriteBatch);
           
        }
        private void GetUserPos()
        {

            //FiXLater
            ////change later
            // int posVec = BossFireDragonSprite.getPos().Item1;
            //userX = (int)posVec.X;
            //userY = (int)posVec.Y;

            //temp remove later
            userX = 1;
            userY = 1;

        }

        /*
         * filters movement for each orb:
         * 
         */
        private void filterMovementX(int orbNum)
        {
            switch (orbNum)
            {
                //this is orb 1
                case 1:

                    weaponX_1 += -1;
                    break;
                case 2:

                    weaponX_2 += -1;
                    break;
                case 3:

                    weaponX_3 += -1;
                    break;
            }
        }

        private void filterMovementY(int orbNum)
        {

            switch (orbNum)
            {
                case 1:

                    weaponY_1 += -1;
                    break;
                case 2:
                    weaponY_2 += 0;
                    break;
                case 3:
                    weaponY_3 += 1;
                    break;
            }
        }
        private void GetUserState()
        {
            //TODO:FIX LATER
            //direction = BossFireDragonSprite.getDirection();
            direction = 1;

        }
        private void Load()
        {
            throw new NotImplementedException();
        }
        private void filterMoveAll(int orbNum)
        {
            filterMovementX(orbNum);
            filterMovementY(orbNum);
        }
        private void Move()
        {
            filterMoveAll(1);
            filterMoveAll(2);
            filterMoveAll(3);
        }
    }
}
