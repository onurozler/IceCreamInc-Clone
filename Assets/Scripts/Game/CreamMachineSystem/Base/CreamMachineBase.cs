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

        #endregion

        [Inject]
        private void OnInstaller(PlayerInputController playerInputController)
        {
            _playerInputController = playerInputController;
        }
        
        public void Initialize()
        {
            _creamMachineMovementController = gameObject.AddComponent<CreamMachineMovementController>();
            _creamMachineMovementController.Initialize();
            _creamMachineMovementController.SetBezierSpline(CurrentIceCream.CreamSplineManager.GetCreamByLayer(0).BezierSpline);

            InputEventsSubscriptions();
        }

        private void InputEventsSubscriptions()
        {
            _playerInputController.SubscribeHoldingEvent(_creamMachineMovementController.MoveAroundCurve);
            _playerInputController.SubscribeReleasingEvent(_creamMachineMovementController.Stop);

            //_creamMachineInputController.OnReleasing += _creamMachineMovementController.Stop;
        }
    }
}
