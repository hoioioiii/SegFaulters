using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project1
{
    //Item loader's scope is initializing and creating items and drawing them to a specified location
    //By creating a new itemLoader object, one can call upon a method that is able to do so
    public class ItemLoader
    {

        public static void InitializeItemSprites(String itemString, (int,int) pos)
        {
          
                IItem item = ItemInitializer.getInstance(itemString, pos);
                Game1.GameObjManager.addNewItem(item);
            
      
        }
    }
}