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
        public static IPaused pausedMap { get; set; }
        public PausedScreen(GraphicsDevice graphics, ContentManager content)
        {
            pausedInventory = new PausedInventory(graphics, content);
            pausedMap = new PausedMap(graphics, content);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            pausedInventory.Draw(spritebatch);
            pausedMap.Draw(spritebatch);

        }
        public void Update()
        {
            pausedInventory.Update();
            pausedMap.Update();

        }

        public void MoveSelectorRight()
        {
            pausedInventory.MoveSelectorRight();

        }
        public void MoveSelectorLeft()
        {
            pausedInventory.MoveSelectorLeft();

        }
    }
}
