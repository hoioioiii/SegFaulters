using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //Takes in the needed info for all respective rooms, and creates an array of Room instances
    public static class RoomLoader
    {
        private static int roomCount;
        private static Room[] roomList;
        public static void Load(/* data */) {
            roomCount = 0; //load in total room count
            roomList = new Room[roomCount];
            //LoadRooms(roomList, roomCount, data*)
        }
        private static void LoadRooms(Room[]roomList, int roomCount)
        {
            for (int i = 0; i < roomCount; i++)
            {
                roomList[i] = new Room(/* data */); //data consists of the enemies and blocks in each room
            }
        }
    }
}
