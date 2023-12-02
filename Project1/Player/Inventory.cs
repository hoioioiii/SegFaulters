using System;
using static Project1.Constants;

namespace Project1
{
	public static class Inventory
	{
        //this enum is used to access the inventory by item type:
        //public enum ITEMS { Arrow = 0, Bomb = 1, Boomerang = 2, Bow = 3, Clock = 4, Fairy = 5, Heart = 6, HeartContainer = 7, Key = 8, Map = 9, Rupee = 10, Sword = 11, Triforce = 12 };
        public static int[] itemInventory = ITEM_INVENTORY;

        public static void PickUpItem(ITEMS itemToAdd)
        {
            itemInventory[(int)itemToAdd] = itemInventory[(int)itemToAdd] + 1;
        }

        public static bool UseItem(ITEMS itemToDelete)
        {
            bool didItemGetUsed;
            if (itemInventory[(int)itemToDelete] > 0)
            {
                itemInventory[(int)itemToDelete]--;
                didItemGetUsed = true; //if player has item, it got used.
            }
            else
            {
                didItemGetUsed = false; //if player does not have item, it did not get used.
            }

            return didItemGetUsed;
        }
    }
}

