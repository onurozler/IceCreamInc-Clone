using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Helpers
{
    public class MatchPopUp : MonoBehaviour
    {
        [SerializeField] private Image _matchImage;

        public void Show(Sprite sprite)
        {
            gameObject.SetActive(true);
            _matchImage.sprite = sprite;
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
