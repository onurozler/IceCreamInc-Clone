using Game.CreamMachineSystem.Base;
using Game.View.Helpers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CreamMachineBase _creamMachineBase;
        [SerializeField] private PlayerInputController _playerInput;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_creamMachineBase);
            Container.BindInstance(_playerInput);
        }
    }
}