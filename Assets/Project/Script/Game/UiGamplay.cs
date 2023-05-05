using System;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class UiGamplay : MonoBehaviour
    {
        [Header("Logic")]
        [SerializeField] private GameRestarter _restarter;
        [SerializeField] private GameShutdowner _shutdowner;

        [Header("Ui")]
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _selfPuzzle;
        [SerializeField] private GameObject _puzzlePanel;
        [SerializeField] private GameObject _listLevelPanel;

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnExit);
            _restartButton.onClick.AddListener(_restarter.RestartGame);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnExit);
            _restartButton.onClick.RemoveListener(_restarter.RestartGame);
        }

        private void OnExit()
        {
            _shutdowner.ShutdownGame();

            _selfPuzzle.SetActive(false);
            _puzzlePanel.SetActive(false);
            _listLevelPanel.SetActive(true);
        }
    }
}