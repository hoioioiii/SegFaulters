/*
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1.Weapons.sprites
{
	public class SwordSprite : ISpriteWeapon
	{
        public Rectangle BoundingBox { get; set; }
        private String userState;
        private String weaponState;

        private int userPosX;
        private int userPosY;
        private Texture2D[] texture;

        private static int swordScale = 4;

        private int swordOffsetX;

        private int swordOffsetY;

        public SwordSprite(Texture2D[] spriteSheet)
		{
            texture = spriteSheet;
		}

        public static void Draw(Vector2 position, int linkDirection)
        {
            //sprite.Draw(Game1._spriteBatch);
            // Attacks
            switch (linkDirection)
            {
                case 1:
                    swordOffsetX = 0;
                    swordOffsetY = -50;
                    break;
                case 2:
                    swordOffsetX = 50;
                    swordOffsetY = 25;
                    break;
                case 3:
                    swordOffsetX = 25;
                    swordOffsetY = 60;
                    break;
                case 4:
                    swordOffsetX = -50;
                    swordOffsetY = 25;
                    break;
            }
            DrawSword(texture[linkDirection], position, swordOffsetX, swordOffsetY);

            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box
        }
        public static void DrawSword(Texture2D tex, Vector2 position, int offsetX, int offsetY)
        {
            // Attacks
            Game1._spriteBatch.Draw(tex, new Rectangle((int)position.X + offsetX, (int)position.Y + offsetY, tex.Width * swordScale, tex.Height * swordScale), Color.White);
            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box
        }
    }
}

*/