using UnityEngine;

public abstract class Eenemy : Entity
{
    public override void OnDead()
    {
        throw new System.NotImplementedException();
    }

    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
