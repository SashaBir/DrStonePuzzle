using UnityEngine;

namespace Puzzle
{
    public class AudioManagement : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioClip _buttonClickSound;
        [SerializeField] private AudioClip _wonSound;
        [SerializeField] private AudioClip _timeOutSound;

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
            _music.Play();
        }

        public void MusicOff()
        {
            IsPlayingMusic = false;
            _music.Stop();
        }

        public void PlayButtonClickSound()
        {
            Play(_buttonClickSound);
        }

        public void PlayWonSound()
        {
            Play(_wonSound);
        }

        public void PlayTimeOutSound()
        {
            Play(_timeOutSound);
        }

        private void Play(AudioClip clip)
        {
            if (IsPlayingSound == false)
                return;

            _sound.clip = clip;
            _sound.Play();
        }
    }
}