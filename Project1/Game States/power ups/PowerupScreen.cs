using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class PowerupScreen
    {
        IPowerUpScreen powerupSelection;
        public PowerupScreen(GraphicsDevice graphics, ContentManager content)
        {
            powerupSelection = new PowerupSelection(graphics, content);

        }
        public void Draw(SpriteBatch spritebatch)
        {
            powerupSelection.Draw(spritebatch);
        }
        public void Update()
        {

            powerupSelection.Update();
        }

    }
}
