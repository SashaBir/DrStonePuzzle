using UnityEngine;

namespace Puzzle
{
    public class Game : MonoBehaviour
    {
        public static bool IsPaused { get; private set; } = false;

        public static void Pause()
        {
            IsPaused = true;
        }

        public static void Unpause()
        {
            IsPaused = false;
        }
    }
}