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
    internal class BeesSprite : ISpriteWeapon
    {

        private List<Texture2D[]> texture;

        private bool rocketPlaced;
        private int current_frame;

        private int elapsedTime;

        private int width;
        private int height;

        private bool completed;
        private bool drawExplosion;
        private ORB_DIRECTION rocketType;
        private int offset;
        private Rectangle rec;
        private IMove movement_manager;
        private IAnimation animation_manager;
        private IEntity target;
        private bool detected;
        public BeesSprite(List<Texture2D[]> spriteSheet, (int, int) pos, ORB_DIRECTION rocketType)
        {
            texture = spriteSheet;
            current_frame = 0;
            elapsedTime = 0;

            width = texture[0][0].Width;
            height = spriteSheet[0][0].Height;

            animation_manager = new AnimationBees(0,new TimeTracker(false), spriteSheet);
            

            movement_manager = new WeaponMove(pos.Item1, pos.Item2);
            this.rocketType = rocketType;
            detected = false;
            rocketPlaced = false;
            completed = false;
            
         
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
            animation_manager.Animate();
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
            Rectangle SOURCE_REC = new Rectangle(1, y: 1, BEE_WIDTH, BEE_HEIGHT);
            Rectangle DEST_REC = new Rectangle(movement_manager.getPosition().Item1, movement_manager.getPosition().Item2, BEE_WIDTH, BEE_HEIGHT);
            rec = DEST_REC;
            spriteBatch.Draw(animation_manager.sprite_frame, DEST_REC, SOURCE_REC, Color.White);
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
        private void filterMovementX()
        {
            //this can be fixed later
            int weaponX = movement_manager.getPosition().Item1 - (Random.RandomBeeSPD());
            movement_manager.setPosition(weaponX, movement_manager.getPosition().Item2);
        }

        private void filterMovementY(ORB_DIRECTION type)
        {

            int weaponX = movement_manager.getPosition().Item2;
            int weaponY = movement_manager.getPosition().Item2;
            switch (type)
            {
                case ORB_DIRECTION.TOP:

                    weaponY += -(Random.RandomBeeSPD()) * offset;
                   
                    break;
                case ORB_DIRECTION.MIDDLE:
                    weaponY += -(Random.RandomBeeSPD()) * offset;
                   
                    break;
                case ORB_DIRECTION.BOTTOM:
                    weaponY += (Random.RandomBeeSPD()) * offset;
                   
                    break;
            }

            movement_manager.setPosition(movement_manager.getPosition().Item1, weaponY);
        }

        public void setTarget(IEntity entity)
        {
            if(entity != null)
            {
                detected = true;
                target = entity;
            }
            else{
                removeTarget();
            } 
        }

        private void removeTarget()
        {
            detected = false;
            target = null;
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

        private void filterMoveAll(ORB_DIRECTION type)
        {
            if (!detected)
            {
                filterMovementX();
                filterMovementY(type);
            }
           
        }
        private void Move()
        {
        
            CheckIfTargetDetected();
            filterMoveAll(rocketType);
            checkFinish();
        }
        private void CheckIfTargetDetected()
        {
            if (detected)
            {
                Vector2 targetPosition = new Vector2(target.getPos().Item1, target.getPos().Item2);
                
                SeekEntity.Move(targetPosition, movement_manager);
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
            if (elapsedTime >= 5000)
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
             
            }
        }

        public Rectangle getDetectionFieldRectangle()
        {

            return new Rectangle(GetCenteredBoundingBoxX(), GetCenteredBoundingBoxY(), BEES_DETECTION_FEILD_WIDTH, BEES_DETECTION_FEILD_HEIGHT);
        }

        private int GetCenteredBoundingBoxY()
        {
            
            int spriteY = movement_manager.getPosition().Item2;
            return spriteY - ((BEES_DETECTION_FEILD_HEIGHT / CENTER_RATIO) - BEE_HEIGHT / CENTER_RATIO);

        }
        private int GetCenteredBoundingBoxX()
        {
            int spriteX = movement_manager.getPosition().Item1;

            return spriteX - ((BEES_DETECTION_FEILD_WIDTH / CENTER_RATIO) - BEE_WIDTH / CENTER_RATIO);
        }



        public void GetUserPos(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void GetUserState(Constants.Direction direct)
        {
            throw new NotImplementedException();
        }

        public void MovementChange(bool detected)
        {
            
        }
    }
}
