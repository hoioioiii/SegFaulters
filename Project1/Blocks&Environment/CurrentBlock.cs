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

        public Rectangle BoundingBox { get; set; }

        public CurrentBlock(Texture2D text)
        {
            texture = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, new Vector2(200,300),Color.White);
        }
    }
}
