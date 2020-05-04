using System.Linq;
using Game.IceCreamSystem.Managers;
using UnityEngine;

namespace Game.IceCreamSystem.Base
{
    public class IceCreamBase : MonoBehaviour
    {
        private CreamSplineManager _creamSplineManager;
        
        public void Initialize()
        {
            var creamSplines = GetComponentsInChildren<CreamSpline>().ToList();
            _creamSplineManager = new CreamSplineManager(creamSplines);
        }
    }
}
