using UnityEngine;

namespace Puzzle
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private PuzzlePartGenerator _generator;
        [SerializeField] private Timer _timer;

        public void StartGame()
        {
            _generator.Generate();
            _timer.RestartTimer();

            _timer.Unpause();
        }
    }
}