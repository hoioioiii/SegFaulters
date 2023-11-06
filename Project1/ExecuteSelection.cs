using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
namespace Project1
{
    public class ExecuteSelection : ICommand
    {
        public void Execute()
        {
            Game1.selectionManager.SelectOption();
            switch (Game1.selectionManager.selected)
            {
                case OPTION.RETRY:
                    new ResetLink().Execute();
                    break;

                case OPTION.QUIT:
                    new QuitGame().Execute();
                    break;
            }


        }
    }
}
