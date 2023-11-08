using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class PausedScreen
    {
        IPaused pausedInventory;
        public PausedScreen(GraphicsDevice graphics, ContentManager content)
        {
            pausedInventory = new PausedInventory(graphics, content);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            pausedInventory.Draw(spritebatch);

        }
    }
}
