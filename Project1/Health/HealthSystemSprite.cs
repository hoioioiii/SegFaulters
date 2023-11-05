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

public class HealthSystemSprite //turn it into SpriteHealth
{
    
    public static int healthCurrent;

    public static Texture2D fullHeart;

    public static Texture2D halfHeart;
    public static Texture2D emptyHeart;

    public static List<HealthSystemSpriteManager> heartsList;
    public static List<Texture2D> heartsFragments;

    public HealthSystem healthSystem;
    public HealthSystemSpriteManager heart;

    public HealthSystemSprite()
    {


        heartsList = new List<HealthSystemSpriteManager>();
        heartsFragments = new List<Texture2D>();

        LoadHearts();

        HealthSystem healthSystem = new HealthSystem(3);
        setHealthSystem(healthSystem);
    }

    public void setHealthSystem(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        createHeart(new Vector2(100, 200)).SetHeartFragment(0);
        createHeart(new Vector2(100, 200)).SetHeartFragment(0);
        createHeart(new Vector2(100, 200)).SetHeartFragment(0);
    }

    public void LoadHearts()
    {
        fullHeart = Game1.contentLoader.Load<Texture2D>("fullheart");
        halfHeart = Game1.contentLoader.Load<Texture2D>("halfheart");
        emptyHeart = Game1.contentLoader.Load<Texture2D>("emptyheart");

        heartsFragments.Add(fullHeart);
        heartsFragments.Add(halfHeart);
        heartsFragments.Add(emptyHeart);
    }

    public HealthSystemSpriteManager createHeart(Vector2 position)
    {
        Texture2D currentHeart = heartsFragments[0];

        heart = new HealthSystemSpriteManager(currentHeart, position, this);

        heartsList.Add(heart);
        return heart;
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
