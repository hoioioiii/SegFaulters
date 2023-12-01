using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.SmartAI;
using static Project1.Constants;
namespace Project1
{
    internal class OrbSprite : ISpriteWeapon
    {

        private Texture2D[] texture;
      

        private bool orbPlaced;
        private int current_frame;

        private int elapsedTime;

        private int width;
        private int height;

        private bool completed;
        private ORB_DIRECTION orbType;
        private int offset;
        private Rectangle rec;
        private IMove movement_manager;
        private RangeDetectionToPlayer rangeDetector;

        public OrbSprite(Texture2D[] spriteSheet,(int,int) pos, ORB_DIRECTION orbType)
        {
            texture = spriteSheet;
            current_frame = 0;
            elapsedTime = 0;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;


            movement_manager = new WeaponMove(pos.Item1, pos.Item2);
            this.orbType = orbType;
            



            orbPlaced = false;
            completed = false;

            rangeDetector = new RangeDetectionToPlayer(movement_manager, 100);
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
            Rectangle DEST_REC = new Rectangle(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, width * LARGER_SIZE, height * LARGER_SIZE);
            rec = DEST_REC;
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
        public Rectangle GetRectangle()
        {
            return rec;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Attack();
            if (orbPlaced)
            {
                drawItem(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, spriteBatch);
            }
        }

        /*
         * filters movement for each orb:
         * 
         */
        private void filterMovementX()
        {
            
            int weaponX = movement_manager.getPosition().Item1 - 1;
            movement_manager.setPosition(weaponX, movement_manager.getPosition().Item2);
        }

        private void filterMovementY(ORB_DIRECTION type)
        {
            //this is going to need to be based on hypotenus

            int weaponY = movement_manager.getPosition().Item2;
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

            movement_manager.setPosition(movement_manager.getPosition().Item1, weaponY);
        }


        private int filterPlayerPosition()
        {
            int playerY = (int)Player.getPositionAndRectangle().Location.Y;

            //Change in the future:
            //Later change it so in the future, if the player is farther. Have the y have a smaller slope
            if(playerY < movement_manager.getPosition().Item2)
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
            if(rangeDetector.DetectionField() == RangeTypeToMovement.SEEK)
            {
                SeekPlayer.Move(movement_manager.getVector(), movement_manager, SMARTAI_USER.WEAPON);
            }
            else
            {
                filterMoveAll(orbType);
            }
            checkFinish();
        }

        

        public bool finished()
        {
            return completed;
        }

        private bool FinishConditions()
        {
            
            //If it collides with a wall,
            if (CheckBoundary(movement_manager.getPosition().Item1, roomBoundsMaxX, roomBoundsMinX) || CheckBoundary(movement_manager.getPosition().Item2, roomBoundsMaxY, roomBoundsMinY))
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
