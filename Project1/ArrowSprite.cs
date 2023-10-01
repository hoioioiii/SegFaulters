using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class ArrowSprite: ISpriteWeapon
    {

        private Texture2D[] texture;
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

        public ArrowSprite(Texture2D[] spriteSheet) {
            texture = spriteSheet;
            ArrowPlaced = false;
            total_frame = 2;
            current_frame = 0;
            fps = 300;

            onScreen = 0;
            offsetX = 0; 
            offsetY = 0;

            width = spriteSheet[0].Width;
            height= spriteSheet[0].Height;

        }

        public void setArrow()
        {
            ArrowPlaced = true;
        }
        private void removeArrow()
        {
           ArrowPlaced = false;
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
            setArrow();

        }

        private void DetermineWeaponState()
        {
            if(!ArrowPlaced) {
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


        }

        private void Load()
        {
            throw new NotImplementedException();
        }

        private void Move()
        {
            if(direction %2 == 0)
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
