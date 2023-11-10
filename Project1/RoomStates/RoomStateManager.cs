using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class RoomStateManager
    {
        private Dictionary<int, IActiveObjects> roomEntityState; // Map room ID to its active objects

        public RoomStateManager()
        {
            roomEntityState = new Dictionary<int, IActiveObjects>();
        }

        public void SaveCurrentRoomState(IActiveObjects activeObjects)
        {
            int currentRoomIndex = RoomManager.GetCurrentRoomIndex();
            roomEntityState[currentRoomIndex] = activeObjects; // Save the state of active objects for the current room
        }

        public IActiveObjects LoadCurrentRoomState()
        {
            int currentRoomIndex = RoomManager.GetCurrentRoomIndex();
            if (roomEntityState.ContainsKey(currentRoomIndex))
            {
                return roomEntityState[currentRoomIndex]; // Retrieve the state of active objects for the current room
            }
            return null; // Handle non-existence of data for the current room
        }
    }
}