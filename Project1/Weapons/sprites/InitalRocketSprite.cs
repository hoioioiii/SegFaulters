using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.SmartAI;
using static Project1.Constants;
namespace Project1
{
    internal class InitalRocketSprite : ISpriteWeapon
    {

        private Texture2D[] texture;

        private bool rocketPlaced;
        private int current_frame;

        private int elapsedTime;

        private int width;
        private int height;

        private bool completed;
        private bool drawExplosion;
        private Direction direction;
        private int offset;
        private Rectangle rec;
        private IMove movement_manager;
        private RangeDetectionToPlayer rangeDetector;

        public InitalRocketSprite(Texture2D[] spriteSheet)
        {
            texture = spriteSheet;
            current_frame = 0;
            elapsedTime = 0;

            width = spriteSheet[0].Width;
            height = spriteSheet[0].Height;

            movement_manager = new WeaponMove((int)Player.getPosition().X, (int)Player.getPosition().Y);
            

            rocketPlaced = false;
            completed = false;
            direction = playerNumToDirection();
            rangeDetector = new RangeDetectionToPlayer(movement_manager, 100);
        }

        private void setRocket()
        {
            if (!completed)
                rocketPlaced = true;
        }
        private void removeRocket()
        {
            rocketPlaced = false;
        }

        public void Attack()
        {

            DetermineWeaponState();
            setRocket();

        }

        private void DetermineWeaponState()
        {
            if (!rocketPlaced)
            {
                placeOffset();
            }
        }

        public void Update()
        {
            Move();

            if (drawExplosion)
            {


            }

        }

        

        private void placeOffset()
        {
            filterPlayerPosition();

        }

        private void drawItem(int x, int y, SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, width, height);
            Rectangle DEST_REC = new Rectangle(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, width * LARGER_SIZE, height * LARGER_SIZE);
            rec = DEST_REC;
            spriteBatch.Draw(texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
        public Rectangle GetRectangle()
        {
            return rec;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Attack();
            if (rocketPlaced)
            {
                drawItem(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, spriteBatch);
            }
        }

        /*
         * filters movement for each orb:
         * 
         */
        private void filterMovementX(Direction type)
        {

            int weaponX = movement_manager.getPosition().Item1;
            int weaponY = movement_manager.getPosition().Item2;
            switch (type)
            {
                case Direction.Left:
                    weaponX -= WEAPON_INITAL_SPD;
                    break;
                case Direction.Right:
                    weaponX += WEAPON_INITAL_SPD;
                    break;
            }

            movement_manager.setPosition(weaponX, weaponY);
        }

        private void filterMovementY(Direction type)
        {
            //this is going to need to be based on hypotenus

            int weaponY = movement_manager.getPosition().Item2;
            switch (type)
            {
                case Direction.Up:
                    weaponY -= WEAPON_INITAL_SPD;
                    break;
                case Direction.Down:
                    weaponY += WEAPON_INITAL_SPD;
                    break;
            }

            movement_manager.setPosition(movement_manager.getPosition().Item1, weaponY);
        }

        private int filterPlayerPosition()
        {
            int playerY = (int)Player.getPositionAndRectangle().Location.Y;

            //Change in the future:
            //Later change it so in the future, if the player is farther. Have the y have a smaller slope
            if (playerY < movement_manager.getPosition().Item2)
            {
                offset = -1;
            }
            else
            {
                offset = 1;
            }

            return offset;

        }

        private void filterMoveAll(Direction type)
        {
            filterMovementX(type);
            filterMovementY(type);
        }
        private void Move()
        {
            filterMoveAll(direction);
            checkFinish();
        }


        private Direction playerNumToDirection()
        {
            int direction = Player.getUserDirection();
            switch(direction)
            {
                case 0:
                    return Direction.Up;
                    
                case 1:
                    return Direction.Right;
                 case 2:
                    return Direction.Down;
                 case 3:
                    return Direction.Left;
                 default:
                    return Direction.Down;
            }
        }


        public bool finished()
        {
            return completed;
        }

        private bool FinishConditions()
        {

            //If it collides with a wall,
            if (CheckBoundary(movement_manager.getPosition().Item1, roomBoundsMaxX, roomBoundsMinX) || CheckBoundary(movement_manager.getPosition().Item2, roomBoundsMaxY, roomBoundsMinY))
            {
                return true;
            }

            //if the time slot is up
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= 1000)
            {
                return true;
            }
            return false;
        }

        private bool CheckBoundary(int pos, int upperBound, int lowerBound)
        {
            if ((pos >= upperBound) || (pos <= lowerBound))
            {
                return true;
            }
            return false;
        }


        private void checkFinish()
        {
            if (FinishConditions())
            {

                removeRocket();
                completed = true;
                //drawExplosion = true;
                CreateSubWeapons();
            }
        }

        private void CreateSubWeapons()
        {
            //(int, int) pos = (movement_manager.getPosition().Item1 + Random.RandomSeconds(), movement_manager.getPosition().Item2 + Random.RandomSeconds());
            
            for (int i = 0; i < 5; i++)
            {
                (int, int) pos = (movement_manager.getPosition().Item1 + Random.RandomSeconds(), movement_manager.getPosition().Item2 + Random.RandomSeconds());
                IWeapon topRocket = new Rocket(pos, ORB_DIRECTION.TOP);
                IWeapon middleRocket = new Rocket(pos, ORB_DIRECTION.MIDDLE);
                IWeapon botRocket = new Rocket(pos, ORB_DIRECTION.BOTTOM);

                Game1.GameObjManager.addNewPlayerWeapon(topRocket);
                Game1.GameObjManager.addNewPlayerWeapon(middleRocket);
                Game1.GameObjManager.addNewPlayerWeapon(botRocket);

                Game1.GameObjManager.addNewDetectionWeapon(topRocket);
                Game1.GameObjManager.addNewDetectionWeapon(middleRocket);
                Game1.GameObjManager.addNewDetectionWeapon(botRocket);
            }
        }



        public void GetUserPos(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void GetUserState(Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public Rectangle getDetectionFieldRectangle()
        {
            throw new NotImplementedException();
        }

        public void MovementChange(bool detected)
        {
            throw new NotImplementedException();
        }

        public void setTarget(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
