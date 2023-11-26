using System;
using static Project1.Constants;

namespace Project1
{

	public static class PlayerAttack
	{
        // attacking metrics
        private static float AttackTimer;

        // weapons
        private static bool isAttackingWithSword = false;
        private static bool isAttackingWithBoomerang = false;
        private static bool isAttackingWithBow = false;
        private static bool isAttackingWithBomb = false;

        public static IWeapon spriteWeapon;

        //Command Functions
        public static void attackSword()
        {
            if (Player.itemInventory[(int)ITEMS.Sword] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithSword = true;
                spriteWeapon = new Sword();
                Game1.GameObjManager.addNewPlayerWeapon(spriteWeapon);
            }
        }

        public static void attackBoom()
        {
            if (Player.itemInventory[(int)ITEMS.Boomerang] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBoomerang = true;
                IWeapon boom = new BoomerangePlayer();
                Game1.GameObjManager.addNewPlayerWeapon(boom);
            }
        }

        public static void attackBow()
        {
            if (Player.itemInventory[(int)ITEMS.Bow] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBow = true;
                IWeapon arrow = new Arrow2();
                Game1.GameObjManager.addNewPlayerWeapon(arrow);
            }
        }

        public static void attackBomb()
        {
            if (Player.itemInventory[(int)ITEMS.Bomb] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBomb = true;
                IWeapon bomb = new Bomb();
                Game1.GameObjManager.addNewPlayerWeapon(bomb);
                Inventory.UseItem(ITEMS.Bomb);
            }
        }

        // if 1 second has passed since attacking, revert attack keystate to false (allowing for other actions)
        public static void WaitForAttack()
        {
            if (AttackTimer <= 0)
            {

                Player.isAttacking = false;
                AttackTimer = Constants.ATTACK_SECONDS;

                isAttackingWithBoomerang = false;
                isAttackingWithBow = false;
                isAttackingWithSword = false;


            }
        }

        public static float getAttackTimer()
        {
            return AttackTimer;
        }

        public static void setAttackTimer(float newVal)
        {
            AttackTimer = newVal;
        }

        /*
        public static bool getIsAttackingWithSword()
        {
            return isAttackingWithSword;
        }
        */

        public static void setIsAttackingWithSword(bool newVal)
        {
            isAttackingWithSword = newVal;
        }

        /*
        public static bool getIsAttackingWithBoomerang()
        {
            return isAttackingWithBoomerang;
        }
        */

        public static void setIsAttackingWithBoomerang(bool newVal)
        {
            isAttackingWithBoomerang = newVal;
        }

        /*
        public static bool getIsAttackingWithBomb()
        {
            return isAttackingWithBomb;
        }
        */

        public static void setIsAttackingWithBomb(bool newVal)
        {
            isAttackingWithBomb = newVal;
        }

        /*
        public static bool getIsAttackingWithBow()
        {
            return isAttackingWithBow;
        }
        */

        public static void setIsAttackingWithBow(bool newVal)
        {
            isAttackingWithBow = newVal;
        }
    }
}

