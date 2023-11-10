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
    public class HealthSystem : IHealthSystem
    {
        public static Texture2D fullHeart;
        public static Texture2D halfHeart;
        public static Texture2D emptyHeart;

        public List<IndividualHeart> heartsList;
        public List<Texture2D> heartsFragments;

        public HealthSystemManager healthSystem;
        public IndividualHeart heart;

        private float yCoordState = 0;

        public HealthSystem(int amountHearts)
        {
            //list of all types of hearts
            heartsFragments = new List<Texture2D>();
            LoadHearts();

            //list of current Link's hearts
            heartsList = new List<IndividualHeart>();

            //set up a health system that starts with (amountHearts) hearts
            HealthSystemManager healthSystem = new HealthSystemManager(amountHearts);
            SetHealthSystem(healthSystem);
        }

        public void SetHealthSystem(HealthSystemManager healthSystem)
        {
            //HUD bounding box
            Vector2 boundingBoxUpperLeft = new Vector2(HEALTH_HUD_WIDTH, HEALTH_HUD_HEIGHT);
            Vector2 boundingBoxLowerRight = new Vector2(SCREEN_WIDTH, HUD_HEIGHT);
            float rowColSize = HEALTH_ROW;
            Vector2 currentHeartPosition = boundingBoxUpperLeft; // initial pos based off HUD
            int colMax = (int)((boundingBoxLowerRight.X - boundingBoxUpperLeft.X) / rowColSize);

            //list of hearts with amount of fragments each
            this.healthSystem = healthSystem;
            List<HealthSystemManager.Heart> hearts = healthSystem.GetHealthSystem();

            for (int i = 0; i < hearts.Count; i++)
            {
                HealthSystemManager.Heart heart = hearts[i];

                //add heart with its respective fragments
                CreateHeart(currentHeartPosition).SetHeartFragment(heart.GetFragmentAmount());
                currentHeartPosition.X += rowColSize; // Offset the next heart to the right

                //adjust heart to be inside HUD bounding box
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
            return (hearts[0].GetFragmentAmount() == 0); //if first heart empty, link dead
        }

        public IndividualHeart CreateHeart(Vector2 position)
        {
            Texture2D currentHeart = heartsFragments[0];

            //Create a type heart (full, empty, half)
            heart = new IndividualHeart(currentHeart, position, this);

            //Add to Link current hearts
            heartsList.Add(heart);

            return heart;
        }

        public void DamageHealth(int damageAmount)
        {
            healthSystem.DamageHealth(damageAmount);
            Update(); //update fragment quantity of all the hearts
        }

        public void HealHealth(int healAmount)
        {
            // Update fragment quantity of all the hearts
            healthSystem.HealHealth(healAmount);

            Vector2 boundingBoxUpperLeft = new Vector2(HEALTH_HUD_WIDTH, HEALTH_HUD_HEIGHT);
            Vector2 boundingBoxLowerRight = new Vector2(SCREEN_WIDTH, HUD_HEIGHT);
            float rowColSize = HEALTH_ROW;

            for (int i = heartsList.Count; i < healthSystem.GetHealthSystem().Count; i++)
            {
                HealthSystemManager.Heart heart = healthSystem.GetHealthSystem()[i];

                // Calculate the position based on the HUD bounding box
                Vector2 newPosition = new Vector2(
                    boundingBoxUpperLeft.X + (i % (int)((boundingBoxLowerRight.X - boundingBoxUpperLeft.X) / rowColSize)) * rowColSize,
                    boundingBoxUpperLeft.Y + (i / (int)((boundingBoxLowerRight.X - boundingBoxUpperLeft.X) / rowColSize)) * rowColSize
                );

                // Add additional hearts
                CreateHeart(newPosition).SetHeartFragment(heart.GetFragmentAmount());
            }

            Update();//update fragment quantity of all the hearts
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

        //Pushed down hearts when paused state
        public void Paused()
        {
            yCoordState = ((SCREEN_HEIGHT / 3) * 2);
        }

        //Pushed up hearts when reset state
        public void Reset()
        {
            yCoordState = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            float desiredWidth = HEALTH_ROW; // The desired width for the sprite
            float scale = desiredWidth / heartsList[0].heartTexture.Width;

            foreach (var heart in heartsList)
            {
                Vector2 heartPosition = new Vector2(heart.position.X, heart.position.Y + yCoordState);
                spriteBatch.Draw(heart.heartTexture, heartPosition, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
        }


    }
}