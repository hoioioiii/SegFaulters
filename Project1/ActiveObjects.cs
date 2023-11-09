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
        private List<Door> doors;
        private List<IEnvironment> blocks;
        private List<Rectangle> walls;

        private List<IItem> removeItemsList;
        private List<IEntity> removeEntityList;
        private List<IWeapon> removeWeaponList;

        private List<IItem> addItemsList;
        private List<IEntity> addEntitiesList;
        private List<IWeapon> addWeaponsList;
        private List<Door> addDoorsList;
        private List<IEnvironment> addBlocksList;
        private List<Rectangle> addWallsList;



        private Player link;
        private ITime timeManager;

        private bool DrawState;
        private bool UpdateState;
        public ActiveObjects() {
            items = new List<IItem>();
            entities = new List<IEntity>();
            weapons = new List<IWeapon>();
            doors = new List<Door>();
            blocks = new List<IEnvironment>();
            walls = new List<Rectangle>();

            removeEntityList = new List<IEntity>();
            removeItemsList = new List<IItem>();
            removeWeaponList = new List<IWeapon>();

            addDoorsList = new List<Door>();
            addItemsList = new List<IItem> ();
            addEntitiesList = new List<IEntity>();
            addWeaponsList = new List<IWeapon>();
            addBlocksList = new List<IEnvironment> ();
            addWallsList = new List<Rectangle> ();

            ITime timeManager = new TimeTracker(true);

            DrawState = false;
            UpdateState = true;
        }

        public void addLink(Project1.Player link)
        {
            this.link = link;
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
            addAllWalls();
            addAllBlocks();
            addAllDoors();
            addAllEntities();
            addAllItems();
        }


        public void clearAll()
        {
            items.Clear();
            entities.Clear();
            weapons.Clear();
            doors.Clear();
            blocks.Clear();
        }

        public void ClearAddingLists()
        {
            addBlocksList.Clear();
            addWeaponsList.Clear();
            addWallsList.Clear();
            addEntitiesList.Clear();
            addDoorsList.Clear();
            addItemsList.Clear();

            
            
        }

        public void ClearRemovingLists()
        {
            removeItemsList.Clear();
            removeWeaponList.Clear();
            removeEntityList.Clear();
        }
        

        public Player getLink() { return link; }
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

        public void RemoveDead()
        {
            removeAllItems();
            removeAllWeapons();
            removeAllEntities();
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
    }
}

//public void Update()
//{

//    if (!DrawState)
//    {
//        setAllObjects();
//        ClearAddingLists();
//        UpdateState = true;
//        UpdateItems();
//        UpdateEnemies();
//        UpdateIWeapons();
//    }

//    RemoveDead();
//    ClearRemovingLists();

//    UpdateState = false;

//    //UpdatePlayer();
//    //AllCollisionDetection.DetectCollision(this);
//}





//private void UpdatePlayer()
//{
//    //link.Update();
//}

//private void UpdateIWeapons()
//{
//    for (int i = 0; i < weapons.Count; i++)
//    {
//        weapons[i].Update();
//    }
//}

//private void UpdateEnemies()
//{
//    for (int i = 0; i < entities.Count; i++)
//    {
//        entities[i].Update();
//    }
//}

//private void UpdateItems()
//{
//    for (int i = 0; i < items.Count; i++)
//    {
//        items[i].Update();
//    }
//}


//private void DrawPlayer()
//{

//        //TODO:Fix later
//       // link.Draw(, Game1._spriteBatch);

//}

//private void DrawIWeapons()
//{

//    for (int i = 0; i < weapons.Count; i++)
//    {
//        //this is needed for bomb(the attack)
//        //weapons[i].Attack();
//        weapons[i].Draw();
//    }
//}

//private void DrawEnemies()
//{
//    for (int i = 0; i < entities.Count; i++)
//    {
//        entities[i].Draw(Game1._spriteBatch);
//    }
//}

//private void DrawItems()
//{
//    for (int i = 0; i < items.Count; i++)
//    {
//        if (items[i].drawState)
//        {
//            items[i].Draw(Game1._spriteBatch, new Vector2(100, 100), 1);
//        }
//    }
//}

//public void Draw()
//{

//    if (!UpdateState)
//    {
//        DrawState = true;
//        DrawIWeapons();
//        DrawEnemies();
//        DrawItems();

//    }
//    DrawState = false;
//   // DrawPlayer();
//}

