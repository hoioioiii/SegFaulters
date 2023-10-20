using System;
using System.Collections.Generic;
using System.Linq;
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

        public CurrentBlock(Texture2D text, int posX, int posY)
        public Rectangle BoundingBox { get; set; }

        public CurrentBlock(Texture2D text)
        {
            texture = text;
            this.posX = posX;
            this.posY = posY;
        }

        public void Update()
        {
            texture = EnvironmentIterator.getCurrEnemy();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(posX, posY, BLOCK_DIMENSION, BLOCK_DIMENSION),Color.White);
        }
    }
}
