using BezierSolution;
using Game.CreamMachineSystem.Controllers;
using UnityEngine;

namespace Game.CreamMachineSystem.Base
{
    public class CreamMachineBase : MonoBehaviour
    {
        public BezierSpline testSpline;
        
        #region Controllers

        private CreamMachineInputController _creamMachineInputController;
        private CreamMachineMovementController _creamMachineMovementController;

        #endregion
        
        public void Initialize()
        {
            _creamMachineInputController = gameObject.AddComponent<CreamMachineInputController>();
            _creamMachineMovementController = gameObject.AddComponent<CreamMachineMovementController>();
            _creamMachineMovementController.Initialize();
            _creamMachineMovementController.SetBezierSpline(testSpline);
            
            InputEventsSubscriptions();
        }

        private void InputEventsSubscriptions()
        {
            _creamMachineInputController.OnPressing += _creamMachineMovementController.MoveAroundCurve;
            _creamMachineInputController.OnReleasing += _creamMachineMovementController.Stop;
        }
    }
}
