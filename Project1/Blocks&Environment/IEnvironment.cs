using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public interface IEnvironment
    {
        public Rectangle BoundingBox { get; }
        public void Draw(SpriteBatch spriteBatch);
        public DIRECTION direction { get; }
        //Remove later
        public int destinationRoom { get;  }
        void Update();
    }
}
