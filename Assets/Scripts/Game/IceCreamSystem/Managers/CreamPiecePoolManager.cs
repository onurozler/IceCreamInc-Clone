using System.Collections.Generic;
using System.Linq;
using Game.IceCreamSystem.Base;
using Helpers;
using UnityEngine;

namespace Game.IceCreamSystem.Managers
{
    public class CreamPiecePoolManager : GenericSingleton<CreamPiecePoolManager>
    {
        [SerializeField] private Material _chocolateMaterial;
        [SerializeField] private Material _vanillaMaterial;
        
        private List<CreamPiece> _creamPieces;
        
        public void Initialize()
        {
            _creamPieces = GetComponentsInChildren<CreamPiece>().ToList();
        }
        
        
    }
}
