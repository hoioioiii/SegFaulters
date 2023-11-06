using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace Project1.Health
{
    public class HealthSystem //turn it into SpriteHealth
    {

        public static int healthCurrent;

        public static Texture2D fullHeart;
        public static Texture2D halfHeart;
        public static Texture2D emptyHeart;

        public static List<IndividualHeart> heartsList;
        public static List<Texture2D> heartsFragments;

        public HealthSystemManager healthSystem;
        public IndividualHeart heart;

        public HealthSystem()
        {
            //list of all types of hearts
            heartsFragments = new List<Texture2D>();
            LoadHearts();

            //list of current Link's hearts
            heartsList = new List<IndividualHeart>();

            //set up a health system that starts with 3 hearts
            HealthSystemManager healthSystem = new HealthSystemManager(3);
            SetHealthSystem(healthSystem);
        }

        public void SetHealthSystem(HealthSystemManager healthSystem)
        {
            this.healthSystem = healthSystem;
            List<HealthSystemManager.Heart> hearts = healthSystem.GetHealthSystem();

            //INITIAL POSITION TO BE CHANGED BY HUD 
            Vector2 currHeartPosition = new Vector2(100, 200);

            for (int i = 0;  i < hearts.Count; i++)
            {
                HealthSystemManager.Heart heart = hearts[i];
                CreateHeart(currHeartPosition).SetHeartFragment(heart.GetFragmentAmount());
                currHeartPosition += new Vector2(50, 0); //offset the next to the right
            }

        }



        //Load all possible types of hearts
        public void LoadHearts()
        {
            fullHeart = Game1.contentLoader.Load<Texture2D>("fullheart");
            halfHeart = Game1.contentLoader.Load<Texture2D>("halfheart");
            emptyHeart = Game1.contentLoader.Load<Texture2D>("emptyheart");

            heartsFragments.Add(emptyHeart);
            heartsFragments.Add(halfHeart);
            heartsFragments.Add(fullHeart);

        }

        public bool isDead()
        {
            List<HealthSystemManager.Heart> hearts = healthSystem.GetHealthSystem();

            //update each heart texture based off its fragments
            for (int i = 0; i < heartsList.Count; i++)
            {
               // IndividualHeart currentHeart = heartsList[i];

                HealthSystemManager.Heart heart = hearts[i];

                if (heart.GetFragmentAmount() >=1)
                {
                    return false;
                }

            }
            return true;
        }

        public IndividualHeart CreateHeart(Vector2 position)
        {
            Texture2D currentHeart = heartsFragments[0];


/*            // Find the last heart's position in the heartsList
            Vector2 lastHeartPosition = Vector2.Zero;
            if (heartsList.Count > 0)
            {
                lastHeartPosition = heartsList[heartsList.Count - 1].position;
            }

            int screenWidth = 800; // Replace with your target screen width

            // Calculate the position for the new heart
            float heartOffsetX = 50; // Adjust the horizontal offset as needed
            Vector2 newHeartPosition = lastHeartPosition + new Vector2(heartOffsetX, 0);

            // If the new position is beyond the screen bounds, place it below the last heart
            if (newHeartPosition.X + currentHeart.Width * 0.5f > screenWidth)
            {
                newHeartPosition.X = lastHeartPosition.X;
                newHeartPosition.Y += currentHeart.Height; // Adjust the vertical offset as needed
            }
*/

            //Create a type heart (full, empty, half)
            heart = new IndividualHeart(currentHeart, position, this);

            //Add to Link's current hearts
            heartsList.Add(heart);

            return heart;
        }

        public void damageHealth(int damageAmount)
        {
            //update fragment quantity of all the hearts
            healthSystem.DamageHealth(damageAmount);
            Update();
        }

        public void HealHealth(int healAmount)
        {
            //update fragment quantity of all the hearts
            healthSystem.HealHealth(healAmount);


            for (int i = heartsList.Count; i < healthSystem.GetHealthSystem().Count; i++)
            {
                // Create a new heart for each additional heart in the health system
                HealthSystemManager.Heart heart = healthSystem.GetHealthSystem()[i];
                CreateHeart(new Vector2(100 + i * 50, 200)).SetHeartFragment(heart.GetFragmentAmount());
            }


            Update();
        }

        public void Update()
        {
            List<HealthSystemManager.Heart> hearts = healthSystem.GetHealthSystem();

            //update each heart texture based off its fragments
            for (int i = 0; i < heartsList.Count; i++)
            {
                IndividualHeart currentHeart = heartsList[i];

                HealthSystemManager.Heart heart = hearts[i];

                currentHeart.SetHeartFragment(heart.GetFragmentAmount());
            }


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            float desiredWidth = 50; // The desired width for the sprite
            float scale = desiredWidth / heartsList[0].heartTexture.Width;

            foreach (var heart in heartsList)
            {
                spriteBatch.Draw(heart.heartTexture, heart.position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
        }


    }
}