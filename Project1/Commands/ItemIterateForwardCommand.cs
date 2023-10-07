using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class ItemIterateForwardCommand : ICommand
    {
        public void Execute()
        {
            Game1.Item = ItemIterator.getCurrEnemy(false);
        }
    }
}
