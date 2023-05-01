using UnityEngine;

namespace Puzzle
{
    public class FormPart : MonoBehaviour
    {
        [field: SerializeField] public int Id { get; private set; }

        public void Init(int id)
        {
            Id = id;
        }
    }
}