
using System;
using Utils;

namespace Game.LevelSystem.Events
{
    public class LevelEvent
    {
        private event Action _levelAction;
        public LevelEventType LevelEventType;
        
        public LevelEvent(LevelEventType levelEventType)
        {
            LevelEventType = levelEventType;
        }

        public void Invoke()
        {
            _levelAction.SafeInvoke();
        }

        public void Subscribe(Action action)
        {
            _levelAction += action;
        }
    }

    public enum LevelEventType
    {
        ON_STARTED,
        ON_FINISHED
    }
}
