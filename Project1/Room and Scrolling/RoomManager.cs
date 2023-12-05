using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;


namespace Project1
{
    //The state machine which manages which room is currently active
    public static class RoomManager
    {
        private static Dictionary<int, bool> activeList;
        private static int currentRoomIndex;
        
        //Have Room manager own their own Active GAME oBJECT MANAGER

        public static void Load()
        {
            //load in list of active rooms
            activeList = new Dictionary<int, bool>();
            
            for(int i = 0; i < LevelLoader.roomCount; i++)
            {
                activeList.Add(i, false);
            }
            activeList[0] = true;
            DrawActiveRoom(0, DIRECTION.none);
            currentRoomIndex = 0;
        }

        public static void SetActiveRoom(int roomId, DIRECTION doorDirection)
        {
            int oldRoom = 0;

            PositionGrid.Update();
            for (int i = 0; i < activeList.Count; i++)
            {
                if (activeList[i])
                {
                    oldRoom = i;
                    activeList[i] = false;
                }
            }
            activeList[roomId] = true;
            DrawActiveRoom(oldRoom, doorDirection);
            currentRoomIndex = roomId;
        }
        public static void IncrementActiveRoom()
        {
            int n = 0;
            for (int i = 0; i < activeList.Count; i++)
            {
                if (activeList[i])
                {
                    n = i;
                    activeList[i] = false;
                }
            }
            int oldRoom = n;
            n++;
            if (n >= activeList.Count)
            {
                n = 0;
            }

            activeList[n] = true;
            DrawActiveRoom(oldRoom, DIRECTION.none);
            currentRoomIndex = n;
        }
        public static void DecrementActiveRoom()
        {
            int n = 0;
            for (int i = 0; i < activeList.Count; i++)
            {
                if (activeList[i])
                {
                    n = i;
                    activeList[i] = false;
                }
            }
            int oldRoom = n;
            n--;
            if (n < 0)
            {
                n = activeList.Count - 1;
            }

            activeList[n] = true;
            DrawActiveRoom(oldRoom, DIRECTION.none);
            currentRoomIndex = n;
        }

        public static int GetActiveRoomNumber()
        {
            for (int i = 0; i < activeList.Count; i++)
            {
                if (activeList[i])
                    return i;
            }

            return -1;
        }

        public static void DrawActiveRoom(int oldRoom, DIRECTION doorDirection)
        {

            for (int i = 0; i < activeList.Count - 1; i++)
            {
                if (activeList[i])
                {
                    LevelLoader.drawActiveRoom(oldRoom, i, doorDirection);
                }
            }
        }

        public static Dictionary<int, bool> GetActiveList()
        {
            return activeList;
        }

        public static int GetCurrentRoomIndex()
        {
            return currentRoomIndex;
        }


    }
}
