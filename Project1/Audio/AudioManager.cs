using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using static Project1.AudioConstants;

namespace Project1.Audio
{
    public class AudioManager
    {
        //BackGround Music
        //private static Song BGM;

        // Sound Effects
        //private static SoundEffect addUI, boomerang, cling, death, zeldaSound, dragon, dragon2, dragon3, enemyDie, fire, flame;


        public static void LoadContent(ContentManager content)
        {
            BGM = content.Load<Song>("Audio\\04 Underworld BGM");

            addUI = content.Load<SoundEffect>("Audio\\add ui");

            zeldaSound = content.Load<SoundEffect>("Audio\\zelda sound");
            //  Uncomment the following line will also loop the song
            //  MediaPlayer.IsRepeating = true;
            //MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        public static void PlayMusic(Song music)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(music);
        }
        public static void StopAllAudio()
        {
            MediaPlayer.Stop();
        }

        public static void ResumeMusic() 
        {         
            MediaPlayer.Resume();
        }

        public static void PlaySoundEffect(SoundEffect SFX)
        {
            SFX.Play();
        }      
    }
}
