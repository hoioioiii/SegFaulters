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
            //print();
        }


        private void LoadEnvironment()
        {
            (string, (int, int))[] blocks = environmentInfo.Item2;
            /*(int, int)[] blocksToLoad = new (int, int)[blocks.Length];
            for (int i = 0; i < blocks.Length; i++)
            {
                blocksToLoad[i] = blocks[i].Item2;
            }*/
            EnvironmentLoader.LoadBlocks(blocks);

            ((string, bool), (int, bool))[] doors = environmentInfo.Item1; //((direction, isTunnel),(destinationRoom, isLocked))
            //TODO: code door loading in, most of the code will be in environment loader
            EnvironmentLoader.LoadDoors(doors);
        }

        private void LoadEntity()
        {
            foreach ((string, ((int, int), (string, int)[])) enemyInfo in enemyArray)
            {
                String name = enemyInfo.Item1;
                (int, int) position = enemyInfo.Item2.Item1;
                (string, int)[] items = enemyInfo.Item2.Item2;

                if(!name.Equals("DEAD"))
                    EntityLoader.LoadEntities(Game1.GameObjManager, enemyInfo.Item1, position, items);
            }
        }

        private void LoadItems()
        {
            //(string, (int, int))[] itemArray
            foreach ((string, (int, int)) item in itemArray)
            {
                String name = item.Item1;
                (int, int) position = item.Item2;

                if (position != (-1, -1))
                { //-1 -1 is the code for invalid item
                    position = PositionGrid.getPosBasedOnGrid(position.Item1, position.Item2);
                    ItemLoader.LoadAndInitializeItems(name, position, Game1.GameObjManager);
                }
                else
                {

                }
            }
        }

        //find the door that matches up with the door that wants to be changed, and unlock it within the room
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
            string itemName = item.itemInventoryIndex.ToString();
            for (int i = 0; i < itemArray.Length; i++)
            {
                (string, (int, int)) n = itemArray[i];
                string name = n.Item1;
                if (name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase))
                {
                    n.Item2 = (-1, -1);
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
                    enemy.Item1 = "DEAD";
                    enemyArray[i] = enemy;
                }
            }
        }
        public void print()
        {
            PrintEnemies();
            PrintEnvironment();
            PrintItems();
        }
        private void PrintEnemies()
        {
            for (int i = 0; i < enemyArray.Length; i++)
            {
                System.Diagnostics.Debug.Write("EnemyName: " + enemyArray[i].Item1 + ", Location: " + enemyArray[i].Item2.Item1 + ", Items: ");
                for (int j = 0; j < enemyArray[i].Item2.Item2.Length; j++)
                {
                    System.Diagnostics.Debug.Write(enemyArray[i].Item2.Item2[j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        private void PrintEnvironment()
        {
            int doorCount = environmentInfo.Item1.Length;
            System.Diagnostics.Debug.WriteLine("Doors: ");
            for (int i = 0; i < doorCount; i++)
            {
                System.Diagnostics.Debug.WriteLine("Direction: " + environmentInfo.Item1[i].Item1 + ", DestinationRoom: " + environmentInfo.Item1[i].Item2.Item1 + ", IsLocked: " + environmentInfo.Item1[i].Item2.Item2);
            }

            int blockCount = environmentInfo.Item2.Length;
            for (int j = 0; j < blockCount; j++)
            {
                System.Diagnostics.Debug.WriteLine("BlockType: " + environmentInfo.Item2[j].Item1 + ", posX: " + environmentInfo.Item2[j].Item2.Item1 + ", posY: " + environmentInfo.Item2[j].Item2.Item2);
            }
        }

        private void PrintItems()
        {
            int itemCount = itemArray.Length;
            System.Diagnostics.Debug.WriteLine("Items: ");
            for (int i = 0; i < itemCount; i++)
            {
                System.Diagnostics.Debug.WriteLine("Item name: " + itemArray[i].Item1 + ", posX: " + itemArray[i].Item2.Item1 + ", posY: " + itemArray[i].Item2.Item2);
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
