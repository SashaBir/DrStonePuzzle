using UnityEngine;

namespace Puzzle
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private PuzzelSolver _solver;
        [SerializeField] private PuzzlePartGenerator _generator;
        [SerializeField] private PuzzleCounter _counter;
        [SerializeField] private Timer _timer;

        public void RestartGame()
        {
            _solver.ResetCounter();

            _generator.Delete();
            _generator.Generate();

            _timer.RestartTimer();
            _counter.ResetCounter();
        }
    }
}