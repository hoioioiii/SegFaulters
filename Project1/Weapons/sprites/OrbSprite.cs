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

            //Get player position
            Move();


        }
        private void placeOffset()
        {
            //change to constants
            //Change offsets to consider player position
            //Weapons 1,2,3 should be moved out to just weapon 1 x and weapon 2 x.
            // Weapons 2 and 3 will be created as separete class orbs
            weaponX_3 = WeaponDirectionMovement.DirectionOffsetX(userX, 4);
            weaponY_3 = WeaponDirectionMovement.DirectionOffsetY(userY, 3);

            weaponX_2 = WeaponDirectionMovement.DirectionOffsetX(userX, 4);
            weaponY_2 = WeaponDirectionMovement.DirectionOffsetY(userY, 0);
            weaponX_1 = WeaponDirectionMovement.DirectionOffsetX(userX, 4);
            weaponY_1 = WeaponDirectionMovement.DirectionOffsetY(userY, 1);

        }

        public void drawOrb(int x, int y, SpriteBatch spriteBatch)
        {
           
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(x, y, width, height);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
           
            drawOrb(weaponX_1, weaponY_1, spriteBatch);
            drawOrb(weaponX_2, weaponY_2, spriteBatch);
            drawOrb(weaponX_3, weaponY_3, spriteBatch);
        }

        //Method will get player postion and start moving towards player
        private void SeekPlayer()
        {

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

        private void GetPlayerPosition()
        {
         
            //Pretend this returns a vector w player position
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
            throw new NotImplementedException();
        }
    }
}
