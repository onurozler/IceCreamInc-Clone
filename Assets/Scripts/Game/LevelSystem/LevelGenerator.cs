using System;
using Game.IceCreamSystem.Base;
using Game.LevelSystem.Events;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.LevelSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        public Action<LevelData> OnLevelLoaded;
        
        private const string LEVEL_DATA_PATH = "LevelDatas/";
        private int _levelIndex;

        private IceCreamBase _iceCreamBase;
        
        [Inject]
        private void OnInstaller(IceCreamBase iceCream)
        {
            _iceCreamBase = iceCream;
        }
        
        public void Initialize()
        {
            _levelIndex = 1;
            GenerateLevel();
        }

        public void GenerateLevel()
        {
            var levelData = Resources.Load<LevelData>(LEVEL_DATA_PATH+"Level"+_levelIndex);
            if (levelData == null)
                _levelIndex = 1;
            
            _iceCreamBase.CreamSplineManager.UpdateCreamInfos(levelData.CreamInfos);
            OnLevelLoaded.SafeInvoke(levelData);
            _levelIndex++;
            
            
            LevelEvents.InvokeEvent(LevelEventType.ON_STARTED);
        }
        
    }
}
