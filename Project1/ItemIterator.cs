using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class ItemIterator : IListIterate
    {

        public Texture2D[] texture2D;
        Game1 GAME_OBJ;
        public int pointer;

        public ItemIterator(Game1 game1) {
            //create iterator here  
            Load();
            pointer = 0;
            GAME_OBJ = game1;
        }
        public void CreateList(Texture2D[] temp)
        {
           texture2D = temp;
        }
        
        public void Load()//this would not exist but instead call the enemy class
        {
            Texture2D item0 = GAME_OBJ.Content.Load<Texture2D>("Compass");
            Texture2D item1= GAME_OBJ.Content.Load<Texture2D>("Map");
            Texture2D item2 = GAME_OBJ.Content.Load<Texture2D>("Key");
            Texture2D item3 = GAME_OBJ.Content.Load<Texture2D>("Heart");
            Texture2D item4 = GAME_OBJ.Content.Load<Texture2D>("HeartContainer");
            Texture2D item5 = GAME_OBJ.Content.Load<Texture2D>("Triforce");
            Texture2D item6 = GAME_OBJ.Content.Load<Texture2D>("Boomerang");
            Texture2D item7 = GAME_OBJ.Content.Load<Texture2D>("Bow");
            Texture2D item8 = GAME_OBJ.Content.Load<Texture2D>("Heart");
            Texture2D item9 = GAME_OBJ.Content.Load<Texture2D>("Rupee");
            Texture2D item10 = GAME_OBJ.Content.Load<Texture2D>("Arrow");
            Texture2D item11= GAME_OBJ.Content.Load<Texture2D>("Bomb");
            Texture2D item12= GAME_OBJ.Content.Load<Texture2D>("Fairy");
            Texture2D item13= GAME_OBJ.Content.Load<Texture2D>("Clock");


            Texture2D[] temp = {item1,item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13};
            CreateList(temp);
        }

        public void Draw(SpriteBatch spriteBatch)
            {
            Texture2D drawItem = texture2D[pointer];

            spriteBatch.Draw(drawItem, new Vector2(200, 200), Color.White);

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



            return texture2D[pointer];
        }


        public void moveBack()
        {
            if (pointer > 0)
            {
                pointer -= 1;
            }
           
        }
        public void moveForward()
        {
            if (pointer < texture2D.Length)
            {
                pointer += 1;
            }
            
        }
    }
}
