using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //the actual room; uses environment, item, and enemy loader to load in the respective information 
    internal class Room
    {
        private (string, ((int, int), (string, int)[]))[] enemyArray; //(string enemyName, ((int posX, int posY), (string itemName, int quantity)[]))
        private ((string, (int, bool))[], (string, (int, int))[]) environmentInfo; //(doorArray, blockArray)
        private (string, (int, int))[] itemArray;//(string itemName,(int posX, posY))
        public Room((string, ((int, int), (string, int)[]))[] enemyArray, ((string, (int, bool))[], (string, (int, int))[]) environmentInfo, (string, (int, int))[] itemArray) 
        {
            this.enemyArray = enemyArray;
            this.environmentInfo = environmentInfo;
            this.itemArray = itemArray;
        }

        public void Load()
        {
            LoadEnvironment();
        }

        private void LoadEnvironment()
        {
            (string, (int, int))[] blocks = environmentInfo.Item2;
            (int, int)[] blocksToLoad = new (int, int)[blocks.Length];
            for (int i = 0;i < blocks.Length; i++)
            {
                blocksToLoad[i] = blocks[i].Item2;
            }
            EnvironmentLoader.LoadBlocks(blocksToLoad);

            (string, (int, bool))[] doors = environmentInfo.Item1;
            //TODO: code door loading in, most of the code will be in environment loader
        }
        
        public void print()
        {
            printEnemies();
            printEnvironment();
            printItems();
        }
        private void printEnemies()
        {
            for (int i = 0; i < enemyArray.Length; i++)
            {
                System.Diagnostics.Debug.Write("Enemy Name: " + enemyArray[i].Item1 + ", Location: " + enemyArray[i].Item2.Item1 + ", Items: ");
                for (int j = 0; j < enemyArray[i].Item2.Item2.Length; j++)
                {
                    System.Diagnostics.Debug.Write(enemyArray[i].Item2.Item2[j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        private void printEnvironment()
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
                System.Diagnostics.Debug.WriteLine("BlockType: " + environmentInfo.Item2[j].Item1 + ", posX: " + environmentInfo.Item2[j].Item2.Item1 + ", posY: " + environmentInfo.Item2[j].Item2.Item1);
            }
        }

        private void printItems()
        {
            int itemCount = itemArray.Length;
            System.Diagnostics.Debug.WriteLine("Items: ");
            for (int i = 0; i < itemCount; i++)
            {
                System.Diagnostics.Debug.WriteLine("Item name: " + itemArray[i].Item1 + ", posX: " + itemArray[i].Item2.Item1 + ", posY: " + itemArray[i].Item2.Item1);
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
