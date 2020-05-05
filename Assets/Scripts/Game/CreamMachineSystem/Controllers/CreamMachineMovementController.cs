using System;
using BezierSolution;
using Game.IceCreamSystem.Base;
using Game.View.Helpers;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineMovementController : BezierWalkerWithSpeed
    {
        public Action<CreamType,BezierSpline,Transform> OnCreamGenerated;
        
        private PlayerInputController _playerInputController;
        
        private Transform _iceCreamFilter;
        private float _pieceChecker;
        private float _yPosition;
        private bool _isActive;

        [Inject]
        private void OnInstaller(PlayerInputController playerInputController)
        {
            _playerInputController = playerInputController;
            _playerInputController.SubscribeHoldingEvent(CreamType.CHOCOLATE,()=>GenerateCream(CreamType.CHOCOLATE));
            _playerInputController.SubscribeHoldingEvent(CreamType.VANILLA,()=>GenerateCream(CreamType.VANILLA));
            _playerInputController.SubscribeHoldingEvent(MoveAroundCurve);
            _playerInputController.SubscribeReleasingEvent(Stop);
        }
        
        public void Initialize()
        {
            _iceCreamFilter = transform.Find("IceCreamFilter");
            _yPosition = transform.position.y;
            _pieceChecker = 0;
            lookAt = LookAtMode.None;
            speed = 2f;
        }
        
        public void SetBezierSpline(BezierSpline bezierSpline)
        {
            spline = bezierSpline;
        }
        
        public void MoveAroundCurve()
        {
            _isActive = true;
        }

        public void Stop()
        {
            _isActive = false;
        }
        
        protected override void Update()
        {
            if(!_isActive || spline == null)
                return;
            
            base.Update();
            UpdateHeightPosition();
        }

        private void UpdateHeightPosition()
        {
            _pieceChecker += Time.deltaTime;
            transform.ChangePositionY(_yPosition);
        }

        private void GenerateCream(CreamType creamType)
        {
            if (_pieceChecker > 0.15f)
            {
                _pieceChecker = 0;
                OnCreamGenerated.SafeInvoke(creamType,spline,_iceCreamFilter);
            }
        }
    }
}
