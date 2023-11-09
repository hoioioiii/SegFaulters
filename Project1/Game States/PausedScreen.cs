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
        public static IPaused pausedInventory { get; set; }
        public PausedScreen(GraphicsDevice graphics, ContentManager content)
        {
            pausedInventory = new PausedInventory(graphics, content);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            pausedInventory.Draw(spritebatch);

        }


        public void moveSelectorRight()
        {
            pausedInventory.moveSelectorRight();

        }
        public void moveSelectorLeft()
        {
            pausedInventory.moveSelectorLeft();

        }
    }
}
