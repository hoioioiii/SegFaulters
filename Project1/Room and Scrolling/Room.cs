using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using static Project1.Constants;


namespace Project1
{

    //the actual room; uses environment, item, and enemy loader to load in the respective information 
    internal class Room
    {
        public DIRECTION direction { get; private set; }

        private (string, ((int, int), (string, int)[]))[] enemyArray; //(string enemyName, ((int posX, int posY), (string itemName, int quantity)[]))
        private (((string, bool), (int, bool))[], (string, (int, int))[]) environmentInfo; //(doorArray, blockArray)
        private (string, (int, int))[] itemArray;//(string itemName,(int posX, posY))

        public Room((string, ((int, int), (string, int)[]))[] enemyArray, (((string, bool), (int, bool))[], (string, (int, int))[]) environmentInfo, (string, (int, int))[] itemArray)
        {
            this.enemyArray = enemyArray;
            this.environmentInfo = environmentInfo;
            this.itemArray = itemArray;
        }

        public void Load()
        {
            Game1.GameObjManager.clearAll();
            LoadEnvironment();
            LoadEntity();
            LoadItems();
        }


        private void LoadEnvironment()
        {
            (string, (int, int))[] blocks = environmentInfo.Item2;
            
            EnvironmentLoader.LoadBlocks(blocks);

            ((string, bool), (int, bool))[] doors = environmentInfo.Item1; //((direction, isTunnel),(destinationRoom, isLocked))
            
            EnvironmentLoader.LoadDoors(doors);
        }

        private void LoadEntity()
        {
            foreach ((string, ((int, int), (string, int)[])) enemyInfo in enemyArray)
            {
                String name = enemyInfo.Item1;
                (int, int) position = enemyInfo.Item2.Item1;
                (string, int)[] items = enemyInfo.Item2.Item2;

                
                if(!name.Equals(DEAD))
                    EntityLoader.LoadEntities(Game1.GameObjManager, enemyInfo.Item1, position, items);
            }
        }

        private void LoadItems()
        {
            foreach ((string, (int, int)) item in itemArray)
            {
                String name = item.Item1;
                (int, int) position = item.Item2;

                if (position != INVALID_ITEM)
                {
                    position = PositionGrid.getPosBasedOnGrid(position.Item1, position.Item2);
                    ItemLoader.LoadAndInitializeItems(name, position, Game1.GameObjManager);
                }
            }
        }

   
        public void UnlockDoor(DIRECTION doorToUnlockDirection)
        {
            ((string, bool), (int, bool))[] doors = environmentInfo.Item1; //(direction,(destinationRoom, isLocked))
            for (int i = 0; i < doors.Length; i++)
            {
                ((string, bool), (int, bool)) door = doors[i];

                DIRECTION direction = EnvironmentLoader.DirectionToEnum(door.Item1.Item1);
                int destinationRoom = door.Item2.Item1;

                //if the door that is being unlocked is found,
                if (doorToUnlockDirection == direction)
                {
                    door = (door.Item1, (destinationRoom, false));
                    doors[i] = door;
                    environmentInfo.Item1 = doors;


                    return;
                }
            }
        }

        public void RemoveItem(IItem item)
        {
            string itemName = item.GetTypeIndex().ToString();
            for (int i = 0; i < itemArray.Length; i++)
            {
                (string, (int, int)) n = itemArray[i];
                string name = n.Item1;
                if (name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase))
                {
                    n.Item2 = INVALID_ITEM;
                    itemArray[i] = n;
                }

            }
        }

        public void RemoveEnemy((int,int) positionToKill) //removes enemy using the inital spawning position as the identifier
        {
            for(int i = 0; i < enemyArray.Length; i++)
            {
                (string, ((int, int), (string, int)[])) enemy = enemyArray[i];

                (int, int) enemyPos = enemy.Item2.Item1;
                if(enemyPos == positionToKill)
                {
                    enemy.Item1 = DEAD;
                    enemyArray[i] = enemy;
                }
            }
        }
    }
}
