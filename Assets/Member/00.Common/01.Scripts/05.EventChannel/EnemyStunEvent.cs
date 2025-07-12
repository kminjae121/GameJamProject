namespace Blade.Core
{

    public class EnemyStateChannel : GameEvent
    {
        public static EnemyStunEvent stunEvt = new EnemyStunEvent();
    }
    public class EnemyStunEvent : GameEvent
    {
        public bool isStun;
        public int cnt;

        public GameEvent Initialize(bool isStun, int Cnt)
        {
            this.isStun = isStun;
            this.cnt = Cnt;
            
            return this;
        }
    }
    
}