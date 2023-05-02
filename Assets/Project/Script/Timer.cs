using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Puzzle
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private int _second;

        public event Action OnTimeOut;

        private Coroutine _coroutine;

        public int Counter { get; private set; }

        private void Start()
        {
            StartTimer();
        }

        public void StartTimer()
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(Count());
        }

        public void StopTimer()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void Pause()
        {
            Game.Pause();
        }

        public void Unpause()
        {
            Game.Unpause();
        }

        private IEnumerator Count()
        {
            var delay = new WaitForSeconds(1);
            var waiter = new WaitWhile(() => Game.IsPaused == true);

            for (int i = _second - 1; i >= 0; i--)
            {
                yield return delay;
                yield return waiter;

                _text.text = CalculateTime(i);
            }

            OnTimeOut?.Invoke();
        }

        private string CalculateTime(int second)
        {
            return $"{second / 60}:{second % 60}";
        }
    }
}