using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class CurrentBlock : IEnvironment
    {

        private Texture2D texture;
        private int posX;
        private int posY;

        public CurrentBlock(Texture2D text, int posX, int posY)
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
            //114 75
            spriteBatch.Draw(texture, new Rectangle(posX, posY, 48, 48),Color.White);
        }
    }
}
