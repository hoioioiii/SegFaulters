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
        public IDirectionStateManager direction_state_manager;
        public IAnimation animation_manager;
        public ITime time_manager;
        public IMove movement_manager;
        public IEntityState state_manager;

        //CHANGE TO INTERFACE LATER
        private IHealthSystem entityHealthSystem;

        public (string, int)[] drops;

        private (Rectangle, Rectangle) rectangles;
        public int attackStat { get; private set; }
     



        //the initial spawning position of the enemy, not yet put into pixel coordinates
        private (int, int) initalPosition; 
        public UniversalClassEntity((int, int) position, (string, int)[] items)
        {
            this.initalPosition = position;

            //replace starting direction based on lvl loader info
            direction_state_manager = new DirectionState(Direction.Up);
            time_manager = new TimeTracker(false);
            animation_manager = new Animation(0, time_manager, direction_state_manager);
            state_manager = new EntityState();
            movement_manager = new Movement(direction_state_manager, this, time_manager, position.Item1, position.Item2, 0);
            attackStat = 1;

            //set up entities health system
            entityHealthSystem = new HealthSystem(ENTITY_HEARTS); //start entity with 5 hearts

            //enemy drops
            drops = items;
        }

    

        public void Update()
        {
            //testDeath();

            //check entity life status
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
            //Check if enemy is currently attacking:

            //No:
            //We need to check the attack timer to see if we need to attack now
            //Set isAttack to true
            //set isMoving to false

            //this is going to be for collision damage attack i think
        }
        public void UpdateFrames()
        {
            if (state_manager.IsAlive())
            {
                //sprite.animationManager
                animation_manager.Animate();
            }
           
        }

        
        public void Move()
        {
            if (state_manager.isMoving())
            {
                //Movement.WanderMove(direction_state_manager, this, time_manager);
                MovementType();
                //This is just for testing purposes: 
                
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


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
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
                ItemLoader.LoadAndInitializeItems(item.Item1, (x, y), Game1.GameObjManager);
            }

        }


        public virtual void ChangeDirections()
        {
            direction_state_manager.getRandomDirection();
        }

        public void TakeDamage(int damageAmount)
        {
            //Play a sound
            AudioManager.PlaySoundEffect(enemyHit);
            //Have it flash


            //Reduce the health in health manager 
            entityHealthSystem.DamageHealth(damageAmount);

        }

    }
}
