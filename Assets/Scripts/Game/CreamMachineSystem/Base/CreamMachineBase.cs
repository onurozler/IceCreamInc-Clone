using Game.CreamMachineSystem.Controllers;
using UnityEngine;

namespace Game.CreamMachineSystem.Base
{
    public class CreamMachineBase : MonoBehaviour
    {
        #region Controllers

        private CreamMachineInputController _creamMachineInputController;
        private CreamMachineMovementController _creamMachineMovementController;

        #endregion
        
        public void Initialize()
        {
            _creamMachineInputController = gameObject.AddComponent<CreamMachineInputController>();
            _creamMachineMovementController = gameObject.AddComponent<CreamMachineMovementController>();
        }
    }
}
