using DG.Tweening;
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

        private Transform _chocolateStick;
        private Transform _vanillaStick;
        
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

            _chocolateStick = transform.Find("ChocolateStick");
            _vanillaStick = transform.Find("VanillaStick");
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
            
            _playerInputController.SubscribeHoldingEvent(CreamType.CHOCOLATE, () =>
                _chocolateStick.DORotate(Vector3.forward * 45f, 1f)
                );
            _playerInputController.SubscribeReleasingEvent(CreamType.CHOCOLATE, () =>
                _chocolateStick.DORotate(Vector3.zero, 1f)
            );
            
            _playerInputController.SubscribeHoldingEvent(CreamType.VANILLA, () =>
                _vanillaStick.DORotate(Vector3.forward * 45f, 1f)
            );
            _playerInputController.SubscribeReleasingEvent(CreamType.VANILLA, () =>
                _vanillaStick.DORotate(Vector3.zero, 1f)
            );
        }
    }
}
