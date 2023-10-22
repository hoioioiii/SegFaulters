using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //The state machine which manages which room is currently active
    public static class RoomManager
    {
        private static Dictionary<int, bool> activeList;
        
        public static void Load()
        {
            //load in list of active rooms
            activeList = new Dictionary<int, bool>();
            
            for(int i = 0; i < LevelLoader.roomCount; i++)
            {
                activeList.Add(i, false);
            }
            activeList[0] = true;
            DrawActiveRoom();
        }

        public static void SetActiveRoom(int roomId)
        {
            for(int i = 0; i < activeList.Count; i++)
            {
                if (activeList[i])
                {
                    activeList[i] = false;
                }
            }
            activeList[roomId] = true;
            DrawActiveRoom();
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

            n++;
            if(n >= activeList.Count)
            {
                n = 0;
            }

            activeList[n] = true;
            DrawActiveRoom();
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

            n--;
            if (n < 0)
            {
                n = activeList.Count - 1;
            }

            activeList[n] = true;
            DrawActiveRoom();
        }

        public static void DrawActiveRoom()
        {
            
            for (int i = 0; i < activeList.Count-1; i++)
            {
                if (activeList[i])
                {
                    LevelLoader.drawActiveRoom(i);
                }
            }
        }
    }
}
