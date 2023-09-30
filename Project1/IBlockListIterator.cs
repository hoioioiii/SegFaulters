using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IBlockListIterator
    {
            public void CreateList(Texture2D[] temp);
            public void moveBack();
            public void moveForward();
            public void Load();
    }
}
