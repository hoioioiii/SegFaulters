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
            pointer = 0;
            GAME_OBJ = game1;
            Game1.Item = ENTITY[pointer];
        }
        public void CreateList(Texture2D[] ignore)
        {
            IItem[] temp = { new ArrowItem(), new BombItem(), new BoomerangItem(), new Bow(), new Clock(), new Fairy(), new Heart(), new HeartContainer(),new Key(),new Map(),new Rupee(), new SwordItem(), new Triforce()}; 
            ENTITY = temp;
        }
        
        public void Load()//this would not exist but instead call the enemy class
        {
            CreateList(texture2D);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            IItem entitySprite = ENTITY[pointer];
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
