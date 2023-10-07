using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1
{
    internal interface IWeaponProjectile
    {
        
        public void Attack();

        public void Load();

        public void GetUserPos();

        public void GetUserState();

        public void DetermineWeaponState();

        public void Update();

        public void Physics();

        //public void Draw(Vector2 position, int direction, int userScale);
    }




}

