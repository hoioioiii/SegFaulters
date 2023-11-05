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
        public Heart individualHeart;
        public HealthSystem(int heartsAmount) 
        { 
            heartList = new List<Heart>();

            //create heartAmount of hearts
            for (int  i = 0; i < heartsAmount; i++) 
            {
                Heart individualHeart = new Heart(2); //start them as full
                heartList.Add(individualHeart);
            }

            heartList[heartList.Count - 1].SetHeartFragment(1); //testing purposes
        }

        public List<Heart> GetHealthSystem()
        {
            return heartList;
        }

        //damage of 2 empties a heart. UP TO CHANGE
        public void DamageHealth(int damageAmount)
        {
            for (int i = heartList.Count - 1; i >= 0; i--)
            {
                Heart heart = heartList[i];

                //heart can only handle partial damage
                if (damageAmount > heart.GetFragmentAmount())
                {
                    damageAmount -= heart.GetFragmentAmount();
                    heart.DamageHealth(heart.GetFragmentAmount());
                }
                else //heart can handle all damage
                {
                    heart.DamageHealth(damageAmount);
                    break;
                }
            }
        }

        public class Heart
        {
            public int fragments;
            public Heart(int fragments)
            {
                SetHeartFragment(fragments);
            }

            public void SetHeartFragment(int fragments)
            {
                this.fragments = fragments;
            }

            public int GetFragmentAmount()
            { return fragments; }

            public void DamageHealth(int damageAmount)
            {
                if (damageAmount >= fragments)
                {
                    fragments = 0;
                } 
                else
                {
                    fragments -= damageAmount;
                }
            }
        }

    }
}
