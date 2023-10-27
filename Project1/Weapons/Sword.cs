//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;

//namespace Project1
//{
//    internal class Sword : IWeapon
//    {
//        public Rectangle BoundingBox { get; set; }
//        private String userState;
//        private String weaponState;

//        private int userPosX;
//        private int userPosY;

//        private static Texture2D swordRight;
//        private static Texture2D swordLeft;
//        private static Texture2D swordUp;
//        private static Texture2D swordDown;

//        private static int swordScale = 4;

//        //private static int position;

//        //private Game1 Game;


//        public static void LoadContent(ContentManager content)
//        {
//            //Game = Game1.Game;

//            //attack using sword
//            swordRight = content.Load<Texture2D>("swordRight");
//            swordLeft = content.Load<Texture2D>("swordLeft");
//            swordUp = content.Load<Texture2D>("swordUp");
//            swordDown = content.Load<Texture2D>("swordDown");
//        }



//        public static void Draw(Vector2 position, int linkDirection)
//        {
//            // Attacks
//            switch (linkDirection)
//            {
//                case 2:
//                    int swordOffsetX = 0;
//                    int swordOffsetY = -50;
//                    DrawSword(swordUp, position, swordOffsetX, swordOffsetY);
//                    break;
//                case 0:
//                    swordOffsetX = 50;
//                    swordOffsetY = 25;
//                    DrawSword(swordRight, position, swordOffsetX, swordOffsetY);
//                    break;
//                case 3:
//                    swordOffsetX = 25;
//                    swordOffsetY = 60;
//                    DrawSword(swordDown, position, swordOffsetX, swordOffsetY);
//                    break;
//                case 1:
//                    swordOffsetX = -50;
//                    swordOffsetY = 25;
//                    DrawSword(swordLeft, position, swordOffsetX, swordOffsetY);
//                    break;
//            }

//            // render attack texture to sprite

//            // call method of attack used (e.g. sword or arrow)
//            // the sword should be a seperate object so it can have its own bounding box
//        }

//        public static void DrawSword(Texture2D tex, Vector2 position, int offsetX, int offsetY)
//        {
//            // Attacks
//            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X + offsetX, (int)position.Y + offsetY, tex.Width * swordScale, tex.Height * swordScale), Color.White);
//            // render attack texture to sprite

//            // call method of attack used (e.g. sword or arrow)
//            // the sword should be a seperate object so it can have its own bounding box
//        }

//        public void Attack()
//        {
//            throw new NotImplementedException();
//        }

//        public void DetermineWeaponState()
//        {
//            throw new NotImplementedException();
//        }

//        public void GetUserPos()
//        {
//            throw new NotImplementedException();
//        }

//        public void GetUserState()
//        {
//            throw new NotImplementedException();
//        }

//        public void Load()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update()
//        {
//            throw new NotImplementedException();
//        }

//        public void Draw()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(int x, int y, Constants.Direction direct)
//        {
//            throw new NotImplementedException();
//        }

//        public bool finished()
//        {
//            throw new NotImplementedException();
//        }

//        public void Draw(int x, int y, Constants.Direction direct)
//        {
//            throw new NotImplementedException();
//        }

//        public void Attack(int x, int y, Constants.Direction direct)
//        {
//            throw new NotImplementedException();
//        }

//        public void Draw(SpriteBatch spriteBatch)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
namespace Project1
{



    internal class Sword : IWeapon
    {
        private ISpriteWeapon sprite;

        public Rectangle BoundingBox { get; set; }
        public Sword()
        {
            sprite = WeaponSpriteFactory.Instance.CreateSwordSprite();
        }

        /*
         * Attack
         */
        public void Attack()
        {
            sprite.Attack();

        }
        /*
         * Update
         */
        public void Update()
        {

            sprite.Update();
        }
        /*
         * 
         * Draw
         */
        public void Draw()
        {

            sprite.Draw(Game1._spriteBatch);
        }

        public void GetUserPos(int x, int y)
        {
            sprite.GetUserPos(x, y);
        }

        public void GetUserState(Direction currUserDirection)
        {
            sprite.GetUserState(currUserDirection);
        }

        /*
        * Ognore--------------------
        * 
        */
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void GetUserPos()
        {
            throw new NotImplementedException();
        }

        public void GetUserState()
        {
            throw new NotImplementedException();
        }

        public void DetermineWeaponState()
        {
            throw new NotImplementedException();
        }



        public bool finished()
        {
            return sprite.finished();
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Attack(int x, int y, Direction direct)
        {
            throw new NotImplementedException();
        }
    }
}
