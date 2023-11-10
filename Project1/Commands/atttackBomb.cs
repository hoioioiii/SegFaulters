using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Commands
{
    public class atttackBomb : ICommand
    {
        public void Execute()
        {
            Player.attackBomb(); ;
        }
    }
}
