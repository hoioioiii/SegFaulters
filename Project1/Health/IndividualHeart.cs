using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Health
{
    //sets a heart to be a specific type
    public class IndividualHeart
    {
        public Texture2D heartTexture { get; set; }
        public Vector2 position;
        public HealthSystem healthSystem;
        public IndividualHeart(Texture2D heart, Vector2 position, HealthSystem healthSystem)
        {
            this.heartTexture = heart;
            this.healthSystem = healthSystem;
            //this.position = getPosition()
            this.position = position;
        }

/*        public Vector2 getPosition()
        {
            Vector2 position = new Vector2(100, 200);
            float desiredWidth = 50; // The desired width for the sprite
            float scale = desiredWidth / HealthSystem.heartsFragments[0].Width;

            if (HealthSystem.heartsList.Count > 0)
            {
                IndividualHeart previousHeart = HealthSystem.heartsList[HealthSystem.heartsList.Count - 1];
                float newX = previousHeart.position.X + desiredWidth + 5; // Adjust the 5 to control the spacing
                position = new Vector2(newX, position.Y);
            }

            return position;
        }
*/
        public void SetHeartFragment(int fragments)
        {
            //set heart to be full, half or empty
            switch (fragments)
            {
                case 0: heartTexture = HealthSystem.heartsFragments[0]; break; //empty
                case 1: heartTexture = HealthSystem.heartsFragments[1]; break; //half
                case 2: heartTexture = HealthSystem.heartsFragments[2]; break; //full
            }
        }
    }
}
