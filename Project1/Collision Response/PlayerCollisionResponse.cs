using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Collision;
using Project1.HUD;
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
            AudioManager.PlaySoundEffect(smallItemGet);
            Player.PickUpItem(IItemtoITEMS(item));
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
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case Fairy:
                    ITEMS = ITEMS.Fairy;
                    AudioManager.PlaySoundEffect(smallItemGet);
                    break;
                case HeartContainer:
                    ITEMS = ITEMS.HeartContainer;
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

                bool didItemGetUsed = Player.UseItem(ITEMS.Key); //use key
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

            RoomManager.SetActiveRoom(door.destinationRoom, door.direction);
        }

        /*
         * For boundary collision, can't move past/through
         */
        public static void BoundaryResponse(DIRECTION direction)
        {          
            Vector2 playerPosition = Player.getPosition();
            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, Player.playerSpeed);
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

            HealthDisplay.linkHealth.DamageHealth(DAMAGE_HALF_HEART);           
        }
    }
}
