using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal interface IAnimation
    {
        public Texture2D sprite_frame { get;}
        public void Animate();

        public int getCurrentFrame();

        public void setTotalFrame(int frame);
        public void setStartFrame(int frame);

    }
}
