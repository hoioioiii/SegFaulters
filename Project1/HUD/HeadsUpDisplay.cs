using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.HUD
{
	public class HeadsUpDisplay : IHUD
	{
		private IHUDEntity location;
        private IHUDEntity inventory;
        private IHUDEntity health;

        private static bool isFullMenu;

        public HeadsUpDisplay(GraphicsDevice graphics, ContentManager content)
		{
            isFullMenu = false;
            location = new LocationDisplay(graphics);
            inventory = new InventoryDisplay(graphics);
            health = new HealthDisplay(graphics);

        }

        public void Update(bool fullMenu)
        {
            isFullMenu = fullMenu;
            location.Update();
            inventory.Update();
            health.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            location.Draw(spriteBatch);
            inventory.Draw(spriteBatch);
            health.Draw(spriteBatch);
        }

        public static bool IsFullMenuDisplay()
        {
            return isFullMenu;
        }
	}
}

