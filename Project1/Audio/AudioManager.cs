using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using static Project1.Constants;
using System;

namespace Project1
{
    public class AudioManager
    {
        /*
         * Loads in sound files, held in Constants.cs
         */
        public static void LoadContent(ContentManager content)
        {
            // song used for background music
            BGM = content.Load<Song>("Audio\\04 Underworld BGM");
            gameOver = content.Load<Song>("Audio\\11_-_Legend_of_Zelda_-_NES_-_Game_Over");

            // sound effects
            addUI = content.Load<SoundEffect>("Audio\\add ui");
            bombBlow = content.Load<SoundEffect>("Audio\\LOZ_Bomb_Blow");
            bombDrop = content.Load<SoundEffect>("Audio\\LOZ_Bomb_Drop");
            boomerang = content.Load<SoundEffect>("Audio\\LOZ_Arrow_Boomerang");
            death = content.Load<SoundEffect>("Audio\\death");
            dragon = content.Load<SoundEffect>("Audio\\dragon");
            dragon2 = content.Load<SoundEffect>("Audio\\dragon2");
            dragon3 = content.Load<SoundEffect>("Audio\\dragon3");
            doorUnlock = content.Load<SoundEffect>("Audio\\LOZ_Door_Unlock");
            enemyDie = content.Load<SoundEffect>("Audio\\enemy die");
            enemyHit = content.Load<SoundEffect>("Audio\\LOZ_Enemy_Hit");
            fire = content.Load<SoundEffect>("Audio\\fire");
            flame = content.Load<SoundEffect>("Audio\\flame");
            bigItemGet = content.Load<SoundEffect>("Audio\\item get");
            smallItemGet = content.Load<SoundEffect>("Audio\\LOZ_Get_Item");
            heartGet = content.Load<SoundEffect>("Audio\\LOZ_Get_Heart");
            rupeeGet = content.Load<SoundEffect>("Audio\\LOZ_Get_Rupee");
            linkHurt = content.Load<SoundEffect>("Audio\\LOZ_Link_Hurt");
            lowHealth = content.Load<SoundEffect>("Audio\\low health");
            plus = content.Load<SoundEffect>("Audio\\plus");
            plusPlus = content.Load<SoundEffect>("Audio\\plus plus");
            secret = content.Load<SoundEffect>("Audio\\secret revealed");
            stairs = content.Load<SoundEffect>("Audio\\stairs");
            subtractUI = content.Load<SoundEffect>("Audio\\subtract ui");
            sword = content.Load<SoundEffect>("Audio\\sword swing");
            winningStateSound = content.Load<SoundEffect>("Audio\\TriforceSound");
            gameOverStateSound = content.Load<SoundEffect>("Audio\\Game OverState");
            //puzzleSolved = content.Load<SoundEffect>("Audio\\puzzleSolved");

            MediaPlayer.IsRepeating = true;
            //MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        public static void PlayMusic(Song music)
        {
            //MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(music);
        }

        public static void PlaySoundEffect(SoundEffect SFX)
        {
            try
            {
                SFX.Play();               
            }
            catch (Exception e)
            {

            }
        }      
    }
}
