using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class GameOverPuzzle : MonoBehaviour
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
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _wonText;
        [SerializeField] private GameObject _timeOutText;

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnExit);
            _restartButton.onClick.AddListener(OnRestart);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnExit);
            _restartButton.onClick.RemoveListener(OnRestart);
        }

        public void ShowWonPanel()
        {
            _panel.SetActive(false);

            _wonText.SetActive(true);
            _timeOutText.SetActive(false);
        }

        public void ShowTimeOutPanel()
        {
            _panel.SetActive(false);

            _wonText.SetActive(false);
            _timeOutText.SetActive(true);
        }

        private void OnExit()
        {
            _shutdowner.ShutdownGame();

            _selfPuzzle.SetActive(false);
            _puzzlePanel.SetActive(false);
            _listLevelPanel.SetActive(true);

            _panel.SetActive(false);
        }

        private void OnRestart()
        {
            _restarter.RestartGame();
            _panel.SetActive(false);
        }
    }
}