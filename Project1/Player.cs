using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public class Player
    {
        private Texture2D playerTexture;
        public Vector2 CharacterPosition { get; internal set; }
        public Pistol pistol;

        public Player()
        {
            // Load the player texture in the constructor or LoadContent, not both
            // playerTexture = Game1.contentLoader.Load<Texture2D>("topdownpistol");
            pistol = new Pistol(this);
        }

        public void LoadContent()
        {
            playerTexture = Game1.contentLoader.Load<Texture2D>("topdownpistol");
        }

        public void Update(GameTime gameTime)
        {
            // Add your update logic here
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, CharacterPosition, Color.White);
        }

        public void FireAction()
        { }
    }
}