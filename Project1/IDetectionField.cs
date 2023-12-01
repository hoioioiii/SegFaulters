using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project1.SmartAI;

namespace Project1
{
    public interface IDetectionField
    {

        public RangeDetectionWeapons rangeDetectionWeapons { get; }
        public RangeDetectionWeapons rangeDetectionPlayer { get; }
        public Rectangle getDetectionFieldRectangle();
    }
}
