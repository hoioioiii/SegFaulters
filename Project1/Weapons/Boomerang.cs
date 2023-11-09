using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;
using static Project1.Constants;

namespace Project1
{
    internal class Boomerang : IWeaponProjectile
    {
        public Rectangle BoundingBox { get; set; }

        /*
         * 
         * Ignore not used.
         */
        private static Texture2D[] boomerangTex = new Texture2D[BOOMERANG_C];
        //private static Texture2D boomerangTex1;
        //private static Texture2D boomerangTex2;
        //private static Texture2D boomerangTex3;
        //private static Texture2D boomerangTex4;

        private bool activeAttack;

        private int userDirection;

        private Vector2 userPosition;

        private Vector2 projectilePosition;

        private static int scale = 4;

        private int currFrame;
        private int totalFrame;

        // timer
        private static float boomerangTimer;

        public Boomerang(Vector2 userPosition, int direction) { 
            currFrame = 0;
            totalFrame = 3;

            this.userPosition = userPosition;
            //this.userDirection = direction;

            projectilePosition = userPosition;


        }

      
        public void Attack()
        {
            if (!activeAttack) {
                this.activeAttack = true;

                AudioManager.PlaySoundEffect(boomerang);
            }
        }

        
        public static void LoadContent(ContentManager content)
        {
            boomerangTex[0] = content.Load<Texture2D>("boomerang1");
            boomerangTex[1] = content.Load<Texture2D>("boomerang2");
            boomerangTex[2] = content.Load<Texture2D>("boomerang3");
            boomerangTex[3] = content.Load<Texture2D>("boomerang4");
        }                

        // userScale needed to 
        // GameTime gameTime may be needed
        /*
        public static void Draw(Vector2 position, int direction, int userScale)
        {
            //float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //boomerangTimer;

            //based on the direction, change the projectile position in the appropriate direction
            //switch (direction)
            //{
            //    case 1: //shot upwards
            // will need to change in the future, could not implement by 
            int boomerangOffsetX = 0;
                    int boomerangOffsetY = 0;
                    DrawBoomerang(position, position, userScale);
                    //break;

//        public void GetUserState()
//        {
//            this.userState = //call a function
//        }

            //}
        }
        */

        private void Draw()
        {

        }
        private static void DrawBoomerang(Vector2 position, Vector2 offset, int userScale)
        {
            for (int i = 0; i < BOOMERANG_RANGE * userScale; i++)
            {
                int frameNumber = i % BOOMERANG_C;
                Game1._spriteBatch.Draw(boomerangTex[frameNumber], new Rectangle((int)position.X, (int)position.Y + i, boomerangTex[1].Width * userScale, boomerangTex[1].Height * userScale), Color.White);
            }
            // Attacks
            
            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box
        }

        public void Physics()
        {
            //no physics
        }

        public void DetermineWeaponState()
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

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
