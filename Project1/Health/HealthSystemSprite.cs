using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1;
using Project1.Enemies;
using Project1.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
//using static Project1.ConstantClass;
namespace Project1.Health
{
    public class HealthSystemSprite //turn it into SpriteHealth
    {

        public static int healthCurrent;

        public static Texture2D fullHeart;
        public static Texture2D halfHeart;
        public static Texture2D emptyHeart;

        public static List<IndividualHeart> heartsList;
        public static List<Texture2D> heartsFragments;

        public HealthSystem healthSystem;
        public IndividualHeart heart;

        public HealthSystemSprite()
        {
            //list of all types of hearts
            heartsFragments = new List<Texture2D>();
            LoadHearts();

            //list of current Link's hearts
            heartsList = new List<IndividualHeart>();

            HealthSystem healthSystem = new HealthSystem(3); //3 hearts as starter
            SetHealthSystem(healthSystem);

/*            UpdateDamage(2);
*/        }

        public void SetHealthSystem(HealthSystem healthSystem)
        {
            this.healthSystem = healthSystem;
            List<HealthSystem.Heart> hearts = healthSystem.GetHealthSystem();

            //INITIAL POSITION TO BE CHANGED BY HUD 
            Vector2 currHeartPosition = new Vector2(100, 200);

            for (int i = 0;  i < hearts.Count; i++)
            {
                HealthSystem.Heart heart = hearts[i];
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

        public IndividualHeart CreateHeart(Vector2 position)
        {
            Texture2D currentHeart = heartsFragments[0];

            //Create a type heart (full, empty, half)
            heart = new IndividualHeart(currentHeart, position, this);

            //Add to Link's current hearts
            heartsList.Add(heart);

            return heart;
        }

        public void DamageHealthUpdate(int damageAmount)
        {
            List<HealthSystem.Heart> hearts = healthSystem.GetHealthSystem();

            healthSystem.DamageHealth(damageAmount);

            for (int i = 0; i < heartsList.Count; i++)
            {
                IndividualHeart currentHeart = heartsList[i];

                HealthSystem.Heart heart = hearts[i];

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