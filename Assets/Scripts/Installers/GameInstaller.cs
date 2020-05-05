using Game.CreamMachineSystem.Base;
using Game.IceCreamSystem.Base;
using Game.LevelSystem;
using Game.View;
using Game.View.Helpers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private IceCreamBase _iceCreamBase;
        [SerializeField] private CreamMachineBase _creamMachineBase;

        [SerializeField] private PlayerInputController _playerInput;
        [SerializeField] private LevelGenerator _levelGenerator;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_playerView);
            Container.BindInstance(_creamMachineBase);
            Container.BindInstance(_iceCreamBase);
            Container.BindInstance(_playerInput);
            Container.BindInstance(_levelGenerator);
        }
    }
}