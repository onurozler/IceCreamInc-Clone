using System.Collections.Generic;
using Game.IceCreamSystem.Base;
using UnityEngine;

namespace Game.LevelSystem
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level Datas/New Level", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int LevelIndex;
        public Sprite LevelImage;
        public List<CreamInfo> CreamInfos;
    }
}
