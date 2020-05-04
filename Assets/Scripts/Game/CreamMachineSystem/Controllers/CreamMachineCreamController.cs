﻿using Game.IceCreamSystem.Base;

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

            UpdateLayer();
        }

        private void GenerateCream()
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
