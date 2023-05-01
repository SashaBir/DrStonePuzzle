using System;
using System.Linq;
using UnityEngine;

namespace Puzzle
{
    public class PuzzleBinder : MonoBehaviour
    {
        [SerializeField] private PuzzlePartDragger _dragger;
        [SerializeField] private float _distance;
        [SerializeField] private FormPart[] _formParts;

        private void OnEnable()
        {
            _dragger.OnDragEnded += OnBind;
        }

        private void OnDisable()
        {
            _dragger.OnDragEnded -= OnBind;
        }

        private void OnBind(PuzzlePart puzzlePart)
        {
            var formPart = _formParts.FirstOrDefault(i => i.Id == puzzlePart.Id);
            if (formPart == null)
                return;

            var isDistance = Vector2.Distance(puzzlePart.Rect.position, formPart.Rect.position) <= _distance;
            if (isDistance == false)
                return;

            puzzlePart.Rect.position = formPart.Rect.position;
        }
    }        
}