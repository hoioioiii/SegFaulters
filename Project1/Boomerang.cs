//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;


//namespace Project1
//{
//    internal class Boomerang : IWeaponProjectile
//    {
//        private Texture2D[] texture;

//        private bool activeAttack;

//        private String userDirection;

//        private String lastWeaponDirection;

//        private Vector2 userPosition;
//        private Vector2 lastWeaponPosition;


//        private Object mainUser;

//        private int currFrame;
//        private int totalFrame;

//        public Boomerang(Texture2D[] spritesheet) { 
//            activeAttack = false;
//            texture = spritesheet;
//            currFrame = 0;
//            totalFrame = 4;
//        }
//        public void Attack(Object user)
//        {
//           mainUser = user;
//           this.activeAttack = true;
//           GetUserPos();
//           DetermineWeaponState();
//        }
        


//        public void DetermineWeaponState()
//        {
//            this.lastWeaponDirection = userDirection;


//            DirectionManager.weaponLoaderToDirection;
           


//        }

//        public void GetUserPos()
//        {
//            this.userPosition =//;
//            this.lastWeaponPosition = userPosition;
//        }

//        public void GetUserState()
//        {
//            this.userState = //call a function
//        }

//        public void Draw(SpriteBatch spriteBatch)
//        {
            
//            Rectangle SOURCE_REC = new Rectangle(1, 1, texture[currFrame].Width, texture[currFrame].Height);
//            Rectangle DEST_REC = new Rectangle(this.lastWeaponPosition.X, this.lastWeaponPosition.Y, texture[currFrame].Width, texture[currFrame].Height);
//            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
//        }

//        public void Physics()
//        {
            
//        }

//        public void Update()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
