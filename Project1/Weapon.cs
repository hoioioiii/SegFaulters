using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Weapon : IWeapon
    {
        protected int maxAmmo;
        protected float reloadTime;
        public bool shouldReload;
        public int currentAmmo;
        public Texture2D weaponSprite;
        protected Weapon()
        {
            shouldReload = false;
        }
        public virtual void Update()
        {
            this.Update();
        
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            
        }
        public void WeaponFire(Texture2D player)
        {
            if (currentAmmo <= 0)
            {
                WeaponReload();
            }


        }

        public void WeaponReload()
        {
            // Do not reload if full ammo or new acquired weapon
            if (currentAmmo == maxAmmo || shouldReload)
            {
                return;
            } 
            else
            {
                shouldReload = true;
                currentAmmo = maxAmmo;
            }
        }
    }
}
