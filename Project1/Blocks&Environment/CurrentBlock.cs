using System;
using System.Collections.Generic;
using System.Linq;
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

        private Rectangle tempBoundingBox;

        public CurrentBlock(Texture2D text, int posX, int posY, bool canCollide)
        {
            tempBoundingBox = new Rectangle(posX, posY, BLOCK_DIMENSION, BLOCK_DIMENSION);
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
            spriteBatch.Draw(texture, tempBoundingBox, Color.White);
        }
    }
}
