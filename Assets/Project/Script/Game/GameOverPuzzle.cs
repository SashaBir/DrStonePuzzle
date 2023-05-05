using UnityEngine;

namespace Puzzle
{
    public class GameOverPuzzle : MonoBehaviour
    {
        [Header("Logic")]
        [SerializeField] private GameRestarter _restarter;
        [SerializeField] private GameShutdowner _shutdowner;

        [Header("Ui")]
        [SerializeField] private GameObject _puzzlePanel;
        [SerializeField] private GameObject _listLevelPanel;
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _wonText;
        [SerializeField] private GameObject _timeOutText;

        private void OnDisable()
        {
            _panel.SetActive(false);
        }

        public void ShowWonPanel()
        {
            _panel.SetActive(true);

            _wonText.SetActive(true);
            _timeOutText.SetActive(false);
        }

        public void ShowTimeOutPanel()
        {
            _panel.SetActive(true);

            _wonText.SetActive(false);
            _timeOutText.SetActive(true);
        }
    }
}