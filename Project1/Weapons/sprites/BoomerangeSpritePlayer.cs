using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        }

        /*
        * 
        * draw bommer
        */
        public void Draw(SpriteBatch spriteBatch)
        {
            
                Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
                Rectangle DEST_REC = new Rectangle(weaponX, weaponY, width * LARGER_SIZE, height * LARGER_SIZE);
                spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);

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

            if (direction == 1 || direction == 3)
            {
                weaponX = WeaponDirectionMovement.ForwardBack(weaponX, direction, mod);

                if (change) checkFinish(weaponX, (int)Player.getPosition().X);
            }
            else
            {
                weaponY = WeaponDirectionMovement.ForwardBack(weaponY, direction, mod);
                if (change) checkFinish(weaponY, (int)Player.getPosition().Y);
            }

        }



        //this is going to be replaced by collision response
        private void checkFinish(int wPos, int userPos)
        {
            int check = Math.Abs(wPos - userPos);

            //change later
            if (check <= 20)
            {
                removeBang();
                completed = true;
                
            }

        }
    }
}