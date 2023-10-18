using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project1
{
    //reads the XML file and sends info to Room Loader
    public static class LevelLoader
    {
        private static int roomCount;
        public static void Load(string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            parseXML(xmlDoc);
        }
        private static void parseXML(XmlDocument xmlDoc)
        {

            //loop through xml document and send all the info to sendInfo
            //sendInfo(data)
            XmlNodeList rooms = xmlDoc.GetElementsByTagName("Room");
            roomCount = rooms.Count;

            foreach (XmlNode room in rooms)
            {
                //all rooms have these three encompassing nodes
                XmlNode enemies = room.SelectSingleNode("Enemies");
                XmlNode environment = room.SelectSingleNode("Environment");
                XmlNode items = room.SelectSingleNode("Items");

                parseEnemies(enemies);
            }

            //System.Diagnostics.Debug.WriteLine(rooms[0].Attributes["number"].Value);
        }
        private static void parseEnemies(XmlNode enemies)
        {
            //get all the enemies needed to be loaded in

            XmlNodeList enemyList = enemies.ChildNodes;
            if(enemyList.Count == 0) //if no enemies
            {
                System.Diagnostics.Debug.WriteLine("Empty");
                return;
            }

            //if there is enemies, go through each one of them
            foreach (XmlNode enemy in enemyList)
            {
            }
        }
            
        private static void sendInfo(/* data */)
        {
            //RoomLoader.Load(data)
        }
    }
}
