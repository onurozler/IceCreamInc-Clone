using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;
using UnityEngine;

namespace Game.CreamMachineSystem.Managers
{
    public static class CreamPercentageManager
    {
        public static float CurrentPercentage;
        
        private static List<CreamInfo> _creamInfos;
        
        public static void CalculatePercentage(List<CreamInfo> level)
        {
            // I assume we have 8 layers always
            float percentage = 0;
            int total = _creamInfos.Count;
            float increasingRate = 100f / total;
            
            foreach (var levelInfo in level)
            {
                var specificLayer = _creamInfos.Where(x => x.Layer == levelInfo.Layer).ToList();
                foreach (var levelLayer in specificLayer)
                {
                    if (levelLayer.CreamType == levelInfo.CreamType)
                        percentage += increasingRate;
                }
            }
            
            _creamInfos.Clear();

            CurrentPercentage = percentage;
        }

        public static void AddCurrent(CreamInfo creamInfo)
        {
           if(_creamInfos == null)
               _creamInfos = new List<CreamInfo>();
           
           _creamInfos.Add(creamInfo);
        }
    }
}
