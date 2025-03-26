using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace GameEngine.GameServices
{
    public static class SoundEffects
    {
        
        private static List<MediaPlayer> _effectPlayers = new List<MediaPlayer>(); // רשימה של אפקטים
        private static int _volume = 100; // רמת השמע בררת מחדל

        public static int Volume
        {
            set
            {
                _volume = value;
               
            }
            get
            {
                return _volume;
            }
        }

       
        /// <summary>
        /// מנגן את הסאונד של האפקט ומפסיק כאשר הוא הסתיים
        /// </summary>
        public static void PlaySoundEffect(string filename)
        {
            MediaPlayer effectPlayer = new MediaPlayer();
            effectPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Sfx/{filename}"));
            effectPlayer.Volume = _volume / 100.0;
            effectPlayer.Play();

            // Remove the player after playback ends
            effectPlayer.MediaEnded += (sender, args) =>
            {
                effectPlayer.Dispose();
                _effectPlayers.Remove(effectPlayer);
            };

            _effectPlayers.Add(effectPlayer);
        }
    }
}
