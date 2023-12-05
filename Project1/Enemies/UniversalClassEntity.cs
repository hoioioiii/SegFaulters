using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
using System.Collections.Generic;
using Project1.Health;

namespace Project1.Enemies
{
    public class UniversalClassEntity :IEntity
    {
        public virtual Rectangle BoundingBox => throw new NotImplementedException();
        public virtual Rectangle DetectionFieldX => throw new NotImplementedException();
        public virtual Rectangle DetectionFieldY => throw new NotImplementedException();


        public IDirectionStateManager direction_state_manager;
        public IAnimation animation_manager;
        public ITime time_manager;
        public IMove movement_manager;
        public IEntityState state_manager;
        private IHealthSystem entityHealthSystem;

        public (string, int)[] drops;
        public int attackStat { get; private set; }
        public virtual (bool,bool) detected { get; set; }
       

        private (int, int) initalPosition; 
        public UniversalClassEntity((int, int) position, (string, int)[] items)
        {
            this.initalPosition = position;
            direction_state_manager = new DirectionState(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, time_manager, direction_state_manager);
            state_manager = new EntityState();
            movement_manager = new Movement(direction_state_manager, this, time_manager, position.Item1, position.Item2, 0);
            attackStat = 1;
            detected = (false,false);
            entityHealthSystem = new HealthSystem(ENTITY_HEARTS); //start entity with 5 hearts
            drops = items;
        }

    

        public void Update()
        {
            if (entityHealthSystem.IsDead())
            {
                state_manager.setIsAlive(false);
                LevelLoader.RemoveEnemy(RoomManager.GetCurrentRoomIndex(), initalPosition);
            }

            if (state_manager.IsAlive())
            {
                Attack();
                Move();

            }
            else if (!state_manager.finished)
            {
               
                ItemDrop();
                FinishEnemies();
            }
            UpdateFrames();
        }

        private void FinishEnemies()
        {

            Game1.GameObjManager.removeEntity(this);
            
        }


        public virtual void Attack()
        {
            //Only needed for enemies with attack feature
        }

        public void UpdateFrames()
        {
            if (state_manager.IsAlive())
            {
                animation_manager.Animate();
            }
           
        }

        public void Move()
        {
            if (state_manager.isMoving())
            {
                MovementType();    
            }

        }

        public virtual void MovementType()
        {
            movement_manager.WanderMove();
        }

      
        public void setPosition(int x, int y)
        {
            movement_manager.setPosition(x, y);
        }

        public (int, int) getPos()
        {
            return movement_manager.getPosition();
        }

        public virtual Rectangle GetPositionAndRectangle() { throw new NotImplementedException(); }

        public void ItemDrop()
        {
            foreach ((string, int) itemtype in drops)
            {
                CreateNumItem(itemtype);
            }
            state_manager.SetFinished();
        }


        public void CreateNumItem((String, int) item)
        {

            for (int i = 0; i < item.Item2; i++)
            {
                int x = movement_manager.getPosition().Item1;
                int y = movement_manager.getPosition().Item2;

                (int,int) pos = CheckItemDropPosition(x,y);
                ItemLoader.LoadAndInitializeItems(item.Item1,pos, Game1.GameObjManager);
            }

        }
        private (int,int) CheckItemDropPosition(int x , int y)
        {
           int newX =  Math.Clamp(x,roomBoundsMinX,roomBoundsMaxX);
           int newY =  Math.Clamp(y, roomBoundsMinY + ITEM_DROP_OFFSET, roomBoundsMaxY);
            return (newX,newY);
        }

        public virtual void ChangeDirections()
        {
            direction_state_manager.GetRandomDirection();
        }

        public void TakeDamage(int damageAmount)
        {
            AudioManager.PlaySoundEffect(enemyHit);
            entityHealthSystem.DamageHealth(damageAmount);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public virtual void SetDetected(bool x, bool y)
        {
            throw new NotImplementedException();
        }
    }
}
