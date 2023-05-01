using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class Part : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [field: SerializeField] public int Id { get; private set; }

        private Vector2 _size;

        public void Init(int id)
        {
            Id = id;
        }

        public void Init(int id, Sprite sprite, Vector2 size)
        {
            Id = id;
            _image.sprite = sprite;
            _size = size;
        }

        public void SetPosition(Vector2 position)
        {
            _image.rectTransform.anchoredPosition = position;
        }

        public void Resize()
        {
            _image.rectTransform.sizeDelta = new Vector2
            {
                x = _image.sprite.rect.width,
                y = _image.sprite.rect.height
            };
        }

        public void Offset()
        {
            float x = _image.sprite.rect.width;
            float y = _image.sprite.rect.height;

            Vector2 offset = new() 
            {
                x = (x + _size.x) / 2 - _size.x,
                y = (y + _size.y) / 2 - _size.y
            };

            SetPosition(_image.rectTransform.anchoredPosition - offset);
        }
    }
}