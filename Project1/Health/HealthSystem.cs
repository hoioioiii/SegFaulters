using System;
using System.Collections.Generic;
using System.Data;
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
        const int MAX_FRAGMENTS = 2;
        public HealthSystem(int heartsAmount) 
        { 
            heartList = new List<Heart>();

            //create heartAmount of hearts
            for (int  i = 0; i < heartsAmount; i++) 
            {
                Heart individualHeart = new Heart(1); //start them as full
                heartList.Add(individualHeart);
            }

/*            DamageHealth(1);
*//*            heartList[heartList.Count - 2].SetHeartFragment(1); //testing purposes
*/        }

        public List<Heart> GetHealthSystem()
        {
            return heartList;
        }

        //damage of 2 empties a heart. UP TO CHANGE
        public void DamageHealth(int damageAmount)
        {
            for (int i = heartList.Count - 1; i >= 0; i--)
            {
                if (damageAmount <= 0)
                {
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

            //update current hearts
/*            HealthSystemSprite.heartsList.Update();
*/        }

        public void HealHealth(int healAmount)
        {
            for (int i  = 0; i < heartList.Count; i++)
            {
                Heart currHeart = heartList[i];
                int missFragments = MAX_FRAGMENTS - currHeart.GetFragmentAmount();


                if (healAmount <= 0)
                {
                    break;
                }
                //heart gets partially heal
                if (healAmount > missFragments)
                {
                    healAmount -= missFragments;
                    currHeart.HealHealth(missFragments);
                }
                else //heart gets fully heal
                {
                    currHeart.HealHealth(healAmount);
                    break;
                }

            }
            //new heart must be added
            if (healAmount > 0)
            {

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
