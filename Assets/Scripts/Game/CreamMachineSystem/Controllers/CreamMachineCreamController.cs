using UnityEngine;

namespace Game.CreamMachineSystem.Controllers
{
    public class CreamMachineCreamController : MonoBehaviour
    {
        private CreamMachineMovementController _creamMachineMovementController;
        
        public void Initialize(CreamMachineMovementController creamMachineMovementController)
        {
            _creamMachineMovementController = creamMachineMovementController;
        }
    }
}
