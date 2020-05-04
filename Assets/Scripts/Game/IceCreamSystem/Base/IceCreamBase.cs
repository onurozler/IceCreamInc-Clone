using System.Linq;
using Game.IceCreamSystem.Managers;
using UnityEngine;

namespace Game.IceCreamSystem.Base
{
    public class IceCreamBase : MonoBehaviour
    {
        public CreamSplineManager CreamSplineManager;
        
        public void Initialize()
        {
            var creamSplines = GetComponentsInChildren<CreamSpline>().ToList();
            CreamSplineManager = new CreamSplineManager(creamSplines);
        }
    }
}
