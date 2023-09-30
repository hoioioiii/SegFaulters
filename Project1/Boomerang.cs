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

namespace Project1
{
    internal class Boomerang : IWeaponProjectile
    {
        //private static Texture2D[] boomerangTex;
        private static Texture2D boomerangTex1;
        private static Texture2D boomerangTex2;
        private static Texture2D boomerangTex3;
        private static Texture2D boomerangTex4;

        private bool activeAttack;

        private int userDirection;

        private Vector2 userPosition;

        private Vector2 projectilePosition;

        private static int scale = 4;

        private int currFrame;
        private int totalFrame;

        // timer
        //private static float boomerangTimer;

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
                
                
            }
        }


        public static void LoadContent(ContentManager content)
        {
            boomerangTex1 = content.Load<Texture2D>("boomerang1");
            boomerangTex2 = content.Load<Texture2D>("boomerang2");
            boomerangTex3 = content.Load<Texture2D>("boomerang3");
            boomerangTex4 = content.Load<Texture2D>("boomerang4");
        }

        // userScale needed to 
        // GameTime gameTime may be needed
        public void Draw(Vector2 position, int direction, int userScale)
        {
            //float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //boomerangTimer;

            //based on the direction, change the projectile position in the appropriate direction
            switch (direction) {
                case 1: //shot upwards
                    projectilePosition.X += 0; //X wont change
                    projectilePosition.Y += 10;
                    DrawBoomerang(boomerangTex1, position, projectilePosition, userScale);
                    break;
                    //other cases for each direction
            }
            
        }

        private static void DrawBoomerang(Texture2D tex, Vector2 position, Vector2 offset, int userScale)
        {
            // Attacks
            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X + (int)offset.X, (int)position.Y + (int)offset.Y, tex.Width * userScale, tex.Height * userScale), Color.White);
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
    }
}
