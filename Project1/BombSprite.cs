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
    internal class BombSprite: ISpriteWeapon
    {
        private Texture2D[] Texture { get; set; }

        private Texture2D[] texture;
        private int userX;
        private int userY;
        private int weaponX;
        private int weaponY;
        private bool bombPlaced;
        private bool explode;
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

        public BombSprite(Texture2D[] spriteSheet) {
            texture = spriteSheet;
            bombPlaced = false;
            explode = false;
            total_frame = 2;
            current_frame = 0;
            fps = 300;

            onScreen = 0;
            offsetX = 0; 
            offsetY = 0;

            width = 30;
            height= 40;

        }

        public void setBomb()
        {
            bombPlaced = true;
        }
        private void removeBomb()
        {
            bombPlaced = false;
        }
        private void removeExplode()
        {
            explode = false;
        }
        private void setExplode()
        {
            explode = true;
        }

        

        private bool waitExplode()
        {
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;

            if (elapsedTime > fps) {
                return false;
        }
            return true;
        }

        private void UpdateFrames()
        {
            if (!waitExplode())
            {
                current_frame += 1;
                setExplode();
                if (current_frame >= total_frame) {
                    current_frame = 0;
                    removeBomb();
                    removeExplode();
                }
            }
        }

        public void Attack()
        {

            DetermineWeaponState();
            setBomb();

        }

        private void DetermineWeaponState()
        {
            if(!bombPlaced) {
                GetUserPos();
                GetUserState();
                placeOffset();
            }
        }

        public void Update()
        {
            UpdateFrames();

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
}

        private void Load()
        {
            throw new NotImplementedException();
        }

        private void Move()
        {
            throw new NotImplementedException();
        }
    }
}
