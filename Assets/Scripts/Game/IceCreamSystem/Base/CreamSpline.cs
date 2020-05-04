using System;
using BezierSolution;
using UnityEngine;

namespace Game.IceCreamSystem.Base
{
    public enum CreamType
    {
        NONE,
        CHOCOLATE,
        MILK
    }
    
    [Serializable]
    public class CreamInfo
    {
        public int Layer;
        public CreamType CreamType;

        public CreamInfo(int layer, CreamType type)
        {
            Layer = layer;
            CreamType = type;
        }
    }
    
    public class CreamSpline : MonoBehaviour
    {
        public CreamInfo CreamInfo;
        public BezierSpline BezierSpline => GetComponent<BezierSpline>();
    }
}
