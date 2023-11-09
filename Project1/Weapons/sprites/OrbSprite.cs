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
        private int weaponX;
        private int weaponY;

        private bool orbPlaced;
        private int current_frame;

        private int elapsedTime;

        private int width;
        private int height;

        private bool completed;
        private ORB_DIRECTION orbType;
        private int offset;
        public OrbSprite(Texture2D[] spriteSheet,(int,int) pos, ORB_DIRECTION orbType)
        {
            texture = spriteSheet;
            current_frame = 0;
            elapsedTime = 0;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;

            this.orbType = orbType;
            this.weaponX = pos.Item1; 
            this.weaponY = pos.Item2;

            orbPlaced = false;
            completed = false;

            

        }

        private void setOrb()
        {
            if(!completed)
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

        private void drawItem(int x, int y, SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width * LARGER_SIZE, height * LARGER_SIZE);
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Attack();
            if (orbPlaced)
            {
                drawItem(weaponX, weaponY, spriteBatch);
            }
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

                    weaponY += -1 * offset;
                    break;
                case ORB_DIRECTION.MIDDLE:
                    weaponY += 0 * offset;
                    break;
                case ORB_DIRECTION.BOTTOM:
                    weaponY += 2 * offset;
                    break;
            }
        }
       

        private int filterPlayerPosition()
        {
            int playerY = (int)Player.getPositionAndRectangle().Location.Y;

            //Change in the future:
            //Later change it so in the future, if the player is farther. Have the y have a smaller slope
            if(playerY < weaponY)
            {
                offset = -1;
            }
            else
            {
                offset = 1;
            }
           
            return offset;

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

        

        public bool finished()
        {
            return completed;
        }

        private bool FinishConditions()
        {
            
            //If it collides with a wall,
            if (CheckBoundary(weaponX, roomBoundsMaxX, roomBoundsMinX) || CheckBoundary(weaponY, roomBoundsMaxY, roomBoundsMinY))
            {
                return true;
            }

            //if the time slot is up
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= 5000)
            {
                return true; 
            }
            return false;
        }

        private bool CheckBoundary(int pos, int upperBound, int lowerBound)
        {
            if((pos >= upperBound) || (pos <= lowerBound))
            {
                return true;
            }
            return false;
        }

       
        private void checkFinish()
        { 
            if (FinishConditions())
            {
                removeOrb();
                completed = true;
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
    }
}
