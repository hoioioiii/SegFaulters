using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Collision;

namespace Project1
{
    public class ActiveObjects : IActiveObjects
    {
        private List<IItem>items;
        private List<IEntity> entities;
        private List<IWeapon> weapons;
        private List<IEnvironment> doors;
        private List<IEnvironment> blocks;
        private List<Rectangle> walls;
        private Player link;
        

        public ActiveObjects() {
            items = new List<IItem>();
            entities = new List<IEntity>();
            weapons = new List<IWeapon>();
            doors = new List<IEnvironment>();
            blocks = new List<IEnvironment>();
            walls = new List<Rectangle>();
        }

        public void addLink(Project1.Player link)
        {
            this.link = link;
        }

        public void addNewEntity(IEntity entity)
        {
            entities.Add(entity);
        }

        public void addNewWall(Rectangle wall)
        {
            walls.Add(wall);
        }
        public void addNewEnvironment(IEnvironment block)
        {
            blocks.Add(block);
        }

        public void addDoors(IEnvironment door)
        {
            doors.Add(door);
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
        public List<IEnvironment> getDoorList()
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

        public void Update()
        {

            UpdateItems();

            UpdateEnemies();

            //UpdateIWeapons();

            //UpdatePlayer();

            

           //AllCollisionDetection.DetectCollision(this);
        }

        private void UpdatePlayer()
        {
            //link.Update();
        }

        private void UpdateIWeapons()
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].Update();
            }
        }

        private void UpdateEnemies()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }
        }

        private void UpdateItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Update();
            }
        }


        private void DrawPlayer()
        {
          
                //TODO:Fix later
               // link.Draw(, Game1._spriteBatch);
            
        }

        private void DrawIWeapons()
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].Draw();
            }
        }

        private void DrawEnemies()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                
            }
        }

        private void DrawItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Draw(Game1._spriteBatch,new Vector2(200,300), 4);
            }
        }

        public void Draw()
        {
           // DrawPlayer();
            //DrawIWeapons();
            DrawEnemies();
            DrawItems();
            
        }
    }
}
