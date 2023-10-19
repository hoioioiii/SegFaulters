using Microsoft.Xna.Framework.Graphics;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project1
{
    //reads the XML file and sends info to Room Loader
    public static class LevelLoader
    {
        private static int roomCount;
        private static Room[] roomList;
        private static (string, ((int, int), (string, int)[]))[] enemyArray; //(string enemyName, ((int posX, int posY), (string itemName, int quantity)[]))
        private static ((string, (int, bool))[],(string,(int, int))[]) environmentInfo; //(doorArray, blockArray)
        private static int[] itemArray;
        public static void Load(string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            getRoomCountFromXmlDoc(xmlDoc);
            roomList = new Room[roomCount];

            parseXML(xmlDoc);
        }
        private static void parseXML(XmlDocument xmlDoc)
        {

            //loop through xml document and sends info of room to the Room instance
            XmlNodeList rooms = xmlDoc.GetElementsByTagName("Room");
            int i = 0;
            foreach (XmlNode room in rooms)
            {
                System.Diagnostics.Debug.WriteLine("Room " + i);

                //all rooms have these three encompassing nodes
                XmlNode enemies = room.SelectSingleNode("Enemies");
                XmlNode environment = room.SelectSingleNode("Environment");
                XmlNode items = room.SelectSingleNode("Items");

                parseEnemies(enemies);
                printEnemies();
                parseEnvironment(environment);
                printEnvironment();
                parseItems(items);

                roomList[i] = new Room();// enemyArray, environmentArray, itemArray);
                i++;
            }
        }

        //parses enemy info from xml doc, and make enemyArray out of it.
        private static void parseEnemies(XmlNode enemies)
        {
            //clear the enemyArray each time
            if (enemyArray != null)
                Array.Clear(enemyArray);

            //get all the enemies needed to be loaded in

            XmlNodeList enemyList = enemies.ChildNodes;
            int enemyCount = enemyList.Count;

            enemyArray = new (string, ((int, int), (string, int)[]))[enemyCount];
            int i = 0;
            //if there is enemies, go through each one of them
            foreach (XmlNode enemy in enemyList)
            {
                //get all necessary information for the enemyArray
                string name = enemy.Name;
                int posX = int.Parse(enemy.Attributes["xLoc"].Value);
                int posY = int.Parse(enemy.Attributes["yLoc"].Value);

                //cycle through dropped items make it into an array
                XmlNodeList droppedItemsList = enemy.SelectSingleNode("Drops").ChildNodes;
                (string, int)[] droppedItemArray = new (string, int)[droppedItemsList.Count];
                int j = 0;
                foreach(XmlNode droppedItem in droppedItemsList)
                {
                    string itemName = droppedItem.Attributes["Name"].Value;
                    int quantity = int.Parse(droppedItem.Attributes["quantity"].Value);
                    droppedItemArray[j] = (itemName, quantity);

                    j++;
                }

                //add to the enemy array
                enemyArray[i] = new(name, ((posX, posY), droppedItemArray));
                i++;
            }
        }
        private static void parseEnvironment(XmlNode environment)
        {
            XmlNodeList wallList = environment.SelectSingleNode("Walls").ChildNodes;
            XmlNodeList doorList = environment.SelectSingleNode("Doors").ChildNodes;
            XmlNodeList blockList = environment.SelectSingleNode("Blocks").ChildNodes;

            //so far no implementation for walls needed

            //get door information
            (string, (int, bool))[] doorArray = new (string, (int, bool))[doorList.Count];
            int i = 0;
            foreach(XmlNode door in doorList)
            {
                string direction = door.Attributes["id"].Value;
                int destinationRoom = int.Parse(door.SelectSingleNode("DestinationRoom").InnerText);
                bool isLocked = bool.Parse(door.SelectSingleNode("Locked").InnerText);

                doorArray[i] = (direction, (destinationRoom, isLocked));
                i++;
            }

            //get block information
            (string, (int, int))[] blockArray = new (string, (int, int))[blockList.Count];
            int j = 0;
            foreach(XmlNode block in blockList)
            {
                string blockType = block.Name;
                int posX = int.Parse(block.Attributes["xLoc"].Value);
                int posY = int.Parse(block.Attributes["yLoc"].Value);

                blockArray[j] = (blockType, (posX, posY));
                j++;
            }

            environmentInfo = (doorArray,  blockArray);
        }
        private static void parseItems(XmlNode items)
        {

        }

        private static void loadRooms()
        {
            roomList = new Room[roomCount];
        }

        private static void getRoomCountFromXmlDoc(XmlDocument doc)
        {
            roomCount = doc.GetElementsByTagName("Room").Count;
        }
        private static void printEnemies()
        {
            for (int i = 0; i < enemyArray.Length; i++)
            {
                System.Diagnostics.Debug.Write("Name: " + enemyArray[i].Item1 + ", Location: " + enemyArray[i].Item2.Item1 + ", Items: ");
                for (int j = 0; j < enemyArray[i].Item2.Item2.Length; j++)
                {
                    System.Diagnostics.Debug.Write(enemyArray[i].Item2.Item2[j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        private static void printEnvironment()
        {
            int doorCount = environmentInfo.Item1.Length;
            System.Diagnostics.Debug.WriteLine("Doors: ");
            for (int i = 0; i < doorCount; i++)
            {
                System.Diagnostics.Debug.WriteLine("Direction: " + environmentInfo.Item1[i].Item1 + ", DestinationRoom: " + environmentInfo.Item1[i].Item2.Item1 + ", IsLocked: " + environmentInfo.Item1[i].Item2.Item2);
            }
            System.Diagnostics.Debug.WriteLine("");
        }
        private static void sendInfo(/* data */)
        {
            //RoomLoader.Load(data)
        }
    }
}
