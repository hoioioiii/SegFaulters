using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1
{
    public interface IActiveObjects
    {

        public List<IItem> getItemList();

        public Player getLink();
        //change to add environment blocks
        //public IItem getEnvironmentList();

        public List<IEntity> getEntityList();

        public List<IWeapon> getWeaponList();

        public void addNewItem(IItem item);

        public void addNewEntity(IEntity entity);

        public void addNewWeapon(IWeapon weapon);
        public void addNewWall(Rectangle wall);
        public void addNewEnvironment(IEnvironment block);
        public void addDoors(IDoor door);

        public void removeItem(IItem item);

        public void removeEntity(IEntity entity);

        public void removeWeapon(IWeapon weapon);

        public List<IEnvironment> getEnvironmentList();
        public List<IDoor> getDoorList();
        public List<Rectangle> getBoundarys();
        public void clearAll();



    }
}
