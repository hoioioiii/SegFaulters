using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Project1.Constants;

namespace Project1
{
    public class PlayerSpriteFactory
    {
        
        private Texture2D[] linkSheet = new Texture2D[LINK_C * LINK_R];
        private Texture2D[] linkSheetAttack = new Texture2D[LINK_C * LINK_R];
        private Texture2D[] linkSheetMove = new Texture2D[LINK_C * LINK_R];
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

        private PlayerSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //add all frames to the arrays
            //anything in all caps still needs to be updates with the new sprite
            
            linkSheet[0] = content.Load<Texture2D>("linkRight1");
            linkSheet[1] = content.Load<Texture2D>("linkLeft1");
            linkSheet[2] = content.Load<Texture2D>("linkUp1");
            linkSheet[3] = content.Load<Texture2D>("linkDown1");

            // movement only
            linkSheetMove[0] = content.Load<Texture2D>("linkRight2");
            linkSheetMove[1] = content.Load<Texture2D>("linkLeft2");
            linkSheetMove[2] = content.Load<Texture2D>("linkUp2");
            linkSheetMove[3] = content.Load<Texture2D>("linkDown2");

            // Attack using weapon or item
            linkSheetAttack[0] = content.Load<Texture2D>("linkAttackRight");
            linkSheetAttack[1] = content.Load<Texture2D>("linkAttackLeft");
            linkSheetAttack[2] = content.Load<Texture2D>("linkAttackUp");
            linkSheetAttack[3] = content.Load<Texture2D>("linkAttackDown");

        }
        
       
        public ISprite CreateLinkSheet()
        {
            return new PlayerSprite(linkSheet, linkSheetMove, linkSheetAttack);
        }
    }
}

