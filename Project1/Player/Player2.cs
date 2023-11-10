using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project1.Enemies;
using static Project1.Constants;
using Project1.Enemies;
namespace Project1
{
    public class Player2 : IPlayer
    {
        private IPlayerSprite sprite;

        private IAnimationPlayer animationManager;
        private ITime timeManager;
        private IDirectionStateManager directionStateManager;
        private IPlayerStateTest stateManager;
        private IPlayerMovement moveManager;
        public Player2() {

            //Get state manager

            stateManager = new PlayerStateController();
            //Get direction manager
            directionStateManager = new DirectionState(Direction.Up);
            //get animation manager
            animationManager = new PlayerAnimation(0, timeManager, directionStateManager,stateManager);
            //Get movement manager
            //moveManager = new PlayerMove(animationManager,stateManager,();
            //get inventory manager


            sprite = PlayerSpriteFactory.Instance.CreateLinkSpriteTest(animationManager);


        }

        public void Update()
        {
            animationManager.Animate();
        }

        //weapons
        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            // sprite.Draw(Game1._spriteBatch, "still", direction, location);
            sprite.Draw();
        }

        public void PickUpItem(ITEMS itemToAdd)
        {


        }

        public bool UseItem(ITEMS itemToDelete)
        {

            return false;
        }

        public void Move(Direction direction) {

            moveManager.Move(direction);
        }


        //bounding boxes
        public Rectangle BoundingBox()
        {
            throw new NotImplementedException();
        }

        

        public Constants.DIRECTION GetDirection()
        {
            throw new NotImplementedException();
        }

        public bool GetPlayerAttackingState()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetPosition()
        {
            throw new NotImplementedException();
        }

        public void SetPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

       
    }
}
