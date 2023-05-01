using UnityEngine;

namespace Puzzle
{
    public class FormPartGenerator : MonoBehaviour
    {
        [SerializeField] private FormPart _formPart;
        [SerializeField] private RectTransform _spawnpoint;
        [SerializeField] private Transform _container;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private Vector2 _offset;
        [SerializeField] private Vector2 _size;
        [SerializeField] private int _row;
        [SerializeField] private int _column;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            int index = 0;

            Vector2 defualt = _spawnpoint.anchoredPosition;
            Vector2 position = _spawnpoint.anchoredPosition;

            for (int i = 0; i < _row; i++)
            {
                for (int y = 0; y < _column; y++)
                {
                    FormPart part = Instantiate(_formPart, _container);
                    part.name = $"Part {index}";

                    part.Init(index, _sprites[index], _size);
                    part.SetPosition(position);
                    part.Resize();
                    part.Offset();

                    position.x += _offset.x;

                    index++;
                }

                position.y -= _offset.y;
                position.x = defualt.x;
            }
        }
    }
}