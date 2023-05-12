using System.Runtime.InteropServices;
using UnityEngine;

namespace Puzzle
{
    public class Yandex : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void ShowInterstitialAdvertising();

        [DllImport("__Internal")]
        private static extern void Rate();
        
        public static Yandex Instance { get; private set; }

        private void Awake()
        {
            Instance ??= this;
        }

        public void ShowAdInterstitial()
        {
            ShowInterstitialAdvertising();
        }

        public void RateGame()
        {
            Rate();
        }
    }
}
