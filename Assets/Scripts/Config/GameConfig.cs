
using System.Collections.Generic;
using Game.IceCreamSystem.Base;

namespace Config
{
    public static class GameConfig
    {
        // Every Ice Cream Has 8 Layer
        
        public static List<CreamInfo> Level1 = new List<CreamInfo>
        {
            new CreamInfo(0,CreamType.CHOCOLATE),
            new CreamInfo(1,CreamType.CHOCOLATE),
            new CreamInfo(2,CreamType.CHOCOLATE),
            new CreamInfo(3,CreamType.CHOCOLATE),
            new CreamInfo(4,CreamType.CHOCOLATE),
            new CreamInfo(5,CreamType.CHOCOLATE),
            new CreamInfo(6,CreamType.CHOCOLATE),
            new CreamInfo(7,CreamType.CHOCOLATE),
            new CreamInfo(8,CreamType.CHOCOLATE),
        };
    }
}
