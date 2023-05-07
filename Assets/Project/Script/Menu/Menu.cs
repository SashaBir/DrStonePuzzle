using System;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class Menu : MonoBehaviour
    {
        [Header("Volume")]
        [SerializeField] private Button _play;
        [SerializeField] private Button _menu;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _gamePanel;

        [Header("Volume")]
        [SerializeField] private Button _music;
        [SerializeField] private Button _sound;
        [SerializeField] private GameObject _musicBlockImage;
        [SerializeField] private GameObject _soundBlockImage;

        private AudioManagement _audio;

        private void Start()
        {
            _audio = AudioManagement.Instance;

            _play.onClick.AddListener(OnSwitchToGamePanel);
            _menu.onClick.AddListener(OnSwitchToMenuPanel);

            _music.onClick.AddListener(OnControlMusicVolume);
            _sound.onClick.AddListener(OnControlSoundVolume);
        }

        private void OnDestroy()
        {
            _play.onClick.RemoveListener(OnSwitchToGamePanel);
            _menu.onClick.RemoveListener(OnSwitchToMenuPanel);

            _music.onClick.RemoveListener(OnControlMusicVolume);
            _sound.onClick.RemoveListener(OnControlSoundVolume);
        }

        private void OnSwitchToGamePanel()
        {
            _menuPanel.SetActive(false);
            _gamePanel.SetActive(true);
        }

        private void OnSwitchToMenuPanel()
        {
            _menuPanel.SetActive(true);
            _gamePanel.SetActive(false);
        }

        private void OnControlMusicVolume()
        {
            ControlVolume(_audio.IsPlayingMusic, _audio.MusicOn, _audio.MusicOff, _musicBlockImage);
        }

        private void OnControlSoundVolume()
        {
            ControlVolume(_audio.IsPlayingSound, _audio.SoundOn, _audio.SoundOff, _soundBlockImage);
        }

        private void ControlVolume(bool isPlaying, Action on, Action off, GameObject image)
        {
            if (isPlaying == true)
            {
                off.Invoke();
                image.SetActive(true);
            }
            else
            {
                on.Invoke();
                image.SetActive(false);
            }
        }
    }
}
