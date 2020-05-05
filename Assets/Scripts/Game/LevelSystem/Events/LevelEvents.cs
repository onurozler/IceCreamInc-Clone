
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.LevelSystem.Events
{
    public static class LevelEvents
    {
        private static List<LevelEvent> _levelEvents = new List<LevelEvent>
        {
            new LevelEvent(LevelEventType.ON_STARTED),
            new LevelEvent(LevelEventType.ON_FINISHED)
        };
        
        
        public static void InvokeEvent(LevelEventType type)
        {
            var specificEvent = _levelEvents?.FirstOrDefault(x => x.LevelEventType == type);
            specificEvent?.Invoke();
        }

        public static void SubscribeEvent(LevelEventType type, Action action)
        {
            var specificEvent = _levelEvents?.FirstOrDefault(x => x.LevelEventType == type);
            specificEvent?.Subscribe(action);
        }
    }
}
