using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    public class Door : IEnvironment
    {
        public DIRECTION direction { get; private set; }
        public int destinationRoom { get; private set; }
        private bool isLocked;
        private Texture2D texture;
        private int xPos;
        private int yPos;

        public Rectangle BoundingBox { get; private set; }
        public Door(Texture2D[]textures, DIRECTION direction, int destinationRoom, bool isLocked)
        {
            
            this.destinationRoom = destinationRoom - 1;
            this.isLocked = isLocked;

            switch (direction)
            {
                case DIRECTION.up:
                    texture = textures[3];
                    xPos = 350;
                    yPos = 16;
                    break;
                case DIRECTION.down:
                    texture = textures[2];
                    xPos = 350;
                    yPos = 410;
                    break;
                case DIRECTION.left:
                    texture = textures[0];
                    xPos = 45;
                    yPos = 190;
                    break;
                case DIRECTION.right:
                    texture = textures[1];
                    xPos = 685;
                    yPos = 190;
                    break;
                default:
                    break;
            }
        }
        

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) {
            double ratio = 1.3;
            BoundingBox = new Rectangle(xPos, yPos, (int)(texture.Width * ratio), (int)(texture.Height * ratio));

            spriteBatch.Draw(texture, new Rectangle(xPos, yPos, (int)(texture.Width * ratio), (int)(texture.Height * ratio)), Color.White);

        }
    }
}
