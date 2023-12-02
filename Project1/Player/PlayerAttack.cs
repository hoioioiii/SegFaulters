using System;
using System.Reflection.Metadata.Ecma335;
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
        private static bool isAttackingWithBeehive = false;
        private static int weaponAttackAmount = 0;

        public static IWeapon spriteWeapon;

        //Command Functions
        public static void attackSword()
        {
            if (Inventory.itemInventory[(int)ITEMS.Sword] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithSword = true;
                weaponAttackAmount = (int)WEAPON_ATTACK_AMOUNT.swordAmount;
                spriteWeapon = new Sword();
                Game1.GameObjManager.addNewPlayerWeapon(spriteWeapon);
            }
        }

        public static void attackBoom()
        {
            if (Inventory.itemInventory[(int)ITEMS.Boomerang] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBoomerang = true;
                weaponAttackAmount = (int)WEAPON_ATTACK_AMOUNT.boomerangAmount;
                IWeapon boom = new BoomerangePlayer();
                Game1.GameObjManager.addNewPlayerWeapon(boom);
            }
        }

        public static void attackBow()
        {
            if (Inventory.itemInventory[(int)ITEMS.Bow] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBow = true;
                weaponAttackAmount = (int)WEAPON_ATTACK_AMOUNT.bowAmount;
                IWeapon arrow = new Arrow2();
                Game1.GameObjManager.addNewPlayerWeapon(arrow);
            }
        }

        public static void attackBomb()
        {
            if (Inventory.itemInventory[(int)ITEMS.Bomb] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBomb = true;
                weaponAttackAmount = (int)WEAPON_ATTACK_AMOUNT.bombAmount;
                IWeapon bomb = new Bomb();
                Game1.GameObjManager.addNewPlayerWeapon(bomb);
                Inventory.UseItem(ITEMS.Bomb);
            }
        }

        public static void attackBeehive()
        {
            if (Inventory.itemInventory[(int)ITEMS.Beehive] != 0)
            {
                Player.isAttacking = true;
                isAttackingWithBeehive = true;
                weaponAttackAmount = (int)WEAPON_ATTACK_AMOUNT.beehiveAmount;
                //spriteWeapon = new Beehive();
                //Game1.GameObjManager.addNewPlayerWeapon(spriteWeapon);
            }
        }

        public static int getWeaponStats()
        {
            return weaponAttackAmount;
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

