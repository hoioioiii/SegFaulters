using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Health
{
    public class HealthSystemSpriteManager
    {
        public Texture2D heartTexture { get; set; }
        public Vector2 position;
        HealthSystemSprite healthSystem;
        public HealthSystemSpriteManager(Texture2D heart, Vector2 position, HealthSystemSprite healthSystem)
        {
          this.heartTexture = heart;
            this.healthSystem = healthSystem;
            this.position = getPosition();
        }

        public Vector2 getPosition()
        {
            Vector2 position = new Vector2(100, 200);
            float desiredWidth = 50; // The desired width for the sprite
            float scale = desiredWidth / HealthSystemSprite.heartsFragments[0].Width;

            if (HealthSystemSprite.heartsList.Count > 0)
            {
                HealthSystemSpriteManager previousHeart = HealthSystemSprite.heartsList[HealthSystemSprite.heartsList.Count - 1];
                float newX = previousHeart.position.X + desiredWidth + 5; // Adjust the 5 to control the spacing
                position = new Vector2(newX, position.Y);
            }

            return position;
        }

        public void SetHeartFragment(int fragments)
        {
            switch (fragments)
            {
                case 0: heartTexture = HealthSystemSprite.heartsFragments[0]; break; //full
                case 1: heartTexture = HealthSystemSprite.heartsFragments[1]; break; //half
                case 2: heartTexture = HealthSystemSprite.heartsFragments[2]; break; //empty
            }
        }
    }
}
