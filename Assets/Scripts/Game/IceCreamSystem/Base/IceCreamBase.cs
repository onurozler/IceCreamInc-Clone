using System.Linq;
using Game.IceCreamSystem.Managers;
using UnityEngine;

namespace Game.IceCreamSystem.Base
{
    public class IceCreamBase : MonoBehaviour
    {
        private IceCreamSplineManager _iceCreamSplineManager;
        
        public void Initialize()
        {
            var creamSplines = GetComponentsInChildren<IceCreamSpline>().ToList();
            _iceCreamSplineManager = new IceCreamSplineManager(creamSplines);
        }
    }
}
