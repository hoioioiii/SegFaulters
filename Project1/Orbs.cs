using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class Orbs : IWeaponProjectile
    {
        private Texture2D[] texture;
        public bool activeAttack { get; private set; }

        private Vector2[] orbPositions;
        private Vector2 userPosition;

        private int currFrame;
        private int totalFrame;

        public int Width { get; private set; }
        public int Height { get; private set; }
        private const int OrbSpeed = 2;


        public Orbs(Texture2D[] spritesheet, Vector2 userPosition)
        {
            activeAttack = false;
            texture = spritesheet;
            currFrame = 0;
            totalFrame = 3;
            orbPositions = new Vector2[3];
            this.userPosition = userPosition;
            Width = texture[currFrame].Width;
            Height = texture[currFrame].Height;
        }

        public void Attack()
        {
            this.activeAttack = true;
            SetOrbPositions();
        }

        private void SetOrbPositions()
        {
            orbPositions[0] = userPosition + new Vector2(0, -5); // Up
            orbPositions[1] = userPosition + new Vector2(0, 5);  // Down
            orbPositions[2] = userPosition - new Vector2(5, 0);  // Left
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, int direction, int userScale)
        {
            Rectangle SOURCE_REC = new Rectangle(1, 1, Width, Height);
            foreach (Vector2 orbPosition in orbPositions)
            {
                Rectangle destRect = new Rectangle((int)orbPosition.X, (int)orbPosition.Y, Width * 4, Height * 4);
                spriteBatch.Draw(texture[currFrame], destRect, SOURCE_REC, Color.White);
            }
        }

        public void Update()
        {
            if (activeAttack)
            {
                for (int i = 0; i < orbPositions.Length; i++)
                {
                    orbPositions[i] += GetDirectionVector(i) * OrbSpeed;

                    if (!IsInBounds(orbPositions[i]))
                    {
                        activeAttack = false;
                        break;
                    }
                }
            }
        }

        private bool IsInBounds(Vector2 position)
        {
            return position.X >= 0 && position.X <= SCREEN_WIDTH_UPPER &&
                   position.Y >= 0 && position.Y <= SCREEN_HEIGHT_UPPER;
        }

        private Vector2 GetDirectionVector(int directionIndex)
        {
            switch (directionIndex)
            {
                case 0: // Up
                    return new Vector2(0, -1);
                case 1: // Down
                    return new Vector2(0, 1);
                case 2: // Left
                    return new Vector2(-1, 0);
                default:
                    return Vector2.Zero;
            }
        }

        public void Load()
        {
            // Implement if needed
        }

        public void DetermineWeaponState()
        {
            // Implement if needed
        }

        public void GetUserState()
        {
            // Implement if needed
        }

        public void Physics()
        {
            // Implement if needed
        }

        public void GetUserPos()
        {
            // Implement if needed
        }
    }
}