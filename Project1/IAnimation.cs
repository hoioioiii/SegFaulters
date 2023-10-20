using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal interface IAnimation
    {
        public void Animate();

        public int getCurrentFrame();

        public void setTotalFrame(int frame);
        public void setStartFrame(int frame);

    }
}
