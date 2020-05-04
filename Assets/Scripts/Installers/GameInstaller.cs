using Game.CreamMachineSystem.Base;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CreamMachineBase _creamMachineBase;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_creamMachineBase);
        }
    }
}