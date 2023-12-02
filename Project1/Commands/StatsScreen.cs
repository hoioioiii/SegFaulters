using System;
namespace Project1
{
	public class StatsScreen : ICommand
	{
        public void Execute()
        {
            StatsDisplay.displayStats = !StatsDisplay.displayStats;
        }
    }
}

