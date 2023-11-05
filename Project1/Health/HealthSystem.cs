using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Health
{
    public class HealthSystem
    {
        public int fragments;
        public List<Heart> heartList;
        public HealthSystem(int healthAmount) 
        { 
            heartList = new List<Heart>();

            for (int  i = 0; i < 3; i++) 
            {
                Heart individualHeart = new Heart(3);
                heartList.Add(individualHeart);
            }

            heartList[heartList.Count - 1].SetHeartFragment(1);
        }

        public List<Heart> getHealthSystem()
        {
            return heartList;
        }

    }
}
