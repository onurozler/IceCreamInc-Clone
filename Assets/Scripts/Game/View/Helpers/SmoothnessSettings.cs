using Config;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Helpers
{
    public class SmoothnessSettings : MonoBehaviour
    {
        private float _normal = 0.15f;
        private float _high = 0.10f;
        private float _veryHigh = 0.05f;
        
        private Dropdown _dropdown;
        public void Initialize()
        {
            _dropdown = GetComponent<Dropdown>();
            _dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            switch (value)
            {
                case 0:
                    GameConfig.SMOOTHNESS = _normal;
                    break;
                case 1:
                    GameConfig.SMOOTHNESS = _high;
                    break;
                default:
                    GameConfig.SMOOTHNESS = _veryHigh;
                    break;
            }
        }
    }
}
