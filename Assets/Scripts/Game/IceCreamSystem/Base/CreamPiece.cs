using UnityEngine;

namespace Game.IceCreamSystem.Base
{
    public class CreamPiece : MonoBehaviour
    {
        public bool IsActive;
        public CreamType CreamType;

        public void Activate()
        {
            IsActive = true;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }
}
