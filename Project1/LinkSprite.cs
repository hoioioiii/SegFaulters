using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;
using static Project1.Constants;

namespace Project1
{
    public class LinkSprite : IPlayerSprite
    {

        //scaling factor
        private static int spriteScale = 4;

        //tells us which directio it is facing
        public static int linkDirection = 2;

        private static Texture2D[] stillFrames = new Texture2D[PLAYER_FRAMES];
        private static Texture2D[] movingFrames = new Texture2D[PLAYER_FRAMES];
        private static Texture2D[] attackFrames = new Texture2D[PLAYER_FRAMES];

        private Texture2D[] currentFrames = new Texture2D[PLAYER_FRAMES];

        //store position
        private static Vector2 position;

        public LinkSprite(Texture2D[] one, Texture2D[] two, Texture2D[] attack)
        {
            stillFrames = one;
            movingFrames = two;
            attackFrames = attack;

        }

        public void Update(int direction, Vector2 pos)
        {
            linkDirection = direction;
            position = pos;

        }

        private void setCurrentFrames(string type)
        {
            switch (type)
            {
                case "attack":
                    currentFrames = attackFrames;
                    break;
                case "still":
                    currentFrames = stillFrames;
                    break;
                case "move":
                    currentFrames = movingFrames;
                    break;
                default:
                    currentFrames = stillFrames;
                    break;

            }
        }

        private void DrawLink(SpriteBatch sprBatch, int direction)
        {
            Rectangle DEST_REC;
            Rectangle SOURCE_REC;
            DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[direction].Width * spriteScale, currentFrames[direction].Height * spriteScale);
            SOURCE_REC = new Rectangle(0, 0, currentFrames[direction].Width, currentFrames[direction].Height);
            sprBatch.Draw(currentFrames[direction], DEST_REC, SOURCE_REC, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, string _type)
        {
            setCurrentFrames(_type);
            switch (linkDirection)
            {
                case 1:

                    DrawLink(spriteBatch, (int)DIRECTION.up);
                    break;
                case 2:

                    DrawLink(spriteBatch, (int)DIRECTION.right);
                    break;
                case 3:

                    DrawLink(spriteBatch, (int)DIRECTION.down);
                    break;
                case 4:

                    DrawLink(spriteBatch, (int)DIRECTION.left);
                    break;
                default:

                    DrawLink(spriteBatch, (int)DIRECTION.right);
                    break;
            }

        }
    }
}
