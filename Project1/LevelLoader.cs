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
        }
        private static void sendInfo(/* data */)
        {
            //RoomLoader.Load(data)
        }
    }
}
