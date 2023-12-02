using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using static Project1.Constants;

namespace Project1
{
    public class TriforceWinningScreen
    {
        private SpriteFont font;

        public TriforceWinningScreen(GraphicsDevice graphics, ContentManager content)
        {
            font = content.Load<SpriteFont>(ZELDAFONT);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (Game1.timer <= 0)
            {
                Game1.selectionManager.DrawHeartSelector(spritebatch);
                spritebatch.DrawString(font, RETRY, RETRY_POSITION, Color.White);
                spritebatch.DrawString(font, QUIT, QUIT_POSITION, Color.White);
            } else
            {
                spritebatch.DrawString(font, WINNER, CENTER, Color.White);
            }
            
        }
        public static void TriForceSoundEffect() {
            MediaPlayer.Pause();
            AudioManager.PlaySoundEffect(winningStateSound);
        }
        
        public void Update()
        {
            Game1.timer--;
        }
    }
}
