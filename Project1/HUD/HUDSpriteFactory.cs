using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.HUD
{
    public class HUDSpriteFactory
    {

        private Texture2D[] locationSpriteStorage = new Texture2D[2];
        private Texture2D[] inventorySpriteStorage = new Texture2D[2];
        private Texture2D[] healthSpriteStorage = new Texture2D[2];

        private static HUDSpriteFactory instance = new HUDSpriteFactory();

        public static HUDSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
        }

        public IHUDEntity CreateLocationDisplay()
        {
            return new LocationDisplay();
        }
        public IHUDEntity CreateHealthDisplay()
        {
            return new HealthDisplay();
        }
        public IHUDEntity CreateInventoryDisplay()
        {
            return new InventoryDisplay();
        }
    }
}

