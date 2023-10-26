using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace Project1.Audio
{
    internal class AudioManager
    {
        //BackGround Music
        private Song BGM;

        // Sound Effects
        private SoundEffect addUI, boomerang, cling, death, zeldaSound, dragon, dragon2, dragon3, enemyDie, fire, flame;

        void LoadContent(ContentManager content)
        {
            BGM = content.Load<Song>("04 Underworld BGM");

            addUI = content.Load<SoundEffect>("add ui");

            zeldaSound = content.Load<SoundEffect>("do do do do do DO do do");
            //  Uncomment the following line will also loop the song
            //  MediaPlayer.IsRepeating = true;
            //MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        void PlayMusic()
        {
            MediaPlayer.Play(BGM);
        }

        void PlaySoundEffect(SoundEffect SFX)
        {
            SFX.Play();
        }

        void StopAllAudio()
        {

        }
    }
}
