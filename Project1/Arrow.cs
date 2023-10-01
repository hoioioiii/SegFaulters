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
    internal class Arrow : IWeaponProjectile
    {
        
        private static Texture2D arrowLeft;
        private static Texture2D arrowRight;
        private static Texture2D arrowUp;
        private static Texture2D arrowDown;

        private bool activeAttack;

        private int userDirection;

        private Vector2 userPosition;

        private Vector2 projectilePosition;

        private static int scale = 4;

        private int currFrame;
        private int totalFrame;

        // timer
        private static float boomerangTimer;

        public Arrow (Vector2 userPosition, int direction)
        {
            currFrame = 0;
            totalFrame = 3;

            this.userPosition = userPosition;
            //this.userDirection = direction;

            projectilePosition = userPosition;


        }
        public void Attack()
        {
            if (!activeAttack)
            {
                this.activeAttack = true;


            }
        }


        public static void LoadContent(ContentManager content)
        {
            arrowLeft = content.Load<Texture2D>("arrowLeft");
            arrowRight = content.Load<Texture2D>("arrowRight");
            arrowUp = content.Load<Texture2D>("arrowUp");
            arrowDown = content.Load<Texture2D>("arrowDown");
        }

        // userScale needed to 
        // GameTime gameTime may be needed
        public static void Draw(Vector2 position, int direction, int userScale)
        {
            //float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Timer;

            
            switch (direction)
            {
                case 1:
                    int offsetX = 0;
                    int offsetY = -50;
                    DrawArrow(arrowUp, position, offsetX, offsetY, userScale);
                    break;
                case 2:
                    offsetX = 50;
                    offsetY = 25;
                    DrawArrow(arrowRight, position, offsetX, offsetY, userScale);
                    break;
                case 3:
                    offsetX = 25;
                    offsetY = 60;
                    DrawArrow(arrowDown, position, offsetX, offsetY, userScale);
                    break;
                case 4:
                    offsetX = -50;
                    offsetY = 25;
                    DrawArrow(arrowLeft, position, offsetX, offsetY, userScale);
                    break;
            }
        }

            public static void DrawArrow(Texture2D tex, Vector2 position, int offsetX, int offsetY, int scale)
            {
                // Attacks
                Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X + offsetX, (int)position.Y + offsetY, tex.Width * scale, tex.Height * scale), Color.White);
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
