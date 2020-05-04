using System;
using Game.IceCreamSystem.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Helpers
{
    public class CreamButton : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
    {
        public CreamType CreamType;
        
        public Action OnButtonHolding;
        public Action OnButtonReleased;
        
        private bool _isHolding;

        private void Update()
        {
            if (_isHolding)
            {
                OnButtonHolding.SafeInvoke();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isHolding = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isHolding = false;
            OnButtonReleased.SafeInvoke();
        }
    }
}
