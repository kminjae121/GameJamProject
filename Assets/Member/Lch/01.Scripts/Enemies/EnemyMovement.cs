using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEntityComponent,IAfterInitialize
{
    [SerializeField] private Rigidbody2D rbCompo;
    [SerializeField] protected StatSO moveSpeedStat;
    private EntityStat _statCompo;
    private float _moveSpeed;
    Vector3 _moveDir;

    public void Initialize(Entity entity)
    {
        _statCompo = entity.GetCompo<EntityStat>();
    }
    public void AfterInitialize()
    {
        _moveSpeed = _statCompo.SubscribeStat(moveSpeedStat, HandleMoveSpeedChange, 6f);
    }

    private void HandleMoveSpeedChange(StatSO stat, float currentValue, float prevValue)
    {
        _moveSpeed = currentValue;
    }

    private void Start()
    {
        Transform playerPos = GameObject.FindWithTag("Player").transform;
        _moveDir = playerPos.position - transform.position; 
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
        gameObject.transform.LookAt(_moveDir);
        rbCompo.linearVelocity = _moveDir.normalized * _moveSpeed;
    }

}
