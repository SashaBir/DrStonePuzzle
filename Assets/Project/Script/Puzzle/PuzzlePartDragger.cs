using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle
{
    public class PuzzlePartDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas _canvas;

        public event Action<PuzzlePart> OnDragEnded;
        public event Action<PuzzlePart> OnDragBigun;

        private PuzzlePart _puzzlePart;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter == null || eventData.pointerEnter.TryGetComponent(out PuzzlePart puzzlePart) == false)
                return;

            _puzzlePart = puzzlePart;
            OnDragBigun?.Invoke(puzzlePart);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_puzzlePart != null)
                _puzzlePart.Rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_puzzlePart == null)
                return;

            OnDragEnded?.Invoke(_puzzlePart);
            _puzzlePart = null;
        }
    }
}