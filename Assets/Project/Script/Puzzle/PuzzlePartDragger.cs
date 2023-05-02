using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle
{
    public class PuzzlePartDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _area;

        public event Action<PuzzlePart> OnDragEnded;
        public event Action<PuzzlePart> OnDragBigun;

        private PuzzlePart _puzzlePart;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Game.IsPaused == true)
                return;

            if (eventData.pointerEnter == null || eventData.pointerEnter.TryGetComponent(out PuzzlePart puzzlePart) == false)
                return;

            _puzzlePart = puzzlePart;
            OnDragBigun?.Invoke(puzzlePart);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (Game.IsPaused == true)
                return;

            if (_puzzlePart == null)
                return;

            var future = _puzzlePart.Rect.anchoredPosition + eventData.delta / _canvas.scaleFactor;
            if (IsInArea(future) == false)
                return;

            _puzzlePart.Rect.anchoredPosition = future;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (Game.IsPaused == true)
                return;

            if (_puzzlePart == null)
                return;

            OnDragEnded?.Invoke(_puzzlePart);
            _puzzlePart = null;
        }

        private bool IsInArea(Vector2 future)
        {
            Rect rect = _area.rect;
            return rect.min.x <= future.x && rect.min.y <= future.y &&
                future.x <= rect.max.x && future.y <= rect.max.y;
        }
    }
}