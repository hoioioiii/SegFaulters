using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private ORB_DIRECTION orbType;

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
            this.orbType = orbType;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;

            this.weaponX = pos.Item1; this.weaponY = pos.Item2;
            completed = false;

        }

        public void setOrb()
        {
            if(!completed)
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

            filterPlayerPosition();
        }

        public void drawItem(int x, int y, SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width, height);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }


        public void Draw(SpriteBatch spriteBatch)
        {


            Attack();
            if (orbPlaced)
            {
                drawItem(weaponX, weaponY, spriteBatch);
            }

            //drawItem(weaponX_2, weaponY_2, spriteBatch);
            //drawItem(weaponX_3, weaponY_3, spriteBatch);

        }
        private void GetUserPos()
        {

        }

        /*
         * filters movement for each orb:
         * 
         */
        private void filterMovementX()
        {
            weaponX += -1;
        
        }

        private void filterMovementY(ORB_DIRECTION type)
        {
            //this is going to need to be based on hypotenus
            switch (type)
            {
                case ORB_DIRECTION.TOP:

                    weaponY += -1;
                    break;
                case ORB_DIRECTION.MIDDLE:
                    weaponY += 0;
                    break;
                case ORB_DIRECTION.BOTTOM:
                    weaponY += 1;
                    break;
            }
        }
       

        private void filterPlayerPosition()
        {
            double playerY = (double)Player.getPositionAndRectangle().Location.Y;
            int offset = 0;

            if (Math.Floor(playerY/140) <= 0)
            {
                offset = -8;
            }else if (Math.Floor(playerY / 140) > 1)
                {
                    offset = 8 ;
            }


            weaponY += offset;
        }
       
        private void filterMoveAll(ORB_DIRECTION type)
        {
            filterMovementX();
            filterMovementY(type);
        }
        private void Move()
        {
            filterMoveAll(orbType);
            checkFinish();
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

            if (elapsedTime >= 3000)
            {
                removeOrb();
                completed = true;
            }
        }
    }
}
