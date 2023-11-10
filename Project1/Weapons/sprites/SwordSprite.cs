/*
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1.Weapons.sprites
{
	public class SwordSprite : ISpriteWeapon
	{
        public Rectangle BoundingBox { get; set; }
        private String userState;
        private String weaponState;

        private int userPosX;
        private int userPosY;
        private Texture2D[] texture;

        private static int swordScale = 4;

        private int swordOffsetX;

        private int swordOffsetY;

        public SwordSprite(Texture2D[] spriteSheet)
		{
            texture = spriteSheet;
		}

        public static void Draw(Vector2 position, int linkDirection)
        {
            //sprite.Draw(Game1._spriteBatch);
            // Attacks
            switch (linkDirection)
            {
                case 1:
                    swordOffsetX = 0;
                    swordOffsetY = -50;
                    break;
                case 2:
                    swordOffsetX = 50;
                    swordOffsetY = 25;
                    break;
                case 3:
                    swordOffsetX = 25;
                    swordOffsetY = 60;
                    break;
                case 4:
                    swordOffsetX = -50;
                    swordOffsetY = 25;
                    break;
            }
            DrawSword(texture[linkDirection], position, swordOffsetX, swordOffsetY);

            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box
        }
        public static void DrawSword(Texture2D tex, Vector2 position, int offsetX, int offsetY)
        {
            // Attacks
            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X + offsetX, (int)position.Y + offsetY, tex.Width * swordScale, tex.Height * swordScale), Color.White);
            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box
        }
    }
}

*/

using System;
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
    internal class SwordSpritePlayer : ISpriteWeapon
    {

        private Texture2D[] texture = new Texture2D[4];
        private int userX;
        private int userY;
        private int weaponX;
        private int weaponY;

        public bool swordPlaced { get; private set; }
        private int direction;
        private int current_frame;
        private int total_frame;

        private int elapsedTime;
        private int fps;

        private int width;
        private int height;

        private int offsetX;
        private int offsetY;

        private Rectangle rec;


        public bool isAttacking;

        public SwordSpritePlayer(Texture2D[] spriteSheet)
        {
            texture = spriteSheet;
            swordPlaced = false;
            total_frame = 2;
            current_frame = 0;

            
            offsetX = 0;
            offsetY = 0;


            GetUserState();
            isAttacking = Player.getPlayerAttackingState();
        }


        /*
         * Arrow has been created
         */
        public void SetSword()
        {
            swordPlaced = true;
        }

        /*
         * To know when sword should be removed from the active objects list
         */
        private void RemoveSword()
        {
            swordPlaced = false;
            
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
            SetSword();

        }

        /*
         * Get info for weapon direction
         */
        private void DetermineWeaponState()
        {
                GetUserPos();
                GetUserState();
                placeOffset();
                GetUserAttackingState();
        }

        /*
         * Update movement
         */
        public void Update()
        {
            Attack();
        }

        /*
         * inital distiance away from user
         */
        private void placeOffset()
        {
           (int,int) pos = WeaponDirectionMovement.SwordOffSetX(userX,userY, direction);

            weaponX = pos.Item1;
            weaponY = pos.Item2;


        }

        /*
         * Draw
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            
                width = texture[current_frame].Width;
                height = texture[current_frame].Height;
                //System.Diagnostics.Debug.WriteLine("X,Y", userX, userY);
                Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
                Rectangle DEST_REC = new Rectangle(weaponX,weaponY, width * SWORD_SCALE, height * SWORD_SCALE);
            rec = DEST_REC;
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
         * Get user directions -> change name
         */
        private void GetUserState()
        {
            direction = Player.getUserDirection();
            current_frame = direction;

            //right = 0, left = 1, up = 2, down = 3
            switch (direction)
            {
                case 0:
                    current_frame = 0;
                    break;
                case 1:
                    current_frame = 1;
                    break;
                case 2:
                    current_frame = 2;
                    break;
                case 3:
                    current_frame = 3;
                    break;
            }
        }

        private void GetUserAttackingState()
        {
            isAttacking = Player.getPlayerAttackingState();
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
            if (!isAttacking) return true;
            return false;
        }

        public Rectangle GetRectangle()
        {
            return rec;
        }
    }
}


