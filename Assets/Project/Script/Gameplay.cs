using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class Gameplay : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Button _pause;
        [SerializeField] private Button _unpause;
        [SerializeField] private Button _menu;

        private void OnEnable()
        {
            _pause.onClick.AddListener(Pause);
            _unpause.onClick.AddListener(Unpause);
        }

        private void OnDisable()
        {
            _pause.onClick.RemoveListener(Pause);
            _unpause.onClick.RemoveListener(Unpause);
        }

        private void Pause()
        {
            _timer.Pause();
            _pausePanel.SetActive(true);
            _unpause.gameObject.SetActive(true);
        }

        private void Unpause()
        {
            _timer.Unpause();
            _pausePanel.SetActive(false);
            _unpause.gameObject.SetActive(false);
        }
    }
}