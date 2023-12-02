using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Collision;
using Project1.Enemies;
using Project1.HUD;
using Project1.Stats;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    internal class PlayerCollisionResponse
    {
        /*
         * Pass in item
         * Call item to remove it from the room or
         * call room manager to do it (which one should?)
         * 
         * Place it in Link's inventory or
         * Change a value (like health)
         * The last part will be done by the item entity class
         */
        public static void ItemResponse(IItem item)
        {
            Game1.GameObjManager.removeItem(item);
            LevelLoader.RemoveItem(RoomManager.GetCurrentRoomIndex(), item);
            //item.drawState = false;
            if (item.GetTypeIndex() == ITEMS.Rupee)
            {
                if (Inventory.itemInventory[(int)ITEMS.Rupee] % 2 == 0)
                {
                    PlayerStats.stats["DEF"] += 1;
                }
                AudioManager.PlaySoundEffect(rupeeGet);
            }
            else if (item.GetTypeIndex() == ITEMS.HeartContainer)
            {
                HealthDisplay.linkHealth.HealHealth(4); //give link full heart
                AudioManager.PlaySoundEffect(smallItemGet);
            }
            else if (item.GetTypeIndex() == ITEMS.Clock)
            {
                PlayerMovement.setPlayerSpeed(PlayerMovement.getPlayerSpeed() + 10);
                AudioManager.PlaySoundEffect(smallItemGet);
            }
            else if (item.GetTypeIndex() == ITEMS.Fairy)
            {
                Player.stats[ATTACK] += ATTACK_INCREASE;
                AudioManager.PlaySoundEffect(smallItemGet);
            }
            else
            {
                AudioManager.PlaySoundEffect(smallItemGet);
            }
            Inventory.PickUpItem(item.GetTypeIndex());
        }
        //helper method to get player pickupitem method the needed input type
        public static ITEMS IItemtoITEMS(IItem item)
        {
            ITEMS ITEMS = ITEMS.Bow;
            switch (item)
            {
                case BombItem:
                    ITEMS = ITEMS.Bomb;
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case ArrowItem:
                    ITEMS = ITEMS.Arrow;
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case BoomerangItem:
                    ITEMS = ITEMS.Boomerang;
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case Clock:
                    ITEMS = ITEMS.Clock;
                    PlayerMovement.setPlayerSpeed(PlayerMovement.getPlayerSpeed() + 10);
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case Fairy:
                    ITEMS = ITEMS.Fairy;
                    Player.stats[ATTACK] += ATTACK_INCREASE; //increment attack stat
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case HeartContainer:
                    ITEMS = ITEMS.HeartContainer;
                    HealthDisplay.linkHealth.HealHealth(4); //give link full heart
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case Key:
                    ITEMS = ITEMS.Key;
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case Map:
                    ITEMS = ITEMS.Map;
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case Rupee:
                    ITEMS = ITEMS.Rupee;
                    AudioManager.PlaySoundEffect(rupeeGet);
                    break;
                case Sword:
                    ITEMS = ITEMS.Sword;
                    break;
                case Triforce:
                    ITEMS = ITEMS.Triforce;
                    break;
                    // Where is the case for heart?
                    // AudioManager.PlaySoundEffect(heartGet);

            }
            return ITEMS;
        }
        /*
         * Pass in door
         * Send to level loader which door it was
         */
        public static void DoorResponse(Door door)
        {
            if (door.isDoorLocked())//if locked
            {
                if (door.isTunnelDoor())
                {
                    return;
                }

                bool didItemGetUsed = Inventory.UseItem(ITEMS.Key); //use key
                if (didItemGetUsed) //if player does have key
                {
                    door.UnlockDoor();
                    AudioManager.PlaySoundEffect(doorUnlock);
                }
                return;
            }
            
            switch (door.direction)
                {
                    case DIRECTION.up:
                        Player.setPosition(RESPAWN_UP);
                        break;
                    case DIRECTION.down:
                        Player.setPosition(RESPAWN_DOWN);
                        break;
                    case DIRECTION.left:
                        Player.setPosition(RESPAWN_LEFT);
                        break;
                    case DIRECTION.right:
                        Player.setPosition(RESPAWN_RIGHT);
                        break;
                    default:
                        break;
                }

            #region Print to debug console
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("door direction: " + door.direction);

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion

            RoomManager.SetActiveRoom(door.destinationRoom, door.direction);


        }

        /*
         * For boundary collision, can't move past/through
         */
        public static void BoundaryResponse(DIRECTION direction)
        {
           
            Vector2 playerPosition = Player.getPosition();

            #region Print to debug console
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("COLLISION DIRECTION: " + direction);

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion

            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, PlayerMovement.getPlayerSpeed());
            Player.setPosition(playerPosition);
        }

        /*
         * Enemy collision, significant knockback & damage & temporary invincibility
         */
        public static void DamageResponse(DIRECTION direction, bool weapon,int damageAmount)
        {
            AudioManager.PlaySoundEffect(linkHurt);

            Vector2 playerPosition = Player.getPosition();
            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, KNOCKBACK_DISTANCE);            
            Player.setPosition(playerPosition);

            HealthDisplay.linkHealth.DamageHealth(calculateDamage());

            //IF ROOM 13, SEND BACK TO ROOM 0 UPON GETTING HIT (WALL MASTERS)
            if (RoomManager.GetCurrentRoomIndex() == 13)
            {
                Player.setPosition(RESPAWN_UP);
                RoomManager.SetActiveRoom(0, DIRECTION.none);
            }
            
        }

        public static int calculateDamage()

        {
            int damageTaken = 0;
            if (Player.stats[DEFENSE] >= 1)
            {
                damageTaken = (int)(DAMAGE_HALF_HEART / Player.stats[DEFENSE]);
            }
            if (damageTaken <= 0)
            {
                damageTaken = DAMAGE_HALF_HEART;
            }

            return damageTaken;

        }
    }
}
