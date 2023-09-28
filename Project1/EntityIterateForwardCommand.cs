using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class EntityIterateForwardCommand : ICommand
    {
        public void Execute()
        {
            Game1.ENEMY = EnemyIterator.getCurrEnemy(false);
        }
    }
}
