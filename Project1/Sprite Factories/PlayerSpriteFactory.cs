using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Project1.Constants;
using System.Collections.Generic;

namespace Project1
{
    public class PlayerSpriteFactory
    {
      
        private Texture2D[] link1SpriteStorage = new Texture2D[PLAYER_FRAMES];
        private Texture2D[] linkAttackSpriteStorage = new Texture2D[PLAYER_FRAMES];
        private Texture2D[] link2SpriteStorage = new Texture2D[PLAYER_FRAMES];



        private List<Texture2D[]> LinkMovement = new List<Texture2D[]>() { new Texture2D[PLAYER_FRAMES_U], new Texture2D[PLAYER_FRAMES_R], new Texture2D[PLAYER_FRAMES_D], new Texture2D[PLAYER_FRAMES_L]};



        // More private Texture2Ds follow
        // ...

        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            //add all frames to the arrays
            //anything in all caps still needs to be updates with the new sprite

            // still
            link1SpriteStorage[(int)DIRECTION.up] = content.Load<Texture2D>(assetName: "LinkUp1");
            link1SpriteStorage[(int)DIRECTION.right] = content.Load<Texture2D>(assetName: "LinkRight1");
            link1SpriteStorage[(int)DIRECTION.down] = content.Load<Texture2D>(assetName: "LinkDown1");
            link1SpriteStorage[(int)DIRECTION.left] = content.Load<Texture2D>(assetName: "LinkLeft1");
            // movement only
            link2SpriteStorage[(int)DIRECTION.up] = content.Load<Texture2D>(assetName: "LinkUp2");
            link2SpriteStorage[(int)DIRECTION.right] = content.Load<Texture2D>(assetName: "LinkRight2");
            link2SpriteStorage[(int)DIRECTION.down] = content.Load<Texture2D>(assetName: "LinkDown2");
            link2SpriteStorage[(int)DIRECTION.left] = content.Load<Texture2D>(assetName: "LinkLeft2");


            //this is for later refactor
            LinkMovement[(int)DIRECTION.up][0] = content.Load<Texture2D>(assetName: "LinkUp1");
            LinkMovement[(int)DIRECTION.up][1] = content.Load<Texture2D>(assetName: "LinkUp2");

            LinkMovement[(int)DIRECTION.right][0] = content.Load<Texture2D>(assetName: "LinkRight1");
            LinkMovement[(int)DIRECTION.right][1] = content.Load<Texture2D>(assetName: "LinkRight2");

            LinkMovement[(int)DIRECTION.down][0] = content.Load<Texture2D>(assetName: "LinkDown1");
            LinkMovement[(int)DIRECTION.down][1] = content.Load<Texture2D>(assetName: "LinkDown2");

            LinkMovement[(int)DIRECTION.left][0] = content.Load<Texture2D>(assetName: "LinkLeft1");
            LinkMovement[(int)DIRECTION.left][1] = content.Load<Texture2D>(assetName: "LinkLeft2");


            // Attack using weapon or item
            linkAttackSpriteStorage[(int)DIRECTION.right] = content.Load<Texture2D>(assetName: "LinkAttackRight");
            linkAttackSpriteStorage[(int)DIRECTION.left] = content.Load<Texture2D>(assetName: "LinkAttackLeft");
            linkAttackSpriteStorage[(int)DIRECTION.up] = content.Load<Texture2D>(assetName: "LinkAttackUp");
            linkAttackSpriteStorage[(int)DIRECTION.down] = content.Load<Texture2D>(assetName: "LinkAttackDown");


            // More Content.Load calls follow
            //...
        }


        public IPlayerSprite CreateLinkSprite()
        {
            return new LinkSprite(link1SpriteStorage, link2SpriteStorage, linkAttackSpriteStorage);
        }

        //this is for later refactor
        public IPlayerSprite CreateLinkSpriteTest(IAnimationPlayer animation)
        {
            return new PlayerSprite(link1SpriteStorage, LinkMovement, linkAttackSpriteStorage,animation);
        }

        // More public ISprite returning methods follow
        // ...
    }
}
