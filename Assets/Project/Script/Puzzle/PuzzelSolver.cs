using System;
using UnityEngine;

namespace Puzzle
{
    public class PuzzelSolver : MonoBehaviour
    {
        [SerializeField] private PuzzleBinder _binder;
        [SerializeField] private int _totalPuzzle;
        [SerializeField] private FormPart[] _formParts;

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
            if (counter == _totalPuzzle)
                OnAssambled?.Invoke();
        }

        private void OnRemove()
        {
            counter--;
        }
    }
}