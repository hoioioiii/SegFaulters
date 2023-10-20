using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Door : IEnvironment
    {
        private string direction;
        private int destinationRoom;
        private bool isLocked;
        private Texture2D texture;
        private int xPos;
        private int yPos;
        public Door(Texture2D[]textures, string direction, int destinationRoom, bool isLocked)
        {
            this.direction = direction;
            this.destinationRoom = destinationRoom;
            this.isLocked = isLocked;

            switch (direction)
            {
                case "north":
                    texture = textures[3];
                    xPos = 350;
                    yPos = 15;
                    break;
                case "south":
                    texture = textures[2];
                    xPos = 350;
                    yPos = 410;
                    break;
                case "west":
                    texture = textures[0];
                    xPos = 45;
                    yPos = 190;
                    break;
                case "east":
                    texture = textures[1];
                    xPos = 685;
                    yPos = 190;
                    break;
                default:
                    break;
            }
        }
        public Rectangle BoundingBox { get; set; }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) {
            double ratio = 1.3;
            spriteBatch.Draw(texture, new Rectangle(xPos, yPos, (int)(texture.Width * ratio), (int)(texture.Height * ratio)), Color.White);

        }
    }
}
