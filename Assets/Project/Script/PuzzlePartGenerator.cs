using UnityEngine;

namespace Puzzle
{
    public class PuzzlePartGenerator : MonoBehaviour
    {
        [SerializeField] private PuzzlePart _puzzlePart;
        [SerializeField] private RectTransform[] _spawnpoints;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private Transform _container;
        [SerializeField] private Vector2 _size;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            var spawnpoints = _spawnpoints.Shuffle();
            for (int i = 0; i < _sprites.Length; i++)
                Spawn(spawnpoints, i);
        }

        private void Spawn(RectTransform[] spawnpoints, int i)
        {
            PuzzlePart part = Instantiate(_puzzlePart, _container);
            part.name = $"Puzzle {i}";

            part.Init(i, _sprites[i], _size);
            part.SetPosition(spawnpoints[i].anchoredPosition);
            part.Resize();
            part.Offset();
        }
    }
}