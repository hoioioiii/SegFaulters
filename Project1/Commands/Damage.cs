using System;
namespace Project1
{
    public class Damage : ICommand
    {
        public void Execute()
        {
            Player.damage();
        }
    }
}
