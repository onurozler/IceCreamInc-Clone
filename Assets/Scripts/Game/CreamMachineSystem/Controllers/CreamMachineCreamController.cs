﻿using BezierSolution;
using DG.Tweening;
using Game.IceCreamSystem.Base;
using Game.IceCreamSystem.Managers;
using Game.LevelSystem;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineCreamController : MonoBehaviour
    {
        private LevelGenerator _levelGenerator;
        private IceCreamBase _currentIceCream;
        private int _currentLayer;
        
        private CreamMachineMovementController _creamMachineMovementController;

        [Inject]
        public void OnInstaller(IceCreamBase iceBase, LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
            _currentIceCream = iceBase;
            _currentLayer = 0;
        }
        
        public void Initialize(CreamMachineMovementController creamMachineMovementController)
        {
            _creamMachineMovementController = creamMachineMovementController;
            
            _creamMachineMovementController.OnPathCompleted += UpdateLayer;
            _creamMachineMovementController.OnCreamGenerated += GeneratedCream;
            
            UpdateLayer();
        }

        private void GeneratedCream(CreamType creamType, BezierSpline bezier, Transform iceCreamFilter)
        {
            var piece = CreamPiecePoolManager.Instance.GetCreamAvailableCream(creamType);
            piece.transform.position = iceCreamFilter.position;
            piece.transform.DOMove(bezier.GetPoint(_creamMachineMovementController.NormalizedT), 3f);
            var look = Quaternion.LookRotation(bezier.GetTangent(_creamMachineMovementController.NormalizedT));
            piece.transform.DORotateQuaternion(look, 3f);

            PlayerView.Instance.UpdateProgressBar(_creamMachineMovementController.NormalizedT * 0.125f * 0.14f);
        }
        
        private void UpdateLayer()
        {
            if(_currentIceCream == null)
                return;
            
            var creamSpline = _currentIceCream.CreamSplineManager.GetCreamByLayer(_currentLayer++);

            CheckLevelStatus();
            if (creamSpline != null)
            {
                _creamMachineMovementController.NormalizedT = 0;
                _creamMachineMovementController.SetBezierSpline(creamSpline.BezierSpline);
            }
        }

        private void CheckLevelStatus()
        {
            if (_currentLayer >= 8)
            {
                _levelGenerator.GenerateLevel();
            }
        }
    }
}
