using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;

namespace Game.CreamMachineSystem.Managers
{
    public static class CreamPercentageManager
    {
        private static List<CreamInfo> _creamInfos;
        
        public static float CalculatePercentage(List<CreamInfo> level)
        {
            // I assume we have 8 layers always
            float percentage = 0;
            int total = _creamInfos.Count;
            float increasingRate = 100f / 8 / total;
            
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
            return percentage;
        }

        public static void AddCurrent(CreamInfo creamInfo)
        {
           if(_creamInfos == null)
               _creamInfos = new List<CreamInfo>();
           
           _creamInfos.Add(creamInfo);
        }
    }
}
