using System;
namespace Project1
{
    public class LinkDeath : ICommand
    {
        public void Execute()
        {
            Player.dead();
        }
    }

}