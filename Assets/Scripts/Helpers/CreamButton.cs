using System;
using DG.Tweening;
using Game.IceCreamSystem.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Helpers
{
    public class CreamButton : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler, IPointerExitHandler
    {
        public CreamType CreamType;
        
        public Action OnButtonHolding;
        public Action OnButtonReleased;

        public bool IsActive = true;
        
        private bool _isHolding;
        private Tween _animTween;


        private void Update()
        {
            if(!IsActive)
                return;
            
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(_animTween != null)
            {
                _animTween.Kill();
            }
            _animTween = transform.DOScale(0.9f, 0.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(_animTween != null)
            {
                _animTween.Kill();
            }
            _animTween = transform.DOScale(1f, 0.2f);
        }
    }
}
