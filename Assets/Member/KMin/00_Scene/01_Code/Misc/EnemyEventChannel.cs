using Blade.Core;
using UnityEngine;

namespace Member.KMin._00_Scene._01_Code.Misc
{
    public static class EnemyEventChannel
    {
        public static EnemyDeadEvent EnemyDeadEvent = new EnemyDeadEvent();
    }

    public class EnemyDeadEvent : GameEvent
    {
        public Vector3 deadPosition;
        
        public EnemyDeadEvent Initializer(Vector3 position)
        {
            deadPosition = position;
            return this;
        }
    }
}