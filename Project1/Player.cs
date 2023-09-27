using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Player
    {
        Vector2 position;

        // replace magic numbers
        private int positionX = 250;
        private int positionY = 250;

        // cardinal direction player is facing, starts with up on 1 and progresses clockwise (e.g. 4 is left-facing)
        private int direction = 3;

        // frames used for still and animation
        public Texture2D linkRight1;
        public Texture2D linkLeft1;
        public Texture2D linkUp1;
        public Texture2D linkDown1;

        // frames used for animation only
        public Texture2D linkRight2;
        public Texture2D linkLeft2;
        public Texture2D linkUp2;
        public Texture2D linkDown2;
        
        //currentFrame is used to keep track of which frame of the animation we are currently on
        private int currentFrame;

        //totalFrames keeps track of how many frames there are in total
        private int totalFrames = 2;

        //Remove later-------
        private Game1 game1;
        //private ContentManager ContentLoad;

        // speed of the animation
        private int speed;

        //Later create a animation tracker class:
        private int width;
        private int height;
        
        //Movement:
        private int posX;
        private int posY;

        public Player()
        {
            //remove later:
            //Game1 game1 = new Game1();
            //linkRight1 = Load("ZeldaSpriteLinkRight");
            

        }

        //change the current frame to the next frame
        public void Update()
        {
            Move();
            currentFrame += speed;
            if (currentFrame >= totalFrames)
                currentFrame = 0;
        }

        private void Animate()
        {
            width = linkRight1.Width;
            height = linkRight1.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            // TODO: refactor
            Rectangle sourceRect = new Rectangle(width, height, width, height);
            Rectangle destRect = new Rectangle(posX, posY, width, height);
            spriteBatch.Draw(linkRight1, destRect, sourceRect, Color.White);

        }
        

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load(string texName)
        {
            return game1.Content.Load<Texture2D>(assetName: texName);
        }

        public void Move()
        {
            int directionX = 0;
            int directionY = 0;

            
        }

        public void Health()
        {
            // Check health
            // doesn't need to be implemented in sprint 2
        }

        public void Attack()
        {
            // Attacks

            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box

        }
    }
}
