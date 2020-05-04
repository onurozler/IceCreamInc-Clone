using UnityEngine;

namespace Game.LevelSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        private const string LEVEL_DATA_PATH = "LevelDatas";
        private int _levelIndex;

        public void Initialize()
        {
            _levelIndex = 0;
        }

        public void GenerateLevel()
        {
            
        }
    }
}
