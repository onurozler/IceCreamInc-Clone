using BezierSolution;
using Config;
using DG.Tweening;
using Game.CreamMachineSystem.Managers;
using Game.IceCreamSystem.Base;
using Game.IceCreamSystem.Managers;
using Game.LevelSystem;
using Game.LevelSystem.Events;
using Game.View;
using Game.View.Helpers;
using UnityEngine;
using Zenject;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineCreamController : MonoBehaviour
    {
        private PlayerView _playerView;
        private LevelGenerator _levelGenerator;
        private GameFinishedPopUp _gameFinishedPopUp;
        private IceCreamBase _currentIceCream;
        private int _currentLayer;
        
        private CreamMachineMovementController _creamMachineMovementController;
        private CreamPercentageManager _creamPercentageManager;

        [Inject]
        public void OnInstaller(IceCreamBase iceBase,  PlayerView playerView, GameFinishedPopUp gameFinishedPopUp)
        {
            _playerView = playerView;
            _currentIceCream = iceBase;
            _gameFinishedPopUp = gameFinishedPopUp;
            
            _creamPercentageManager = new CreamPercentageManager();
            
            LevelEvents.SubscribeEvent(LevelEventType.ON_FINISHED,() =>
            {
                CreamPiecePoolManager.Instance.DeactivateWholePool();
                _currentLayer = 0;
                UpdateLayer();
            });
        }
        
        public void Initialize(CreamMachineMovementController creamMachineMovementController)
        {
            _currentLayer = 0;

            _creamMachineMovementController = creamMachineMovementController;
            
            _creamMachineMovementController.OnPathCompleted += UpdateLayer;
            _creamMachineMovementController.OnCreamGenerated += GeneratedCream;
            
            UpdateLayer();
        }

        private void GeneratedCream(CreamType creamType, BezierSpline bezier, Transform iceCreamFilter)
        {
            var piece = CreamPiecePoolManager.Instance.GetCreamAvailableCream(creamType);
            piece.transform.eulerAngles = new Vector3(-90,0,0);
            piece.transform.position = iceCreamFilter.position;
            piece.transform.DOMove(bezier.GetPoint(_creamMachineMovementController.NormalizedT), 3f);
            var look = Quaternion.LookRotation(bezier.GetTangent(_creamMachineMovementController.NormalizedT));
            piece.transform.DORotateQuaternion(look, 3f);
            
            _creamPercentageManager.AddCurrent(new CreamInfo(_currentLayer-1,creamType));

            _playerView.UpdateProgressBar(_creamMachineMovementController.NormalizedT * 0.125f * GameConfig.SMOOTHNESS);
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
            if (_currentLayer > 8)
            {
                _gameFinishedPopUp.CurrentPercentage =
                _creamPercentageManager.CalculatePercentage(_currentIceCream.CreamSplineManager.GetIceCreamInfos());
                LevelEvents.InvokeEvent(LevelEventType.ON_FINISHED);
            }
        }
    }
}
