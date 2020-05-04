using System;
using UnityEngine;
using Utils;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineInputController : MonoBehaviour
    {
        public event Action OnPressing;
        public event Action OnReleasing; 

        private void Update()
        {
            if (Input.GetMouseButton(0))
                OnPressing.SafeInvoke();
            else
                OnReleasing.SafeInvoke();
        }
    }
}
