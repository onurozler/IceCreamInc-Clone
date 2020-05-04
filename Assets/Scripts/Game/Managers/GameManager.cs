using Game.CreamMachineSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private CreamMachineBase _creamMachine; 
        
        [Inject]
        private void OnInstaller(CreamMachineBase creamMachineBase)
        {
            _creamMachine = creamMachineBase;
        }

        private void Start()
        {
            _creamMachine.Initialize();
        }
    }
}
