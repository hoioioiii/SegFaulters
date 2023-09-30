using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace Project1
{
    internal class Boomerang : IWeaponProjectile
    {
        private Texture2D[] texture;

        private bool activeAttack;

        private int userDirection;

        private Vector2 userPosition;

        private int currFrame;
        private int totalFrame;

        public Boomerang(Texture2D[] spritesheet, Vector2 userPosition, int direction) { 
            texture = spritesheet;
            currFrame = 0;
            totalFrame = 3;

            this.userPosition = userPosition;
            this.userDirection = direction;
        }
        public void Attack()
        {
            if (!activeAttack) {
                this.activeAttack = true;
                
                
            }
        }



        public void DetermineWeaponState()
        {
            this.lastWeaponDirection = userDirection;


            //DirectionManager.weaponLoaderToDirection;



        }

        public void GetUserState()
        {
            this.userState //call a function
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, 1, texture[currFrame].Width, texture[currFrame].Height);
            Rectangle DEST_REC = new Rectangle((int)this.lastWeaponPosition.X, (int)this.lastWeaponPosition.Y, texture[currFrame].Width, texture[currFrame].Height);
            spriteBatch.Draw(texture[(int)currFrame], DEST_REC, SOURCE_REC, Color.White);
        }

        public void Physics()
        {
            //no physics
        }

        public void Update()
        {
            
        }
    }
}
