using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    public interface IWeapon
    {
        public Rectangle BoundingBox { get; set; }
        public bool detected { set; }

        public void Attack();






        public Rectangle getDetectionFieldRectangle();
        public void Update();

        public void Attack(int x, int y, Direction direct);
        public void Draw();
        public void storeTarget(IEntity entity);
        public bool finished();
    }
}