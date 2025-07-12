using UnityEngine;

public abstract class Enemy : Entity
{
    protected EnemyMovement movement;

    protected override void Awake()
    {
        base.Awake();
        movement = GetCompo<EnemyMovement>();
    }

    public override void OnDead()
    {
        Destroy(gameObject);
    }

    public override void OnHit()
    {
        
    }
}
