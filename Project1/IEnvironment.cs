using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IEnvironment
    {

        public void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
