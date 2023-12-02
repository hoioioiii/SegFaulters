using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1.Health
{
    public class HealthSystemManager
    {
        public int fragments;
        public List<Heart> heartList;
        public Heart individualHeart;
        public HealthSystemManager(int heartsAmount)
        {
            heartList = new List<Heart>();

            //create heartAmount of hearts
            for (int i = 0; i < heartsAmount; i++)
            {
                Heart individualHeart = new Heart(DEFAULT_FULL_HEART); //start all hearts as full
                heartList.Add(individualHeart);
            }
        }

        public List<Heart> GetHealthSystem()
        {
            return heartList;
        }

        //attack = 2: takes half a heart
        //attack = 4: takes an entire heart
        public void DamageHealth(int damageAmount)
        {
            for (int i = heartList.Count - 1; i >= 0; i--)
            {
                if (damageAmount <= 0)
                { //no damage need to be done
                    break;
                }
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

        //healAmount = 2: heal half a heart
        //healAmount = 4: heal entire heart
        public void HealHealth(int healAmount)
        {
            for (int i = 0; i < heartList.Count; i++)
            {

                Heart currHeart = heartList[i];
                int missFragments = MAX_FRAGMENTS - currHeart.GetFragmentAmount();

                if (healAmount >= missFragments)
                {
                    healAmount -= missFragments;
                    currHeart.HealHealth(missFragments);
                }
                else
                {
                    currHeart.HealHealth(healAmount);
                    healAmount = 0;
                    break;
                }
            }


            while (healAmount > 0)
            {
                if (healAmount >= MAX_FRAGMENTS)
                {
                    Heart newHeart = new Heart(MAX_FRAGMENTS);
                    heartList.Add(newHeart);
                    healAmount -= MAX_FRAGMENTS;
                }
                else
                {
                    Heart newHeart = new Heart(healAmount);
                    heartList.Add(newHeart);
                    healAmount = 0; // Reset healAmount, as all healing has been applied
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

            public void HealHealth(int healAmount)
            {
                if (fragments + healAmount > MAX_FRAGMENTS)
                {
                    fragments = MAX_FRAGMENTS;
                }
                else
                {
                    fragments += healAmount;
                }
            }
        }

    }
}
