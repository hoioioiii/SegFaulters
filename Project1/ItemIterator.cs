using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Project1
{
    public class ItemIterator : IListIterate
    {
        public static IItem[] entity;
        Game1 game_obj;
        public static int pointer;

        public ItemIterator(Game1 game1)
		{
            CreateList();
            pointer = 0;
            game_obj = game1;
            Game1.itemSprite = entity[pointer];
        }
        public void CreateList()
        {
            IItem[] temp = { new Compass(), new Map(), new Key(), new HeartContainer(game_obj), new TriforcePiece(), new WoodenBoomerang(game_obj), new Bow(game_obj), new Heart(game_obj), new Rupee(game_obj), new Arrow(game_obj), new Bomb(game_obj), new Fairy(game_obj), new Clock(game_obj) };
            entity = temp;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            IItem entitySprite = entity[pointer];
            entitySprite.Draw(spriteBatch);

        }

        public static IItem getCurrEnemy(Boolean back)
        {
            if (back)
            {
                moveBack();
            }
            else
            {
                moveForward();
            }



            return entity[pointer];
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
            if (pointer < entity.Length - 1)
            {
                pointer += 1;
            }


        }


    }
}

