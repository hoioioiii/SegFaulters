using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //Switch case class for items that when passed in a string containing the name, it returns an initialized object of the type
    // needed for item loader.
    public class ItemInitializer
    {
        public static IItem getInstance(String item, (int,int) pos)
        {
            IItem itemObject;
            switch (item)
            {
                case "bomb":
                    return itemObject = new BombItem(pos);
                case "arrow":
                    return itemObject = new ArrowItem(pos);
                case "boomerang":
                    return itemObject = new BoomerangItem(pos);
                case "clock":
                    return itemObject = new Clock(pos);
                case "fairy":
                    return itemObject = new Fairy(pos);
                case "heartcontainer":
                    return itemObject = new HeartContainer(pos);
                case "key":
                    return itemObject = new Key(pos);
                case "map":
                    return itemObject = new Map(pos);
                case "rupee":
                    return itemObject = new Rupee(pos);
                case "sword":
                    return itemObject = new SwordItem(pos);
                case "triforce":
                    return itemObject = new Triforce(pos);
            }
            //this case should never happen if the passed in string list has correct spelling.
            return itemObject = null;
        }
    }
}