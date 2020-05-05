using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;

namespace Game.IceCreamSystem.Managers
{
    public class CreamSplineManager
    {
        private List<CreamSpline> _iceCreamSplines;

        public CreamSplineManager(List<CreamSpline> splines)
        {
            _iceCreamSplines = splines;
        }

        public CreamSpline GetCreamByLayer(int layer)
        {
            return _iceCreamSplines?.FirstOrDefault(x => x.CreamInfo.Layer == layer);
        }
        
        public void UpdateCreamInfos(List<CreamInfo> creamInfos)
        {
            foreach (var info in creamInfos)
            {
                var creamSpline = _iceCreamSplines?.FirstOrDefault(x => x.CreamInfo.Layer == info.Layer);
                if(creamSpline != null)
                    creamSpline.CreamInfo.CreamType = info.CreamType;
            }
        }

        public List<CreamInfo> GetIceCreamInfos()
        {
            List<CreamInfo> creamInfos = new List<CreamInfo>();
            foreach (var creamSpline in _iceCreamSplines)
            {
                creamInfos.Add(creamSpline.CreamInfo);
            }

            return creamInfos;
        }
    }
}
