using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //Takes in the needed info for all respective rooms, and creates an array of Room instances. Calls upon correct room depending on RoomManager
    public static class RoomLoader
    {
        private static int roomCount;
        private static Room[] roomList;
        public static void Load(/* data */) {
            roomCount = 0; //load in total room count
            //LoadRooms(roomList, roomCount, data*)
        }
        private static void LoadRooms(Room[]roomList, int roomCount)
        {
            for (int i = 0; i < roomCount; i++)
            {
            }
        }
    }
}
