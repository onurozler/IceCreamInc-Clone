using System;
using BezierSolution;
using Config;
using Game.IceCreamSystem.Base;
using Game.LevelSystem.Events;
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

        private Vector3 _firstPosition;
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
            
            LevelEvents.SubscribeEvent(LevelEventType.ON_FINISHED, 
                () =>
                {
                    transform.position = _firstPosition;
                    _isActive = false;
                });
        }
        
        public void Initialize()
        {
            _firstPosition = transform.position;
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

        private void MoveAroundCurve()
        {
            _isActive = true;
        }

        private void Stop()
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
            if (_pieceChecker > GameConfig.SMOOTHNESS)
            {
                _pieceChecker = 0;
                OnCreamGenerated.SafeInvoke(creamType,spline,_iceCreamFilter);
            }
        }
    }
}
