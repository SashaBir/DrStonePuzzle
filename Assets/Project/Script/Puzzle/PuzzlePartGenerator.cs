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

        private GameObject[] _spawnedPuzzle;

        private void Start()
        {
            _spawnedPuzzle = new GameObject[_sprites.Length];
        }

        public void Generate()
        {
            var spawnpoints = _spawnpoints.Shuffle();
            for (int i = 0; i < _sprites.Length; i++)
                _spawnedPuzzle[i] = Spawn(spawnpoints, i);
        }

        public void Delete()
        {
            for (int i = 0; i < _sprites.Length; i++)
                Destroy(_spawnedPuzzle[i]);
        }

        private GameObject Spawn(RectTransform[] spawnpoints, int i)
        {
            PuzzlePart part = Instantiate(_puzzlePart, _container);
            part.name = $"Puzzle {i}";

            part.Init(i, _sprites[i], _size);
            part.SetPosition(spawnpoints[i].transform.position);
            part.Resize();
            part.Offset();

            return part.gameObject;
        }
    }
}