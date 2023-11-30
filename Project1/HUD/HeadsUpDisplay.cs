using System;
using Microsoft.Xna.Framework.Content;
using Color = Microsoft.Xna.Framework.Color;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
using static Project1.ICommand;
using Microsoft.Xna.Framework;

namespace Project1.HUD
{
	public class HeadsUpDisplay : IHUD
	{
		private IHUDEntity location;
        private IHUDEntity inventory;
        private IHUDEntity health;

        private Vector2 coordBase;
        private Texture2D backgroundRect;
        private Rectangle destinationBackground;
        private static bool isFullMenu;

        public HeadsUpDisplay(GraphicsDevice graphics, ContentManager content)
		{
            //black background
            isFullMenu = false;
            backgroundRect = new Texture2D(graphics, 1, 1);
            backgroundRect.SetData(new[] { Color.Black });
            coordBase = new Vector2(0, 0);
            destinationBackground = new Rectangle((int)coordBase.X, (int)coordBase.Y, SCREEN_WIDTH, HUD_HEIGHT);

            //individual components
            location = new LocationDisplay(graphics, content);
            inventory = new InventoryDisplay(graphics, content);
            health = new HealthDisplay(graphics, content);

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

        public static void StartScrolling(DIRECTION scrollDirection)
        {
            Camera.CameraTransitionCalculate(scrollDirection);
            Game1.HUDisTransitioning = true;
        }

        public static void EndScrolling()
        {
            Game1.HUDisTransitioning = false;
        }
    }
}

