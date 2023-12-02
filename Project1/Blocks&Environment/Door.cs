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

            System.Diagnostics.Debug.WriteLine("Door instantiated; direction: " + direction);
        }
        
        private void setProperties()
        {
            switch (direction)//following magic numbers are true magic numbers 
            {
                //set respective scaling, and texture for the door depending on the direction, and if its locked or not.
                case DIRECTION.up:
                    width = 100; height = 60;
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
                    xPos = 350 + FRAME_BUFFER_X;
                    yPos = 14 + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.up;
                    break;
                case DIRECTION.down:
                    width = 100; height = 60;
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
                    xPos = 352 + FRAME_BUFFER_X;
                    yPos = 409 + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.down;
                    break;
                case DIRECTION.left:
                    width = 60; height = 100;
                    if (isLocked)
                        texture = textures[(int)DOORTEXTURES.LOCKDOORWEST];
                    else
                        texture = textures[(int)DOORTEXTURES.DOORWEST];
                    xPos = 53 + FRAME_BUFFER_X;
                    yPos = 190 + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.left;
                    break;
                case DIRECTION.right:
                    width = 63; height = 107;
                    if (isLocked)
                        texture = textures[(int)DOORTEXTURES.LOCKDOOREAST];
                    else
                        texture = textures[(int)DOORTEXTURES.DOOREAST];
                    xPos = 688 + FRAME_BUFFER_X;
                    yPos = 190 + FRAME_BUFFER_Y;
                    this.direction = DIRECTION.right;
                    break;
                default:
                    break;
            }
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch) {
            BoundingBox = new Rectangle(xPos, yPos, width, height);
            //System.Diagnostics.Debug.WriteLine("Direction: " + this.direction + " Width: " + (int)(texture.Width * ratio) + "  Height: " + (int)(texture.Height * ratio));
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
            LevelLoader.UnlockDoorFromRoom(RoomManager.getActiveRoomNumber(), direction);
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
                    break;
                case DIRECTION.down:
                    return DIRECTION.up;
                    break;
                case DIRECTION.left:
                    return DIRECTION.right;
                    break;
                case DIRECTION.right:
                    return DIRECTION.left;
                    break;
                default: return DIRECTION.down;
                
            }
        }
    }
}
