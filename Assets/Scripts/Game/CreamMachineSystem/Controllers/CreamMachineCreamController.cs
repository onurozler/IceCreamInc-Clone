using Game.IceCreamSystem.Base;
using UnityEngine;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineCreamController
    {
        private IceCreamBase _currentIceCream;
        private int _currentLayer;
        
        private CreamMachineMovementController _creamMachineMovementController;

        public CreamMachineCreamController()
        {
            _currentIceCream = null;
            _currentLayer = 0;
        }
        
        public void Initialize(CreamMachineMovementController creamMachineMovementController, IceCreamBase iceBase)
        {
            _currentIceCream = iceBase;
            _creamMachineMovementController = creamMachineMovementController;
            _creamMachineMovementController.OnPathCompleted += UpdateLayer;
            _creamMachineMovementController.OnCreamGenerated += GeneratedCream;
            
            UpdateLayer();
        }

        private void GeneratedCream(CreamType creamType)
        {
            
        }
        
        private void UpdateLayer()
        {
            if(_currentIceCream == null)
                return;
            
            var creamSpline = _currentIceCream.CreamSplineManager.GetCreamByLayer(_currentLayer++);
            if (creamSpline != null)
            {
                _creamMachineMovementController.NormalizedT = 0;
                _creamMachineMovementController.SetBezierSpline(creamSpline.BezierSpline);
            }
        }
    }
}
