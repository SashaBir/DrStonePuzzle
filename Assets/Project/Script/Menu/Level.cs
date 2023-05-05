using System;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    [Serializable]
    public struct Level
    {
        [field: SerializeField] public GameStarter Starter { get; private set; }   

        [field: SerializeField] public Button Play { get; private set; }   

        [field: SerializeField] public GameObject Panel { get; private set; }
    }
}
