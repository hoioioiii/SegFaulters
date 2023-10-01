using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IWeaponMelee
    {

        public void Attack();

        public void Load();

        public void GetUserPos();

        public void GetUserState();

        public void DetermineWeaponState();

        public void Update();


        public void Draw();
    }
}