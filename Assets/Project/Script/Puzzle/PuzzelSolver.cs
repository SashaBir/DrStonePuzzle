﻿using System;
using UnityEngine;

namespace Puzzle
{
    public class PuzzelSolver : MonoBehaviour
    {
        [Header("Logic")]
        [SerializeField] private GameOverPuzzle _gameOver;
        [SerializeField] private Timer _timer;
        [SerializeField] private PuzzleBinder _binder;
        [SerializeField] private FormPart[] _formParts;

        [field: SerializeField] public int TotalPuzzle { get; private set; }

        public event Action OnAssambled;
        public event Action OnDisassambleds;

        private EndStatus _status = EndStatus.None;
        private int _counter = 0;

        private void OnEnable()
        {
            _binder.OnBinded += OnAdd;
            _binder.OnUnbinded += OnRemove;
            _timer.OnTimeOut += OnOut;
        }

        private void OnDisable()
        {
            _binder.OnBinded -= OnAdd;
            _binder.OnUnbinded -= OnRemove;
            _timer.OnTimeOut -= OnOut;
        }

        public void ResetCounter()
        {
            _status = EndStatus.None;
            _counter = 0;
        }

        private void OnOut()
        {
            if (_status == EndStatus.TimeOut)
                return;

            _status = EndStatus.TimeOut;

            AudioManagement.Instance.PlayTimeOutSound();

            Yandex.Instance.ShowAdInterstitial();
            GameRater.Instance.Rate();

            _gameOver.ShowTimeOutPanel();
            OnDisassambleds?.Invoke();
        }

        private void OnAdd()
        {
            _counter++;
            if (_counter != TotalPuzzle)
                return;

            if (_status == EndStatus.TimeOut)
                return;

            _status = EndStatus.Assambled;

            AudioManagement.Instance.PlayWonSound();

            Yandex.Instance.ShowAdInterstitial();
            GameRater.Instance.Rate();

            _gameOver.ShowWonPanel();
            _timer.Pause();
            OnAssambled?.Invoke();
        }

        private void OnRemove()
        {
            _counter--;
        }
    }
}