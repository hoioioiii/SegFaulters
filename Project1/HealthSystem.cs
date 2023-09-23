using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class HealthSystem
{
    public float healthCurrent;
    public float healthMax;

    public void HealthSystemInstantiate()
	{
        this.healthCurrent = healthMax;
        healthCurrent = healthMax;

	}

    public float HealthCurrent
    {
        return healthCurrent;
    }


    public void HealthDamage()
    {

    }

    public void HealthHeal()
    {

    }

    public void Update(GameTime gameTime)
    {
        // Add any update logic here, if needed
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        // Add drawing logic here, if needed
    }

}
