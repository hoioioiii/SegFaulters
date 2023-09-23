using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;

namespace Project1
{
	public class EnemySpriteFactory
	{
        //private Texture2D goombaSpritesheet;
        //private Texture2D koopaSpritesheet;
        private Texture2D batSpritesheet;
        // More private Texture2Ds follow
        // ...

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //goombaSpriteSheet = content.Load<Texture2D>("goomba");
            batSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            // More Content.Load calls follow
            //...
        }
        /*
        public IEnemy CreateGoombaSprite()
        {
            return new GoombaSprite(goombaSpritesheet, Game1.Instance.level.isAboveGround);
        }

        public IEnemy CreateKoopaSprite()
        {
            return new KoopaSprite(koopaSpritesheet, 32, 32);
        }

        public IEnemy CreateGiantKoopaSprite()
        {
            return new KoopaSprite(koopaSpritesheet, 64, 64);
        }
        */
        public IEnemy CreateBatSprite()
        {
            Bat.setFrames();
            return new Bat(batSpritesheet);
        }
        // More public ISprite returning methods follow
        // ...
    }
}

// Client code in main game class' LoadContent method:
//EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
//ISprite mySprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
