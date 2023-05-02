using System;
using UnityEngine;

namespace Puzzle
{
    public class PuzzelSolver : MonoBehaviour
    {
        [SerializeField] private PuzzleBinder _binder;
        [SerializeField] private FormPart[] _formParts;

        [field: SerializeField] public int TotalPuzzle { get; private set; }

        public event Action OnAssambled;

        private int counter = 0;

        private void OnEnable()
        {
            _binder.OnBinded += OnAdd;
            _binder.OnUnbinded += OnRemove;
        }

        private void OnDisable()
        {
            _binder.OnBinded -= OnAdd;
            _binder.OnUnbinded -= OnRemove;
        }

        private void OnAdd()
        {
            counter++;
            if (counter == TotalPuzzle)
                OnAssambled?.Invoke();
        }

        private void OnRemove()
        {
            counter--;
        }
    }
}