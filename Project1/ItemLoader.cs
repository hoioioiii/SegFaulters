using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Project1.Constants;

namespace Project1
{
    //Item loader's scope is initializing and creating items and drawing them to a specified location
    //By creating a new itemLoader object, one can call upon a method that is able to do so
    public class ItemLoader
    {
        private static IActiveObjects GameOBJ;
        private static IItem currItem;

        public static void LoadAndInitializeItems(String itemString, (int, int) pos, IActiveObjects objManager)
        {
            GameOBJ = objManager;
            initItems(itemString, pos);
            GameOBJ.addNewItem(currItem);
        }

        public static void initItems(String itemString, (int,int) pos)
        {

            
            switch (itemString)
            {
                case "bomb":
                    currItem = new BombItem(pos);
                    break;
                case "arrow":
                    currItem = new ArrowItem(pos);
                    break;
                case "boomerang":
                    currItem = new BoomerangItem(pos);
                    break;
                case "clock":
                    currItem = new Clock(pos);
                    break;
                case "fairy":
                    currItem = new Fairy(pos);
                    break;
                case "heartcontainer":
                    currItem = new HeartContainer(pos);
                    break;
                case "key":
                    currItem = new Key(pos);
                    break;
                case "map":
                    currItem = new Map(pos);
                    break;
                case "rupee":
                    currItem = new Rupee(pos);
                    break;
                case "sword":
                    currItem = new SwordItem(pos);
                    break;
                case "triforce":
                    currItem = new Triforce(pos);
                    break;
            }
        }


            
        }
}