using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;
using static Project1.Constants;
namespace Project1
{
    public class PlayerMove : IPlayerMovement
    {
        private IAnimationPlayer animationManager;
        private IPlayerStateTest stateManager;
        private int x;
        private int y;


        public PlayerMove(IAnimationPlayer animationManager, IPlayerStateTest stateManager, (int,int) pos) {
            x = pos.Item1;
            y = pos.Item2;
        
        } 


        public void Move(Direction direction)
        {
           switch(direction)
            {
                case Direction.Up:
                    MoveUp();
                    break;

                case Direction.Right:
                    MoveRight();
                    break;
                case Direction.Left:
                    MoveLeft();
                    break;
                case Direction.Down:
                    MoveDown();
                    break;
            }
            
        }

        private void MoveUp()
        {
            y -= 1;

        }
        private void MoveRight()
        {
            x += 1;
        }
        private void MoveDown()
        {
            y += 1;
        }
        private void MoveLeft()
        {
            x -= 1;
        }
       

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


    }
}
