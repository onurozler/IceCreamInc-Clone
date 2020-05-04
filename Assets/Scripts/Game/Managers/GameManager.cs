using Game.CreamMachineSystem.Base;
using Game.IceCreamSystem.Base;
using Game.IceCreamSystem.Managers;
using Game.LevelSystem;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private IceCreamBase _iceCreamBase;
        private CreamMachineBase _creamMachine;
        private LevelGenerator _levelGenerator;
        
        [Inject]
        private void OnInstaller(IceCreamBase iceCreamBase,CreamMachineBase creamMachineBase, LevelGenerator levelGenerator)
        {
            _iceCreamBase = iceCreamBase;
            _creamMachine = creamMachineBase;
            _levelGenerator = levelGenerator;
        }

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _iceCreamBase.Initialize();
            _creamMachine.Initialize();
            _levelGenerator.Initialize();

            CreamPiecePoolManager.Instance.Initialize();
        }
    }
}
