using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class PlayerView : GenericSingleton<PlayerView>
    {
        [SerializeField] 
        private Image _progressBar;

        public void UpdateProgressBar(float value)
        {
            _progressBar.fillAmount += value;
        }
    }
}
