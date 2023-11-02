using System;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.HUD
{
	public class HeadsUpDisplay : IHUD
	{
		private IHUDEntity location;
        private IHUDEntity inventory;
        private IHUDEntity health;

        private static bool isFullMenu;

        public HeadsUpDisplay()
		{
            location = new LocationDisplay();
            inventory = new InventoryDisplay();
            health = new HealthDisplay();
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

