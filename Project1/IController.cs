using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    internal interface IController
    {
        public void GetInputType();

        public void ActionBasedOnInput(Keys Cleaned_Key);

        public void Update();

    }
}
