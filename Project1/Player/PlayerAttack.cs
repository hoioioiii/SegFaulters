using System;
using static Project1.Constants;

namespace Project1
{

	public static class PlayerAttack
	{
        // attacking metrics
        public static float AttackTimer;

        // weapons
        public static bool isAttackingWithSword = false;
        public static bool isAttackingWithBoomerang = false;
        public static bool isAttackingWithBow = false;
        public static bool isAttackingWithBomb = false;

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
    }
}

