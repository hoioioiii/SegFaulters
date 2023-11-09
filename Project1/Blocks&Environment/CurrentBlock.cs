using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    internal class CurrentBlock : IEnvironment
    {

        private Texture2D texture;
        private int posX;
        private int posY;
        private bool canCollide;
        private string name;

        private Rectangle tempBoundingBox;

        public CurrentBlock(Texture2D text, int posX, int posY, bool canCollide, string name)
        {
            this.name = name;
            //if its blackroom; temp solution, potential refactor later.
            if (name == "BlackRoom")
            {
                int width = BLOCK_DIMENSION * 12;
                int height = BLOCK_DIMENSION * 7;
                tempBoundingBox = new Rectangle(posX, posY, width, height);
            }
            else
            {
                tempBoundingBox = new Rectangle(posX, posY, BLOCK_DIMENSION, BLOCK_DIMENSION);

            }

            //for carpet, dont have a bounding box so there is no collision.
            if (canCollide)
                BoundingBox = tempBoundingBox;

            texture = text;
            this.posX = posX;
            this.posY = posY;
        }
        public Rectangle BoundingBox { get; private set; }

        public int destinationRoom { get; private set; }

        public DIRECTION direction => throw new NotImplementedException();

        public void Update()
        {
        }

        public void CanCollideFalse()
        {
            canCollide = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (name != "Invisible")
                spriteBatch.Draw(texture, tempBoundingBox, Color.White);
        }
    }
}
