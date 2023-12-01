using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project1.SmartAI;
using static Project1.Constants;
namespace Project1
{
    public interface IMove
    {
        
        public void WanderMove();
        public void circularMovement(Direction start_direction);
        public void setPosition(int x, int y);
        public (int, int) getPosition();

        public void HorizontalMovement(Direction start_direction);

        public void LeftAndRight();
        public Vector2 getVector();
        public void SmartAIDetectionFieldMovement();
    }
}
