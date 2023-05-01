using UnityEngine;

namespace Puzzle
{
    public class FormCounter : MonoBehaviour
    {
        [SerializeField] private FormPart[] _formParts;

        private void Start()
        {
            for (int i = 0; i < _formParts.Length; i++)
                _formParts[i].Init(i);
        }
    }
}