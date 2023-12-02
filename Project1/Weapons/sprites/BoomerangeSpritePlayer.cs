using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.SmartAI;
using static Project1.Constants;

namespace Project1
{
    internal class BoomerangeSpritePlayer : ISpriteWeapon
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

        private int width;
        private int height;

        private int onWayTime; 
        private int mod;

        private bool completed;
        private bool change;
        private int animationTime;
        private int fps;
        private Rectangle rec;
        private IMove movementManager;


        public BoomerangeSpritePlayer(Texture2D[] spriteSheet)
        {
            //needs to be refactored 
            texture = spriteSheet;
            BangPlaced = false;
            total_frame = 4;
            current_frame = 0;
        
            mod = 1;
            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;

            animationTime = 0;
            onWayTime = 0;
            change = false;
            completed = false;
            fps = 30;


           movementManager = new WeaponMove((int)Player.getPosition().X,(int)Player.getPosition().Y);

    }

    /*
    * 
    * set Boomerange
    */
    public void setBang()
        {
            BangPlaced = true;
        }

        /*
        * 
        * remove bommereange
        */
        private void removeBang()
        {
            BangPlaced = false;
        }

        /*
        * animate boomerange
        * 
        */
        private void UpdateFrames()
        {
            animationTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

            if(animationTime >= fps) {
                current_frame += 1;

                if (current_frame >= total_frame)
                {
                    current_frame = 0;
                }
                animationTime = 0;
            }
          

        }

        /*
        * 
        * start boomerage
        */
        public void Attack()
        {

            DetermineWeaponState();
            setBang();
        }
        /*
        * 
        * get boomerange infp
        */
        private void DetermineWeaponState()
        {
            if (!BangPlaced)
            {
                GetUserPos(0, 0);
                GetUserState(Direction.Up);
                placeOffset();
            }
        }

        /*
        * 
        * update animation and move
        */
        public void Update()
        {

            Attack();
            UpdateFrames();
            Move();
        }

        /*
        * how far away to create create boomerange form user
        * 
        */
        private void placeOffset()
        {
            weaponX = WeaponDirectionMovement.OffsetX(userX, direction);
            weaponY = WeaponDirectionMovement.OffsetY(userY, direction);

            movementManager.setPosition(weaponX, weaponY);

        }

        /*
        * 
        * draw bommer
        */
        public void Draw(SpriteBatch spriteBatch)
        {
            
                Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
                Rectangle DEST_REC = new Rectangle(movementManager.getPosition().Item1, movementManager.getPosition().Item2, width * LARGER_SIZE, height * LARGER_SIZE);
            rec = DEST_REC;
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);

        }
        public Rectangle GetRectangle()
        {
            return rec;
        }

        /*
        * 
        * get user pos
        */
        public void GetUserPos(int x, int y)
        {

            Vector2 posVec = Player.getUserPos();
            userX = (int)posVec.X; userY = (int)posVec.Y;
        }

        /*
        * get user direction
        * 
        */
        public void GetUserState(Direction direct)
        {
            direction = (int)Player.getUserDirection(); ;
        }

        public bool finished()
        {
            return completed;
        }

       
        /*
        * get the time of which boomerange has been sent out from user
        * 
        */
        public void CheckTime()
        {
            onWayTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            
        }



        /*
        * 
        * move boomeange
        */
        /*
* 
* move boomeange
*/
        private void Move()
        {
            if (!change)
            {
                CheckTime();
                if (onWayTime >= 2000)
                {
                    onWayTime = 0;
                    change = true;

                    mod = mod * -1;
                }
            }

            if (!change)
            {

                //RIGHT LEFT
                if (direction == 1 || direction == 3)
                {
                    weaponX = WeaponDirectionMovement.ForwardBack(movementManager.getPosition().Item1, direction, mod);
                    movementManager.setPosition(weaponX, movementManager.getPosition().Item2);
                    // if (change) checkFinish(weaponX, (int)Player.getPosition().X);
                }
                else  //UP DOWN
                {
                    weaponY = WeaponDirectionMovement.ForwardBack(movementManager.getPosition().Item2, direction, mod);
                    movementManager.setPosition(movementManager.getPosition().Item1, weaponY); //changed item2 to item 
                    //if (change) checkFinish(weaponY, (int)Player.getPosition().Y);
                }

            }
            else
            {
                seekMovement(change);
                int yOffsetCheck = Math.Abs(movementManager.getPosition().Item2 - (int)Player.getPosition().Y);
                int xOffsetCheck = Math.Abs(movementManager.getPosition().Item1 - (int)Player.getPosition().X);
                checkFinish(xOffsetCheck, yOffsetCheck);
                //checkFinish(movementManager.getPosition().Item2, (int)Player.getPosition().Y);
                //checkFinish(movementManager.getPosition().Item1, (int)Player.getPosition().X);
            }
            //movementManager.setPosition(weaponX, weaponY);

        }

        private void seekMovement(bool isReturning)
        {
           
                Vector2 position = new Vector2(movementManager.getPosition().Item1, movementManager.getPosition().Item2);
                SeekPlayer.Move(position,movementManager,SMARTAI_USER.WEAPON);
            
        }



        //this is going to be replaced by collision response
        private void checkFinish(int xOffsetCheck, int yOffsetCheck)
        {
            if (!completed)
            {
                if (xOffsetCheck <= 10 && yOffsetCheck <= 10)
                {
                    removeBang();
                    completed = true;
                }
            }
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