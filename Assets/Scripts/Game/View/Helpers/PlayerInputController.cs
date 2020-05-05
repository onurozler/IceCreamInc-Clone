using System;
using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;
using Helpers;
using UnityEngine;


namespace Game.View.Helpers
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private List<CreamButton> _creamButtons;

        public void ChangeButtonStatus(bool status)
        {
            foreach (var button in _creamButtons)
            {
                button.IsActive = status;
            }
        }
        
        
        public void SubscribeHoldingEvent(Action action)
        {
            foreach (var creamButton in _creamButtons)
            {
                creamButton.OnButtonHolding += action;
            }
        }
        
        public void SubscribeHoldingEvent(CreamType creamType, Action action)
        {
            var creamButton = _creamButtons?.FirstOrDefault(x => x.CreamType == creamType);
            if (creamButton != null)
                creamButton.OnButtonHolding += action;
        }

        public void SubscribeReleasingEvent(Action action)
        {
            foreach (var creamButton in _creamButtons)
            {
                creamButton.OnButtonReleased += action;
            }
        }
        
        public void SubscribeReleasingEvent(CreamType creamType, Action action)
        {
            var creamButton = _creamButtons?.FirstOrDefault(x => x.CreamType == creamType);
            if (creamButton != null)
                creamButton.OnButtonReleased += action;
        }
    }
}
