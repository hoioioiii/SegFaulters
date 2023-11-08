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
    internal class OrbSprite : ISpriteWeapon
    {

        private Texture2D[] texture;
        private int userX;
        private int userY;

        private int weaponX;
        private int weaponY;

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


        private bool completed;
        public OrbSprite(Texture2D[] spriteSheet,(int,int) pos, ORB_DIRECTION orbType)
        {
            texture = spriteSheet;
            orbPlaced = false;
            total_frame = 1;
            current_frame = 0;
            fps = 300;
            elapsedTime = 0;
            onScreen = 0;
            offsetX = 0;
            offsetY = 0;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;


            completed = false;

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
             
               placeOffset();
                    
            }  
        }




        public void Update()
        {
            Move();

        }
       

        private void placeOffset()
        {
            weaponX = WeaponDirectionMovement.DirectionOffsetX(userX, 4);
            weaponY = WeaponDirectionMovement.DirectionOffsetY(userY, 3);

            //weaponX_2 = WeaponDirectionMovement.DirectionOffsetX(userX, 4);
            //weaponY_2 = WeaponDirectionMovement.DirectionOffsetY(userY, 0);
            //weaponX_1 = WeaponDirectionMovement.DirectionOffsetX(userX, 4);
            //weaponY_1 = WeaponDirectionMovement.DirectionOffsetY(userY, 1);

        }

        public void drawItem(int x, int y, SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(x, y, width, height);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }


        public void Draw(SpriteBatch spriteBatch)
        {


            if (orbPlaced)
            {
                drawItem(weaponX, weaponY, spriteBatch);

            }
               
                //drawItem(weaponX_2, weaponY_2, spriteBatch);
                //drawItem(weaponX_3, weaponY_3, spriteBatch);
           
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
            //sWITCH THIS BASED ON DIRECTION
            switch (orbNum)
            {
                //this is orb 1
                case 1:

                    weaponX += -1;
                    break;
                //case 2:

                //    weaponX_2 += -1;
                //    break;
                //case 3:

                //    weaponX_3 += -1;
                //    break;
            }
        }

        private void filterMovementY(int orbNum)
        {

            switch (orbNum)
            {
                case 1:

                    weaponY += -1;
                    break;
                //case 2:
                //    weaponY_2 += 0;
                //    break;
                //case 3:
                //    weaponY_3 += 1;
                //    break;
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
            checkFinish();
            filterMoveAll(1);
            //filterMoveAll(2);
            //filterMoveAll(3);
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

        private void checkFinish()
        {
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

            if (elapsedTime >= 1000)
            {
                removeOrb();
                completed = true;

            }
        }
    }
}
