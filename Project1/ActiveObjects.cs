using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project1.Collision;

namespace Project1
{
    public class ActiveObjects : IActiveObjects
    {
        private List<IItem>items;
        private List<IEntity> entities;
        private List<IWeapon> weapons;
        private List<IWeapon> playerWeapons;
        private List<IWeapon> detectionWeapons;
        private List<IEntity> detectionEntities;


        private List<Door> doors;
        private List<IEnvironment> blocks;
        private List<Rectangle> walls;

        private List<IItem> removeItemsList;
        private List<IEntity> removeEntityList;
        private List<IWeapon> removeWeaponList;
        private List<IWeapon> removePlayerWeaponList;
        private List<IWeapon> removeDetectionWeaponsList;
        private List<IEntity> removeDetectionEntitiesList;


        private List<IItem> addItemsList;
        private List<IEntity> addEntitiesList;
        private List<IWeapon> addWeaponsList;
        private List<Door> addDoorsList;
        private List<IEnvironment> addBlocksList;
        private List<Rectangle> addWallsList;
        private List<IWeapon> addPlayerWeaponsList;
        private List<IWeapon> addDetectionWeaponsList;
        private List<IEntity> addDetectionEntityList;

        

        public ActiveObjects() {
            items = new List<IItem>();
            entities = new List<IEntity>();
            weapons = new List<IWeapon>();
            doors = new List<Door>();
            blocks = new List<IEnvironment>();
            walls = new List<Rectangle>();
            playerWeapons = new List<IWeapon>();
            detectionWeapons = new List<IWeapon>();
            detectionEntities = new List<IEntity>();

            removeEntityList = new List<IEntity>();
            removeItemsList = new List<IItem>();
            removeWeaponList = new List<IWeapon>();
            removePlayerWeaponList = new List<IWeapon>();
            removeDetectionWeaponsList = new List<IWeapon>();
            removeDetectionEntitiesList = new List<IEntity>();

            addDoorsList = new List<Door>();
            addItemsList = new List<IItem> ();
            addEntitiesList = new List<IEntity>();
            addWeaponsList = new List<IWeapon>();
            addBlocksList = new List<IEnvironment> ();
            addWallsList = new List<Rectangle> ();
            addPlayerWeaponsList = new List<IWeapon> ();
            addDetectionWeaponsList = new List<IWeapon> ();
            addDetectionEntityList = new List<IEntity> ();

        }

        public void addNewEntity(IEntity entity)
        {
            addEntitiesList.Add(entity);
        }

        public void addNewWall(Rectangle wall)
        {
            addWallsList.Add(wall);
        }
        public void addNewEnvironment(IEnvironment block)
        {
            addBlocksList.Add(block);
        }

        public void addDoors(Door door)
        {
            addDoorsList.Add(door);
        }

        public void addNewItem(IItem item)
        {
            addItemsList.Add(item);
        }

        public void addNewWeapon(IWeapon weapon)
        {
           addWeaponsList.Add(weapon);
        }

        public void addNewPlayerWeapon(IWeapon weapon)
        {
            addPlayerWeaponsList.Add(weapon);
        }

        public void addNewDetectionWeapon(IWeapon weapon)
        {
            addDetectionWeaponsList.Add(weapon);
        }

        public void addNewDetectionEntity(IEntity entity)
        {
           addDetectionEntityList.Add(entity);
        }


        private void addAllItems()
        {
            foreach(IItem item in addItemsList)
            {
                items.Add(item);
            }
        }

        private void addAllEntities()
        {
            foreach (IEntity entity in addEntitiesList)
            {
                entities.Add(entity);
            }
        }

        private void addAllWeapons()
        {
            foreach (IWeapon weapon in addWeaponsList)
            {
                weapons.Add(weapon);
            }
        }

        private void addAllPlayerWeapons()
        {
            foreach (IWeapon weapon in addPlayerWeaponsList)
            {
                playerWeapons.Add(weapon);
            }
        }

        private void addAllDetectionWeapons()
        {
            foreach (IWeapon weapon in addDetectionWeaponsList)
            {
                detectionWeapons.Add(weapon);
            }
        }
        private void addAllDetectionEntities()
        {
            foreach (IEntity entity in addDetectionEntityList)
            {
                detectionEntities.Add(entity);
            }
        }

        private void addAllWalls()
        {
            foreach (Rectangle wall in addWallsList)
            {
                walls.Add(wall);
            }
        }

        private void addAllDoors()
        {
            foreach (Door door in addDoorsList)
            {
                doors.Add(door);
            }
        }

        private void addAllBlocks()
        {
            foreach (IEnvironment environment in addBlocksList)
            {
                blocks.Add(environment);
            }
        }

        public void setAllObjects()
        {
            addAllWeapons();
            addAllPlayerWeapons();
            addAllWalls();
            addAllBlocks();
            addAllDoors();
            addAllEntities();
            addAllItems();
            addAllDetectionWeapons();
            addAllDetectionEntities();
        }


        public void clearAll()
        {
            items.Clear();
            entities.Clear();
            weapons.Clear();
            playerWeapons.Clear();
            doors.Clear();
            blocks.Clear();
            detectionWeapons.Clear();
            detectionEntities.Clear();
        }

        public void ClearAddingLists()
        {
            addBlocksList.Clear();
            addWeaponsList.Clear();
            addPlayerWeaponsList.Clear();
            addWallsList.Clear();
            addEntitiesList.Clear();
            addDoorsList.Clear();
            addItemsList.Clear();
            addDetectionWeaponsList.Clear();
            addDetectionEntityList.Clear();
            
            
        }

        public void ClearRemovingLists()
        {
            removeItemsList.Clear();
            removeWeaponList.Clear();
            removeEntityList.Clear();
            removePlayerWeaponList.Clear();
            removeDetectionWeaponsList.Clear();
            removeDetectionEntitiesList.Clear();
        }
        

      
        public List<IEntity> getEntityList()
        {
            return entities;
        }

        public List<IItem> getItemList()
        {
            return items;
        }

        public List<IEnvironment> getEnvironmentList()
        {
            return blocks;
        }
        public List<Door> getDoorList()
        {
            return doors;
        }

        public List<Rectangle> getBoundarys()
        {
            return walls;
        }

        public List<IWeapon> getWeaponList()
        {
            return weapons;
        }
        public List<IWeapon> getPlayerWeaponList()
        {
            return playerWeapons;
        }

        public List<IWeapon> getDetectionWeaponsList()
        {
            return detectionWeapons;
        }

        public List<IEntity> getDetectionEntityList()
        {
            return detectionEntities;
        }

       


        public void RemoveDead()
        {
            removeAllItems();
            removeAllWeapons();
            removeAllEntities();
            removeAllPlayerWeapons();
            removeAllDetectionFieldWeapon();
            removeAllDetectionFieldEntities();
        }

        private void removeAllDetectionFieldWeapon()
        {
            foreach (IWeapon weapon in removeDetectionWeaponsList)
            {
                detectionWeapons.Remove(weapon);
            }
        }
        private void removeAllDetectionFieldEntities()
        {
            foreach (IEntity entity in removeDetectionEntitiesList)
            {
                detectionEntities.Remove(entity);
            }
        }

        private void removeAllEntities()
        {
            //Removes all the entities that need to be removed.
            foreach (IEntity entity in removeEntityList)
            {
                entities.Remove(entity);
            }
        }

        private void removeAllItems( )
        {
            foreach (IItem item in removeItemsList)
            {
                items.Remove(item);
            }
           
        }
        private void removeAllWeapons()
        {
            foreach (IWeapon weapon in removeWeaponList)
            {
                weapons.Remove(weapon);
            }
        }
        private void removeAllPlayerWeapons()
        {
            foreach (IWeapon weapon in removePlayerWeaponList)
            {
                playerWeapons.Remove(weapon);
            }
        }




        public void removeItem(IItem item)
        {
            removeItemsList.Add(item);
        }

        public void removeEntity(IEntity entity)
        {
            removeEntityList.Add(entity);
        }

        public void removeWeapon(IWeapon weapon)
        {
           removeWeaponList.Add(weapon);
        }

        public void removePlayerWeapon(IWeapon weapon)
        {
            removePlayerWeaponList.Add(weapon);
        }

        public void removeDetectionWeapon(IWeapon weapon)
        {
            removeDetectionWeaponsList.Add(weapon);
        }

       

       
        public void removeDetectionEntity(IEntity entity)
        {
            removeDetectionEntitiesList.Add(entity);
        }
    }
}


