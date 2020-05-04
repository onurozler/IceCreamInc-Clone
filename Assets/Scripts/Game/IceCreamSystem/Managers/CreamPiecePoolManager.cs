using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;
using Helpers;

namespace Game.IceCreamSystem.Managers
{
    public class CreamPiecePoolManager : GenericSingleton<CreamPiecePoolManager>
    {
        private List<CreamPiece> _creamPieces;
        
        public override void Awake()
        {
            base.Awake();
            _creamPieces = GetComponentsInChildren<CreamPiece>().ToList();
        }
    }
}
