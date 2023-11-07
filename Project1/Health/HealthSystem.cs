using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Principal;
using static Project1.Constants;
using static Project1.Health.HealthSystemManager;

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
            Vector2 boundingBoxUpperLeft = new Vector2(HUD_SECTION_WIDTH * 2, HUD_HEIGHT / 3);
            Vector2 boundingBoxLowerRight = new Vector2(SCREEN_WIDTH, HUD_HEIGHT);
            float rowColSize = 30f;

            this.healthSystem = healthSystem;
            List<HealthSystemManager.Heart> hearts = healthSystem.GetHealthSystem();

            Vector2 currentHeartPosition = boundingBoxUpperLeft;

            int colMax = (int)((boundingBoxLowerRight.X - boundingBoxUpperLeft.X) / rowColSize);

            for (int i = 0; i < hearts.Count; i++)
            {
                HealthSystemManager.Heart heart = hearts[i];

                CreateHeart(currentHeartPosition).SetHeartFragment(heart.GetFragmentAmount());

                currentHeartPosition.X += rowColSize; // Offset the next heart to the right

                if (currentHeartPosition.X >= boundingBoxLowerRight.X)
                {
                    currentHeartPosition.X = boundingBoxUpperLeft.X;
                    currentHeartPosition.Y += rowColSize; // Move to the next row
                }
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

        public bool IsDead()
        {
            List<HealthSystemManager.Heart> hearts = healthSystem.GetHealthSystem();
            return (hearts[0].GetFragmentAmount() == 0);

/*            for (int i = 0; i < heartsList.Count; i++)
            {
                // IndividualHeart currentHeart = heartsList[i];

                HealthSystemManager.Heart heart = hearts[i];

                if (heart.GetFragmentAmount() >= 1)
                {
                    return false;
                }

            }

            return true;*/

        }

        public IndividualHeart CreateHeart(Vector2 position)
        {
            Texture2D currentHeart = heartsFragments[0];

            //Create a type heart (full, empty, half)
            heart = new IndividualHeart(currentHeart, position, this);

            //Add to Link's current hearts
            heartsList.Add(heart);

            return heart;
        }

        public void DamageHealth(int damageAmount)
        {
            //update fragment quantity of all the hearts
            healthSystem.DamageHealth(damageAmount);
            Update();
        }

        public void HealHealth(int healAmount)
        {
            // Update fragment quantity of all the hearts
            healthSystem.HealHealth(healAmount);

            Vector2 boundingBoxUpperLeft = new Vector2(HUD_SECTION_WIDTH * 2, HUD_HEIGHT / 3);
            Vector2 boundingBoxLowerRight = new Vector2(SCREEN_WIDTH, HUD_HEIGHT);
            float rowColSize = 30f;

            for (int i = heartsList.Count; i < healthSystem.GetHealthSystem().Count; i++)
            {
                // Create a new heart for each additional heart in the health system
                HealthSystemManager.Heart heart = healthSystem.GetHealthSystem()[i];

                // Calculate the position based on the HUD bounding box
                Vector2 newPosition = new Vector2(
                    boundingBoxUpperLeft.X + (i % (int)((boundingBoxLowerRight.X - boundingBoxUpperLeft.X) / rowColSize)) * rowColSize,
                    boundingBoxUpperLeft.Y + (i / (int)((boundingBoxLowerRight.X - boundingBoxUpperLeft.X) / rowColSize)) * rowColSize
                );

                CreateHeart(newPosition).SetHeartFragment(heart.GetFragmentAmount());
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
            float desiredWidth = 30; // The desired width for the sprite
            float scale = desiredWidth / heartsList[0].heartTexture.Width;

            foreach (var heart in heartsList)
            {
                spriteBatch.Draw(heart.heartTexture, heart.position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
        }


    }
}