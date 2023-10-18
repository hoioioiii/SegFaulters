using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class ActiveObjects : IActiveObjects
    {
        private List<IItem>items;
        private List<IEntity> entities;
        private List<IWeapon> weapons;

        public ActiveObjects() {

            items = new List<IItem>();
            entities = new List<IEntity>();
            weapons = new List<IWeapon>();
        }

        public void addNewEntity(IEntity entity)
        {
            entities.Add(entity);
        }

        public void addNewItem(IItem item)
        {
            items.Add(item);
        }

        public void addNewWeapon(IWeapon weapon)
        {
           weapons.Add(weapon);
        }

        public void clearAll()
        {
            items.Clear();
            entities.Clear();
            weapons.Clear();
        }

        public List<IEntity> getEntityList()
        {
            return entities;
        }

        public List<IItem> getItemList()
        {
            return items;
        }

        public List<IWeapon> getWeaponList()
        {
            return weapons;
        }

        public void removeEntity(IEntity entity)
        {
            entities.Remove(entity);
        }

        public void removeItem(IItem item)
        {
            items.Remove(item);
        }

        public void removeWeapon(IWeapon weapon)
        {
            weapons.Remove(weapon);
        }
    }
}
