﻿using System.Collections.Generic;
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

        public void UpdateCreamInfos(List<CreamInfo> creamInfos)
        {
            foreach (var info in creamInfos)
            {
                var creamSpline = _iceCreamSplines?.FirstOrDefault(x => x.CreamInfo.Layer == info.Layer);
                if(creamSpline != null)
                    creamSpline.CreamInfo.CreamType = info.CreamType;
            }
        }
    }
}