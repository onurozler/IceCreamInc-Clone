using BezierSolution;
using UnityEngine;

namespace Game.IceCreamSystem.Managers
{
    public enum CreamType
    {
        CHOCOLATE,
        MILK
    }

    public class CreamInfo
    {
        public int Order;
        public CreamType CreamType;
    }
    
    public class IceCreamSpline : MonoBehaviour
    {
        public CreamInfo CreamInfo;
        public BezierSpline BezierSpline => GetComponent<BezierSpline>();
    }
}
