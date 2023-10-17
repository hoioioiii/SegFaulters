using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IDoor
    {
        public Rectangle BoundingBox { get; set; }
        public void Draw(SpriteBatch spriteBatch);
    }
}
