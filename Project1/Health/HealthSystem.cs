using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Project1.ConstantClass;

public class HealthSystem : IHealth
{
    public static float HealthCurrent;
    //private const float maxHealth = ConstantClass.maxHealth;


    Texture2D HealthBarSprite;
    Texture2D BarCoverSprite;
    Vector2 HealthBarPosition;
    Vector2 HealthBarCoverPosition;

    Rectangle BarRectangle;
    Rectangle CoverRectangle;


    public HealthSystem()
    {
        LoadHealthBar();
    }
    
    public void LoadHealthBar()
	{
        
        HealthBarSprite = Game1.contentLoader.Load<Texture2D>("redbaradjusted");
        BarCoverSprite = Game1.contentLoader.Load<Texture2D>("emptyhealthbar");

        HealthBarPosition = new Vector2(59, 38); // NEEDS TO BE CHANGED BASED ON GRAPHICS DEVICE WINDOW
        HealthBarCoverPosition = new Vector2(40, 30); // NEEDS TO BE CHANGED BASED ON GRAPHICS DEVICE WINDOW
        
        BarRectangle= new Rectangle(0, 0, HealthBarSprite.Width, HealthBarSprite.Height);
        CoverRectangle = new Rectangle(0, 0, BarCoverSprite.Width, BarCoverSprite.Height);

        HealthCurrent = BarRectangle.Width;
    }

    public float GetCurrentHealth()
    {
        return HealthCurrent;
    }

    public void HealthDamage(float attack)
    {
        if (HealthCurrent-attack > 0) {
            HealthCurrent -= attack;
        }
    }

    //Can be changed for overheal properties
    public void HealthHeal(float restore)
    {
        if (HealthCurrent + restore <= 100)
        {
            HealthCurrent += restore;
        }
            
    }

    public void HealthLifeStatus()
    {
        if (HealthCurrent <= 0)
        {
            //call state machine to change to death state
        }
    }

    // NEEDS TO BE UPDATED BASED ON HEALTH CURRENT
    //NEEDS MATH MODIFICATION
    public void Update()
    {

        BarRectangle.Width = (int)HealthCurrent;
    }

    public void Draw()
    {

        Game1._spriteBatch.Draw(HealthBarSprite, HealthBarPosition, BarRectangle, Color.White);
        Game1._spriteBatch.Draw(BarCoverSprite, HealthBarCoverPosition, CoverRectangle, Color.White);

    }

}
