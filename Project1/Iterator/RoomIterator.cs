using System;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
/*
namespace Project1.Iterator
{
	public class RoomIterator : IListIterate
    {
        
        public Texture2D[] texture2D;

        //change to data type of Game1.Room
        public static IRoom[] ROOMS;
        Game1 GAME_OBJ;
        public static int pointer;
        public RoomIterator(Game1 game1)
		{
            Load();
            pointer = 0;
            GAME_OBJ = game1;
            Game1.Room = ROOMS[pointer];
        }

        public void CreateList(Texture2D[] ignore)
        {
            IRoom[] temp = { new ArrowItem(), new BombItem(), new BoomerangItem(), new Bow(), new Clock(), new Fairy(), new Heart(), new HeartContainer(), new Key(), new Map(), new Rupee(), new SwordItem(), new Triforce() };
            ROOMS = temp;
        }

        public void Load()
        {
            CreateList(texture2D);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            IRoom entitySprite = ROOMS[pointer];
            entitySprite.Draw(spriteBatch);

        }

        public static IItem getCurrItem(Boolean back)
        {
            
            if (back)
            {
                moveBack();
            }
            else
            {
                moveForward();
            }
            

            return ROOMS[pointer];
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
            if (pointer < ROOMS.Length - 1)
            {
                pointer += 1;
            }


        }
    }
}
*/