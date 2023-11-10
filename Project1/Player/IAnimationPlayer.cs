using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IAnimationPlayer
    {

        public Texture2D sprite_frame { get; }
        public List<Texture2D[]> frame_list { set; }
        public void Animate();
        public void PopulateFrames();
        public int getCurrentFrame();

        public void setTotalFrame(int frame);
        public void setStartFrame(int frame);




    }
}
