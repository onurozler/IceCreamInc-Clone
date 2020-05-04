using System;
using BezierSolution;
using DG.Tweening;
using Game.IceCreamSystem.Base;
using UnityEngine;
using Utils;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineMovementController : BezierWalkerWithSpeed
    {
        public Action OnGenerateCream;
        
        public CreamPiece testPiece;

        private Transform _iceCreamFilter;
        
        private float _pieceChecker;
        private float _yPosition;
        private bool _isActive;

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
            if (_pieceChecker > 0.15f)
            {
                OnGenerateCream.SafeInvoke();
                _pieceChecker = 0;
                
                var piece = Instantiate(testPiece);
                piece.transform.position = _iceCreamFilter.position;
                piece.transform.DOMove(spline.GetPoint(NormalizedT),3f);
                var look = Quaternion.LookRotation(spline.GetTangent(NormalizedT));
                piece.transform.DORotateQuaternion(look, 3f);
            }
            transform.ChangePositionY(_yPosition);
        }
    }
}
