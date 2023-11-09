using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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
            pointer = 2;

            //Game1.CurrentEnvironment = new CurrentBlock(texture2D[0]);
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

            Texture2D block11 = GAME_OBJ.Content.Load<Texture2D>("brickDragon");
            Texture2D block12 = GAME_OBJ.Content.Load<Texture2D>("brickFish");
            Texture2D block13 = GAME_OBJ.Content.Load<Texture2D>("brickWater");

            Texture2D block14 = GAME_OBJ.Content.Load<Texture2D>("BlackRoom");

            Texture2D[] temp = { block0, block1, block2, block3, block4, block5, block6, block7, block8, block9, block10, block11, block12, block13, block14};

            CreateList(temp);
        }

        //get the texture from the block name, given from the XML
        public static Texture2D GetTextureFromName(string name)
        {
            switch (name)
            {
                case ("DragonBlock"):
                    return texture2D[11];
                case ("FishBlock"):
                    return texture2D[12];
                case ("CarpetBlock"):
                    return texture2D[7];
                case ("BrickBlock"):
                    return texture2D[2];
                case ("Water"):
                    return texture2D[13];
                case ("Staircase"):
                    return texture2D[6];
                case ("BlackRoom"):
                    return texture2D[14];
                default:
                    return texture2D[10];
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D drawItem = texture2D[pointer];

            spriteBatch.Draw(drawItem, new Vector2(200, 200), Color.White);

        }

        public static Texture2D getCurrEnemy()
        {
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