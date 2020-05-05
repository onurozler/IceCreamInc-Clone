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
        }

        public void Show(int percentage)
        {
            _percentageText.text = "%" + percentage;
        }
        
    }
}
