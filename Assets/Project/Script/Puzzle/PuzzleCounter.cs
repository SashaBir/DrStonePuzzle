using TMPro;
using UnityEngine;

namespace Puzzle
{
    public class PuzzleCounter : MonoBehaviour
    {
        [SerializeField] private PuzzleBinder _binder;
        [SerializeField] private TextMeshProUGUI  _counterText;
        [SerializeField] private PuzzelSolver _solver;

        private int _counter = 0;

        private void Start()
        {
            UpdateText();
        }

        private void OnEnable()
        {
            _binder.OnBinded += OnAdd;
            _binder.OnUnbinded += OnReduce;
        }

        private void OnDisable()
        {
            _binder.OnBinded -= OnAdd;
            _binder.OnUnbinded -= OnReduce;
        }

        private void OnAdd()
        {
            UpdateText(1);
        }

        private void OnReduce()
        {
            UpdateText(-1);
        }

        private void UpdateText(int value = 0)
        {
            _counter += value;
            _counterText.text = $"{_counter} / {_solver.TotalPuzzle}";
        }
    }
}