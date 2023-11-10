using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Health.HealthSystemManager;

namespace Project1.Health
{
    public interface IHealthSystem
    {
        public void SetHealthSystem(HealthSystemManager healthSystem);

        public void LoadHearts();
        public bool IsDead();

        public IndividualHeart CreateHeart(Vector2 position);

        public void DamageHealth(int damageAmount);

        public void HealHealth(int healAmount);
        public void Update();

        public void Paused();

        public void Reset();
        public void Draw(SpriteBatch spriteBatch);

    }
}
