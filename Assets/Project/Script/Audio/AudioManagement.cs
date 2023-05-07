using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class AudioManagement : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioClip _buttonClickSound;
        [SerializeField] private AudioClip _wonSound;
        [SerializeField] private AudioClip _timeOutSound;
        [SerializeField] private AudioClip _setPuzzle;
        [SerializeField] private AudioClip _takenPuzzle;

        private Button[] _buttons;

        public static AudioManagement Instance { get; private set; }

        public bool IsPlayingSound { get; private set; } = true;

        public bool IsPlayingMusic { get; private set; } = true;

        public void Awake()
        {
            Instance ??= this;
        }

        private void Start()
        {
            _buttons = FindObjectsOfType<Button>(true);
            foreach (var button in _buttons)
                button.onClick.AddListener(PlayButtonClickSound);
        }

        private void OnDisable()
        { 
            foreach (var button in _buttons)
                button.onClick.RemoveListener(PlayButtonClickSound);
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

        public void PlaySetPuzzleSound()
        {
            Play(_setPuzzle);
        }

        public void PlayTakenPuzzleSound()
        {
            Play(_takenPuzzle);
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