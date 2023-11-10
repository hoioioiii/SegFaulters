using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public class PlayerSprite : IPlayerSprite
    {
        private int SCALE = 3;
        private IAnimationPlayer animate;
        public PlayerSprite(Texture2D[] stillFrames, List<Texture2D[]> movementFrames, Texture2D[] attackFrames, IAnimationPlayer animate) {

            this.animate = animate;
            


        }




        public void Draw(SpriteBatch spriteBatch, string _type, int direction, Vector2 location)
        {
        }

        public void Draw()
        {
            
        }

        public Rectangle getRectangle()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
