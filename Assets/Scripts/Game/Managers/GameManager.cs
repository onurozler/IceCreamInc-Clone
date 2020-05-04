using Game.CreamMachineSystem.Base;
using Game.IceCreamSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        public IceCreamBase IceCreamBase;
        
        private CreamMachineBase _creamMachine; 
        
        [Inject]
        private void OnInstaller(CreamMachineBase creamMachineBase)
        {
            _creamMachine = creamMachineBase;
        }

        private void Start()
        {
            IceCreamBase.Initialize();
            _creamMachine.CurrentIceCream = IceCreamBase;
            _creamMachine.Initialize();
        }
    }
}
