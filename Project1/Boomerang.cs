using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        private Vector2 projectilePosition;

        private int currFrame;
        private int totalFrame;

        public Boomerang(Vector2 userPosition, int direction) { 
            currFrame = 0;
            totalFrame = 3;

            this.userPosition = userPosition;
            this.userDirection = direction;

            projectilePosition = userPosition;
        }
        public void Attack()
        {
            if (!activeAttack) {
                this.activeAttack = true;
                
                
            }
        }


        public void LoadContent(ContentManager content)
        {
            texture[0] = content.Load<Texture2D>("boomerang1");
            texture[1]  = content.Load<Texture2D>("boomerang2");
            texture[2] = content.Load<Texture2D>("boomerang3");
            texture[3] = content.Load<Texture2D>("boomerang4");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (userDirection) { //based on the userdirection, change the projectile position in the appropriate direction
                case 1: //shot upwards
                    projectilePosition.X += 0; //X wont change
                    projectilePosition.Y += 10;
                    break;
                    //other cases for each direction
            }
            Rectangle DEST_REC = new Rectangle((int)this.userPosition.X, (int)this.userPosition.Y, texture[currFrame].Width, texture[currFrame].Height);
            spriteBatch.Draw(texture[(int)currFrame], DEST_REC, Color.White);
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
