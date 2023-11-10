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

        public void SetHeartFragment(int fragments)
        {
            //set heart to be full, half or empty
            switch (fragments)
            {
                case 0: heartTexture = this.healthSystem.heartsFragments[0]; break; //empty
                case 2: heartTexture = this.healthSystem.heartsFragments[1]; break; //half
                case 4: heartTexture = this.healthSystem.heartsFragments[2]; break; //full
            }
        }
    }
}
