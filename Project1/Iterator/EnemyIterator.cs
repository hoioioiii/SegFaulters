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
    internal class EnemyIterator : IListIterate
    {

        public Texture2D[] texture2D;

        public static IEntity[] ENTITY;
        Game1 GAME_OBJ;
        public static int pointer;

        public EnemyIterator(Game1 game1)
        {
            //create iterator here  
            Load();
            pointer = 0;
            GAME_OBJ = game1;
            Game1.ENEMY = ENTITY[pointer];
        }
        public void CreateList(Texture2D[] ignore)
        {
            (String, int)[] items = { ("Arrow", 0) };
            (int, int) pos = (SPRITE_X_START, SPRITE_Y_START);


            IEntity[] temp = { new Bat(pos, items), new BossAquaDragon(pos, items), new BossDino(pos, items), new BossFireDragon(pos, items), new DogMonster(pos, items), new Flame(pos, items), new Hand(pos, items), new Jelly(pos, items),new Merchant(pos, items),new OldMan(pos, items),new Skeleton(pos, items), new Snake(pos, items), new SpikeCross(pos, items) }; 
            ENTITY = temp;
        }
        
        public void Load()//this would not exist but instead call the enemy class
        {
            CreateList(texture2D);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            IEntity entitySprite = ENTITY[pointer];
            entitySprite.Draw(spriteBatch);

        }

        public static IEntity getCurrEnemy(Boolean back)
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
