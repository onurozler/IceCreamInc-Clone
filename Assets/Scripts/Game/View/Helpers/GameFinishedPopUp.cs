using Game.CreamMachineSystem.Managers;
using Game.LevelSystem.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Helpers
{
    public class GameFinishedPopUp : MonoBehaviour
    {
        private Text _percentageText;
        private Button _nextLevelButton;

        public void Initialize()
        {
            _percentageText = GetComponentInChildren<Text>();
            _nextLevelButton = GetComponentInChildren<Button>();
            
            _nextLevelButton.onClick.AddListener(() =>
            {
                LevelEvents.InvokeEvent(LevelEventType.ON_STARTED);
                gameObject.SetActive(false);
            });
            
            LevelEvents.SubscribeEvent(LevelEventType.ON_FINISHED,Show);
        }

        private void Show()
        {
            gameObject.SetActive(true);
            _percentageText.text = "Accuracy %" + Mathf.FloorToInt(CreamPercentageManager.CurrentPercentage);
        }
        
    }
}
