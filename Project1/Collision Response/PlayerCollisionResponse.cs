using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Collision;
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
            item.drawState = false;
        }

        /*
         * Pass in door
         * Send to level loader which door it was
         */
        public static void DoorResponse(Door door)
        {
            if (door.isDoorLocked())//if locked
            {
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

            #region Print to debug console
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("door direction: " + door.direction);

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion

            RoomManager.SetActiveRoom(door.destinationRoom);


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

            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, Player.playerSpeed);
            Player.setPosition(playerPosition);
        }

        /*
         * Enemy collision, significant knockback & damage & temporary invincibility
         */
        public static void DamageResponse(DIRECTION direction)
        {
            Vector2 playerPosition = Player.getPosition();
            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, KNOCKBACK_DISTANCE);
            AllCollisionResponse.ApplyDamage();
            Player.setPosition(playerPosition);
        }       
    }
}
