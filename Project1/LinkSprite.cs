using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;
using static Project1.Constants;

namespace Project1
{
    public class LinkSprite : IPlayerSprite
    {
        private Texture2D Texture { get; set; }

        //rows is the number of rows i the texture alias
        private int Rows { get; set; }

        //Columns is the number of columns in the alias
        private int Columns { get; set; }

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private double current_frame { get; set; }

        //totalFrames keeps track of how many frames there are in total
        private int total_frame { get; set; }

        //scaling factor
        private static int spriteScale = 4;

        //tells us which directio it is facing
        public static int linkDirection = 2;

        private static Texture2D[] stillFrames = new Texture2D[PLAYER_FRAMES];
        private static Texture2D[] movingFrames = new Texture2D[PLAYER_FRAMES];
        private static Texture2D[] attackFrames = new Texture2D[PLAYER_FRAMES];

        private Texture2D[] currentFrames = new Texture2D[PLAYER_FRAMES];

        private int pos_x { get; set; }
        private int pos_y { get; set; }

        //store position
        private static Vector2 position;

        private int width;
        private int height;

        private int row;
        private int col;

        public LinkSprite(Texture2D[] one, Texture2D[] two, Texture2D[] attack)
        {
            stillFrames = one;
            movingFrames = two;
            attackFrames = attack;

            total_frame = Rows * Columns;
            current_frame = START_FRAME;

            Rows = PLAYER_R;
            Columns = PLAYER_FRAMES;
        }

        public void Update(int direction, Vector2 pos)
        {
            linkDirection = direction;
            position = pos;

            Move();
            current_frame += FRAME_SPD;
            if (current_frame >= total_frame)
                current_frame = START_FRAME;
        }

        public void Move()
        {
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
                    //currentFrames = stillFrames;
                    break;

            }
        }

        public void Draw(SpriteBatch spriteBatch, string _type)
        {
            setCurrentFrames(_type);
            Rectangle DEST_REC;
            Rectangle SOURCE_REC;
            switch (linkDirection)
            {
               case 1:
                        //DrawLink(linkAttackUp);
                    DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[(int)DIRECTION.up].Width * spriteScale, currentFrames[(int)DIRECTION.up].Height * spriteScale);
                    SOURCE_REC = new Rectangle(0, 0, currentFrames[(int)DIRECTION.up].Width, currentFrames[(int)DIRECTION.up].Height);
                    spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
                        //spriteBatch.Draw(currentFrames[(int)DIRECTION.up], new Rectangle((int)position.X, (int)position.Y, tex.Width * spriteScale, tex.Height * spriteScale), Color.White);
                    break;
               case 2:
                    //DrawLink(linkAttackRight);
                    DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[(int)DIRECTION.right].Width * spriteScale, currentFrames[(int)DIRECTION.right].Height * spriteScale);
                    SOURCE_REC = new Rectangle(0, 0, currentFrames[(int)DIRECTION.right].Width, currentFrames[(int)DIRECTION.right].Height);
                    spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
                    break;
               case 3:
                    //DrawLink(linkAttackDown);
                    DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[(int)DIRECTION.down].Width * spriteScale, currentFrames[(int)DIRECTION.down].Height * spriteScale);
                    SOURCE_REC = new Rectangle(0, 0, currentFrames[(int)DIRECTION.down].Width, currentFrames[(int)DIRECTION.down].Height);
                    spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
                    break;
               case 4:
                    //DrawLink(linkAttackLeft);
                    DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[(int)DIRECTION.left].Width * spriteScale, currentFrames[(int)DIRECTION.left].Height * spriteScale);
                    SOURCE_REC = new Rectangle(0, 0, currentFrames[(int)DIRECTION.left].Width, currentFrames[(int)DIRECTION.left].Height);
                    spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
                    break;
               default:
                    //DrawLink(linkAttackRight);
                    DEST_REC = new Rectangle((int)position.X, (int)position.Y, currentFrames[(int)DIRECTION.right].Width * spriteScale, currentFrames[(int)DIRECTION.right].Height * spriteScale);
                    SOURCE_REC = new Rectangle(0, 0, currentFrames[(int)DIRECTION.right].Width, currentFrames[(int)DIRECTION.right].Height);
                    spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
                    break;
            }
            //Rectangle SOURCE_REC = new Rectangle(width * col, height * row, width, height);
            //Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            //spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
        }
    }
}
