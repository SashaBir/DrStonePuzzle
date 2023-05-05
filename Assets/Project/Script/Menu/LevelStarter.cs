using UnityEngine;

namespace Puzzle
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _listLevelsPanel;
        [SerializeField] private GameObject _puzzlePanel;
        [SerializeField] private Level[] _levels;

        private void OnEnable()
        {
            foreach (var level in _levels)
            {
                level.Play.onClick.AddListener(() =>  BindLevel(level));
            }   
        }

        private void OnDisable()
        {
            foreach (var level in _levels)
                level.Play.onClick.RemoveAllListeners();
        }

        private void BindLevel(Level level)
        {
            _listLevelsPanel.SetActive(false);
            _puzzlePanel.SetActive(true);
            
            level.Panel.SetActive(true);
            level.Starter.StartGame();
        }
    }
}
