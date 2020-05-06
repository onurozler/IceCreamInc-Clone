using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;

namespace Game.CreamMachineSystem.Managers
{
    public class CreamPercentageManager
    {
        private List<CreamInfo> _creamInfos;

        public CreamPercentageManager()
        {
            _creamInfos = new List<CreamInfo>();
        }
        
        public float CalculatePercentage(List<CreamInfo> level)
        {
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

            return percentage;
        }

        public void AddCurrent(CreamInfo creamInfo)
        {
           if(_creamInfos == null)
               _creamInfos = new List<CreamInfo>();
           
           _creamInfos.Add(creamInfo);
        }
    }
}
