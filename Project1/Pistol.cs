using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1
{
    public class Pistol : Weapon
    {
        public Texture2D pistolBulletSprite;
        public SpriteBatch _spriteBatch;
        Vector2 bulletInitialPosition;

        private Vector2 bulletInitialPositionOffset;
        private List<Vector2> bullets;

        public Pistol(Game1 game1, Texture2D player, Vector2 playerPosition)
        {
            bullets = new List<Vector2>();
            maxAmmo = 10;
            currentAmmo = maxAmmo;
            reloadTime = 5f;
            bulletInitialPositionOffset = new Vector2(40, -10);

            pistolBulletSprite = game1.Content.Load<Texture2D>("ammotest");

            weaponSprite = pistolBulletSprite;

            bulletInitialPosition = new Vector2(playerPosition.X + (player.Width / 2), playerPosition.Y + (player.Height / 2)); ; // Set the initial position
            _spriteBatch = game1._spriteBatch;
        }

        protected void Projectiles()
        {

        }

        public void WeaponFire(Vector2 playerPosition, Texture2D player)
        {
            if (currentAmmo <= 0)
            {
                WeaponReload();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                // Calculate the initial position of the bullet based on character's position and offset
                Vector2 bulletInitialPosition = new Vector2(playerPosition.X + (player.Width / 2), playerPosition.Y + (player.Height / 2));

                // Add the bullet's initial position to the list
                bullets.Add(bulletInitialPosition);

                // Reduce ammo count
                currentAmmo--;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            foreach (Vector2 bulletPosition in bullets)
            {
                _spriteBatch.Draw(pistolBulletSprite, bulletPosition, Color.White);
            }



        }

        public override void Update()
        {

            //bulletInitialPosition.X += 10;
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i] = new Vector2(bullets[i].X + 10, bullets[i].Y);

                // Remove bullets that are out of bounds or off-screen (adjust as needed)
                if (bullets[i].X >500)
                {
                    bullets.RemoveAt(i);
                    i--; // Decrement to avoid skipping the next bullet
                }
            }

        }
    }
}
