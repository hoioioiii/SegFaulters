using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    public class Door : IEnvironment
    {
        public DIRECTION direction { get; private set; }
        public int destinationRoom { get; private set; }
        private bool isLocked;
        private bool isTunnel;
        private Texture2D texture;
        private Texture2D[] textures;
        private int xPos;
        private int yPos;
        private int width;
        private int height;

        private bool invisible;

        public Rectangle BoundingBox { get; private set; }
        public Door(Texture2D[] textures, DIRECTION direction, int destinationRoom, bool isLocked, bool isTunnel)
        {

            this.textures = textures;
            this.destinationRoom = destinationRoom;
            this.isLocked = isLocked;
            this.isTunnel = isTunnel;
            this.direction = direction;

            setProperties();

            
        }
        
        private void setProperties()
        {
            switch (direction)
            {
                //set respective scaling, and texture for the door depending on the direction, and if its locked or not.
                case DIRECTION.up:
                    width = HORIZONTAL_DOOR_WIDTH; height = HORIZONTAL_DOOR_HEIGHT;
                    if (isTunnel)
                    {
                        if (isLocked)
                            invisible = true;
                        else
                        {
                            invisible = false;
                            texture = textures[(int)DOORTEXTURES.TUNNELDOORNORTH];
                        }
                    }
                    else if (isLocked)
                        texture = textures[(int)DOORTEXTURES.LOCKDOORNORTH];
                    else
                        texture = textures[(int)DOORTEXTURES.DOORNORTH];
                    xPos = DOOR_NORTH_X + FRAME_BUFFER_X;
                    yPos = DOOR_NORTH_Y + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.up;
                    break;
                case DIRECTION.down:
                    width = HORIZONTAL_DOOR_WIDTH; height = HORIZONTAL_DOOR_HEIGHT;
                    if (isTunnel)
                    {
                        if (isLocked)
                            invisible = true;
                        else
                        {
                            invisible = false;
                            texture = textures[(int)DOORTEXTURES.TUNNELDOORNORTH];
                        }
                    }
                    else if (isLocked)
                        texture = textures[(int)DOORTEXTURES.LOCKDOORSOUTH];
                    else
                        texture = textures[(int)DOORTEXTURES.DOORSOUTH];
                    xPos = DOOR_SOUTH_X + FRAME_BUFFER_X;
                    yPos = DOOR_SOUTH_Y + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.down;
                    break;
                case DIRECTION.left:
                    width = VERTICAL_DOOR_WIDTH; height = VERTICAL_DOOR_HEIGHT;
                    if (isLocked)
                        texture = textures[(int)DOORTEXTURES.LOCKDOORWEST];
                    else
                        texture = textures[(int)DOORTEXTURES.DOORWEST];
                    xPos = DOOR_WEST_X + FRAME_BUFFER_X;
                    yPos = DOOR_WEST_Y + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.left;
                    break;
                case DIRECTION.right:
                    width = VERTICAL_EAST_WIDTH; height = VERTICAL_EAST_HEIGHT;
                    if (isLocked)
                        texture = textures[(int)DOORTEXTURES.LOCKDOOREAST];
                    else
                        texture = textures[(int)DOORTEXTURES.DOOREAST];
                    xPos = DOOR_EAST_X + FRAME_BUFFER_X;
                    yPos = DOOR_EAST_Y + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.right;
                    break;
                default:
                    break;
            }
        }

        public void Update() {
                //door does not get updated, only block does.
        }

        public void Draw(SpriteBatch spriteBatch) {
            BoundingBox = new Rectangle(xPos, yPos, width, height);
            if (!invisible)
            spriteBatch.Draw(texture, new Rectangle(xPos, yPos, width, height), Color.White);

        }

        public bool isDoorLocked()
        {
            return isLocked;
        }

        public bool isTunnelDoor()
        {
            return isTunnel;
        }

        public void UnlockDoor()
        {
            LevelLoader.UnlockDoorFromRoom(RoomManager.GetActiveRoomNumber(), direction);
            DIRECTION directionInverse = GetInverseDirection(direction);
            LevelLoader.UnlockDoorFromRoom(destinationRoom, directionInverse);
            
                
            isLocked = false;
            setProperties();
        }

        private DIRECTION GetInverseDirection(DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.up:
                    return DIRECTION.down;
                case DIRECTION.down:
                    return DIRECTION.up;
                case DIRECTION.left:
                    return DIRECTION.right;
                case DIRECTION.right:
                    return DIRECTION.left;
                default: return DIRECTION.down;
                
            }
        }
    }
}
