using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    internal class ItemIterator : IListIterate
    {

        public Texture2D[] texture2D;


        public static IItem[] ENTITY;
        Game1 GAME_OBJ;
        public static int pointer;

        public ItemIterator(Game1 game1)
        {
            //create iterator here  
            Load();
            pointer = (int)ITEMS.Sword;
            GAME_OBJ = game1;
            Game1.Item = ENTITY[pointer];
        }
        public void CreateList(Texture2D[] ignore)
        {
            int x = (int)Player.getUserPos().X;
            int y = (int)Player.getUserPos().Y;
            IItem[] temp = { new ArrowItem((x,y)), new BombItem((x, y)), new BoomerangItem((x, y)), new Bow((x, y)), new Clock((x, y)), new Fairy((x, y)), new Heart((x, y)), new HeartContainer((x, y)),new Key((x, y)),new Map((x, y)),new Rupee((x, y)), new SwordItem((x, y)), new Triforce((x, y)) }; 
            ENTITY = temp;
        }
        
        public void Load()
        {
            CreateList(texture2D);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            IItem entitySprite = ENTITY[pointer];
            entitySprite.Draw(spriteBatch);

        }

        public static IItem getCurrItem()
        {
   

            return ENTITY[pointer];
        }

        public static void moveBack()
        {
            if (pointer > 0)
            {
                pointer -= 1;
            }
           

        }
        public static void moveForward()
        {
            if (pointer < ENTITY.Length - 1)
            {
                pointer += 1;
            }
            

        }
    }
}
