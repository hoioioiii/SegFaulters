using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal interface IHealth
    {
        public Rectangle BoundingBox { get; set; }
        public int Health { get; set; }

        public void LoadHealthBar();

        public float GetCurrentHealth();

        public void HealthDamage(float attack);

        //Can be changed for overheal properties
        public void HealthHeal(float restore);

        public void HealthLifeStatus();

        public void Update();

        public void Draw();
    }
}
