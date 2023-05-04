using Unity.VisualScripting;
using UnityEngine;

namespace Puzzle
{
    public class GameShutdowner : MonoBehaviour
    {
        [SerializeField] private PuzzelSolver _solver;
        [SerializeField] private PuzzlePartGenerator _generator;
        [SerializeField] private PuzzleCounter _counter;
        [SerializeField] private Timer _timer;

        public void ShutdownGame()
        {
            _solver.ResetCounter();

            _generator.Delete();

            _timer.StopTimer();
            _counter.ResetCounter();
        }
    }
}