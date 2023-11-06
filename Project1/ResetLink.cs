using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ResetLink : ICommand
    {
        public void Execute()
        {
           PlayerFullReset.ResetEntireGame();
        }
    }
}
