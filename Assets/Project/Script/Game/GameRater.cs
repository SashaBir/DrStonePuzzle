﻿using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class GameRater : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _rating;

        public static bool IsRated { get; private set; } = false;

        private void OnEnable()
        {
            if (IsRated == true)
                _panel.SetActive(false);

            _rating.onClick.AddListener(OnRate);
        }

        private void OnDisable()
        {
            _rating.onClick.RemoveListener(OnRate);
        }

        private void OnRate()
        {
            Yandex.Instance.RateGame();

            _panel.SetActive(false);
            IsRated = true;
        }
    }
}