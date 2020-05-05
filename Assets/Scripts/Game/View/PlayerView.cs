using Game.LevelSystem;
using Game.View.Helpers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class PlayerView: MonoBehaviour
    {
        [SerializeField] 
        private Image _progressBar;
        private Text _progressText;

        private GameFinishedPopUp _gameFinishedPopUp;
        private MatchPopUp _matchPopUp;
        private LevelGenerator _levelGenerator;

        [Inject]
        private void OnInstaller(LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
            _progressText = _progressBar.GetComponentInChildren<Text>();
            _matchPopUp = GetComponentInChildren<MatchPopUp>();
            _gameFinishedPopUp = GetComponentInChildren<GameFinishedPopUp>(true);
            _gameFinishedPopUp.Initialize();
            
            _levelGenerator.OnLevelLoaded += UpdateLevel;
        }

        private void UpdateLevel(LevelData levelData)
        {
            _progressText.text = "Level " + levelData.LevelIndex;
            _matchPopUp.Show(levelData.LevelImage);
        }

        public void UpdateProgressBar(float value)
        {
            _progressBar.fillAmount += value;
        }
    }
}
