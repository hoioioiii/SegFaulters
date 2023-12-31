﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class EnvironmentIterator : IListIterate
    {
        public static Texture2D[] texture2D;

        Game1 GAME_OBJ;
        public static int pointer;
        Texture2D[] temp;

        public EnvironmentIterator(Game1 game1)
        {
            //create iterator here
            GAME_OBJ = game1;
            Load();
            pointer = 0;

            Game1.CurrentEnvironment = new CurrentBlock(texture2D[0]);
        }


        public void CreateList(Texture2D[] temp)
        {
            texture2D = temp;
        }

        public void Load()
        {
            Texture2D block0 = GAME_OBJ.Content.Load<Texture2D>("brick");
            Texture2D block1 = GAME_OBJ.Content.Load<Texture2D>("grass");
            Texture2D block2 = GAME_OBJ.Content.Load<Texture2D>("brick2");
            Texture2D block3 = GAME_OBJ.Content.Load<Texture2D>("brick3");
            Texture2D block4 = GAME_OBJ.Content.Load<Texture2D>("brick4");
            Texture2D block5 = GAME_OBJ.Content.Load<Texture2D>("brick5");
            Texture2D block6 = GAME_OBJ.Content.Load<Texture2D>("brick6");
            Texture2D block7 = GAME_OBJ.Content.Load<Texture2D>("brick7");
            Texture2D block8 = GAME_OBJ.Content.Load<Texture2D>("brick8");
            Texture2D block9 = GAME_OBJ.Content.Load<Texture2D>("forest");
            Texture2D block10 = GAME_OBJ.Content.Load<Texture2D>("brick10");


            Texture2D[] temp = { block0, block1, block2, block3, block4, block5, block6, block7, block8, block9 };

            CreateList(temp);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D drawItem = texture2D[pointer];

            spriteBatch.Draw(drawItem, new Vector2(200, 200), Color.White);

        }

        public static Texture2D getCurrEnemy(Boolean back)
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

        public static void moveBack()
        {
            if (pointer > 0)
            {
                pointer -= 1;
            }

        }

        public static void moveForward()
        {
            if (pointer < texture2D.Length - 1)
            {
                pointer += 1;
            }

        }
    }
}