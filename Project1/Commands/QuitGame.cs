using System;
namespace Project1
{
    public class QuitGame : ICommand
    {
        public void Execute()
        {
           Game1.self.Exit();
        }
    }
}

