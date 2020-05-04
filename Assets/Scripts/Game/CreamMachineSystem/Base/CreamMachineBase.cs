using Game.CreamMachineSystem.Controllers;
using Game.IceCreamSystem.Base;
using Game.View.Helpers;
using UnityEngine;
using Zenject;

namespace Game.CreamMachineSystem.Base
{
    public class CreamMachineBase : MonoBehaviour
    {
        public IceCreamBase CurrentIceCream;
        
        #region Controllers

        private PlayerInputController _playerInputController;
        private CreamMachineMovementController _creamMachineMovementController;
        private CreamMachineCreamController _creamMachineCreamController;

        #endregion

        [Inject]
        private void OnInstaller(PlayerInputController playerInputController)
        {
            _playerInputController = playerInputController;
            _creamMachineMovementController = GetComponent<CreamMachineMovementController>(); 
            //gameObject.AddComponent<CreamMachineMovementController>(); 
            _creamMachineCreamController = new CreamMachineCreamController();
        }
        
        public void Initialize()
        {
            _creamMachineMovementController.Initialize();
            _creamMachineCreamController.Initialize(_creamMachineMovementController,CurrentIceCream);
            InputEventsSubscriptions();
        }

        private void InputEventsSubscriptions()
        {
            _playerInputController.SubscribeHoldingEvent(_creamMachineMovementController.MoveAroundCurve);
            _playerInputController.SubscribeReleasingEvent(_creamMachineMovementController.Stop);
        }
    }
}
