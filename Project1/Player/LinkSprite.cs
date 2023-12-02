using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;
using static Project1.Constants;

namespace Project1
{
    public class LinkSprite : IPlayerSprite
    {
        //Player.cs should own linkDirection, not the sprite class
        private static int spriteScale = 3;
        //public static int linkDirection = 0;

        private static Texture2D[] stillFrames = new Texture2D[PLAYER_FRAMES];
        private static Texture2D[] movingFrames = new Texture2D[PLAYER_FRAMES];
        private static Texture2D[] attackFrames = new Texture2D[PLAYER_FRAMES];
        private Texture2D[] currentFrames = new Texture2D[PLAYER_FRAMES];

        //Player.cs should own position as well
        //private Vector2 position;

        //Maybe needs to belong to Player.cs???
        private Rectangle rect;

        //Initialize Link's frame
        public LinkSprite(Texture2D[] still, Texture2D[] move, Texture2D[] attack)
        {
            stillFrames = still;
            movingFrames = move;
            attackFrames = attack;
        }

        //Update Link's direction and position
        public void Update()
        {
        }

        private void setCurrentFrames(string type)
        {
            switch (type)
            {
                case ATTACK_LINK:
                    currentFrames = attackFrames;
                    break;
                case STILL:
                    currentFrames = stillFrames;
                    break;
                case MOVE:
                    currentFrames = movingFrames;
                    break;
                default:
                    currentFrames = stillFrames;
                    break;
            }
        }

        //Draw Link given the direction input
        private void DrawLink(SpriteBatch sprBatch, int direction, Vector2 position)
        {
            Rectangle DEST_REC;
            Rectangle SOURCE_REC;

            DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[direction].Width * spriteScale, currentFrames[direction].Height * spriteScale);
            SOURCE_REC = new Rectangle(0, 0, currentFrames[direction].Width, currentFrames[direction].Height);
            rect = DEST_REC;
            sprBatch.Draw(currentFrames[direction], DEST_REC, SOURCE_REC, Color.White);
        }

        //Decide the direction for Link's
        public void Draw(SpriteBatch spriteBatch, string _type, int direction, Vector2 location)
        {
            setCurrentFrames(_type);
            /*
            switch (linkDirection)
            {
               case 2:
                    
                    DrawLink(spriteBatch, (int)DIRECTION.up);
                    break;
               case 0:
         
                    DrawLink(spriteBatch, (int)DIRECTION.right);
                    break;
               case 3:
                    
                    DrawLink(spriteBatch, (int)DIRECTION.down);
                    break;
               case 1:
                    
                    DrawLink(spriteBatch, (int)DIRECTION.left);
                    break;
               default:
                    
                    DrawLink(spriteBatch, (int)DIRECTION.right);
                    break;
            }
            */
            DrawLink(spriteBatch, direction, location);

        }

        public Rectangle getRectangle()
        {
            return rect;

        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        /*
        public void setPosition(Vector2 pos)
        {
            this.position = pos;
        }

        public Vector2 getPosition()
        {
            return this.position;
        }
        */
    }
}
