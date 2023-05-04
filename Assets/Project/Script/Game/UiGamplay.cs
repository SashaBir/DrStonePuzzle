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

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(_shutdowner.ShutdownGame);
            _restartButton.onClick.AddListener(_restarter.RestartGame);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(_shutdowner.ShutdownGame);
            _restartButton.onClick.RemoveListener(_restarter.RestartGame);
        }
    }
}