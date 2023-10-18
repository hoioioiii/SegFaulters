using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal interface IActiveObjects
    {

        public List<IItem> getItemList();

        //change to add environment blocks
        //public IItem getEnvironmentList();

        public List<IEntity> getEntityList();

        public List<IWeapon> getWeaponList();

        public void addNewItem(IItem item);

        public void addNewEntity(IEntity entity);

        public void addNewWeapon(IWeapon weapon);

        public void removeItem(IItem item);

        public void removeEntity(IEntity entity);

        public void removeWeapon(IWeapon weapon);

        public void clearAll();

    }
}
