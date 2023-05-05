using UnityEngine;

namespace Puzzle
{
    public class AudioManagement : MonoBehaviour
    {
        public static AudioManagement Instance { get; private set; }

        public bool IsPlayingSound { get; private set; } = true;

        public bool IsPlayingMusic { get; private set; } = true;

        public void Awake()
        {
            Instance ??= this;
        }

        public void SoundOn()
        {
            IsPlayingSound = true;
        }

        public void SoundOff()
        {
            IsPlayingSound = false;
        }

        public void MusicOn()
        {
            IsPlayingMusic = true;
        }

        public void MusicOff()
        {
            IsPlayingMusic = false;
        }
    }
}