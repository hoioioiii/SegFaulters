﻿using System;
using System.Collections.Generic;
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

        private int offsetX;
        private int offsetY;

        private int onScreen;

        public ArrowSpritePlayer(Texture2D[] spriteSheet)
        {
            texture = spriteSheet;
            ArrowPlaced = false;
            total_frame = 2;
            current_frame = 0;
            fps = 300;

            onScreen = 0;
            offsetX = 0;
            offsetY = 0;

            //delete later
            texture[(int)DIRECTION.up] = Game1.ContentManager1.Load<Texture2D>("arrowUp");
            texture[(int)DIRECTION.right] = Game1.ContentManager1.Load<Texture2D>("arrowRight");
            texture[(int)DIRECTION.down] = Game1.ContentManager1.Load<Texture2D>("arrowDown");
            texture[(int)DIRECTION.left] = Game1.ContentManager1.Load<Texture2D>("arrowLeft");

            width = texture[0].Width;
            height = texture[0].Height;

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
            Move();
        }

        /*
         * inital distiance away from user
         */
        private void placeOffset()
        {
            weaponX = WeaponDirectionMovement.OffsetX(userX, direction);
            weaponY = WeaponDirectionMovement.OffsetY(userY, direction);
        }

        /*
         * Draw
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width, height);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
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
            current_frame = direction;

            /*
            switch (direction)
            {
                case 1:
                    current_frame = 0;
                    break;
                case 2:
                    current_frame = 1;
                    break;
                case 3:
                    current_frame = 2;
                    break;
                case 4:
                    current_frame = 3;
                    break;
            }
            */
        }
        /*
         * Arrow moves accross screen
         */
        //NEED TO FIX WEAPON-DIRECT-MOVEMENT to reflect new linkdirection variable
        private void Move()
        {
            if (direction % 2 == 0)
            {
                weaponX = WeaponDirectionMovement.FourDirMove(weaponX, direction,1);
            }
            else
            {
                weaponY = WeaponDirectionMovement.FourDirMove(weaponY, direction,1);
            }


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
