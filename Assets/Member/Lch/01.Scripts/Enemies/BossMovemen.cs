using UnityEngine;

public class BossMovemen : MonoBehaviour,IEntityComponent, IAfterInitialize
{
    [SerializeField] private Rigidbody2D rbCompo;
    [SerializeField] protected StatSO moveSpeedStat;
    [SerializeField] protected bool isLoveLetter = false;
    private EntityStat _statCompo;

    private float _timeElapsed = 0f;
    [field : SerializeField]public float _moveSpeed { get; set; }
    Vector3 _moveDir;
    private Boss _enemy;

    public void Initialize(Entity entity)
    {
        _enemy = entity as Boss;
        _statCompo = entity.GetCompo<EntityStat>();
    }
    public void AfterInitialize()
    {
        _moveSpeed = _statCompo.SubscribeStat(moveSpeedStat, HandleMoveSpeedChange, 1.5f);
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
        if (_enemy.IsDead == false)
        {
            Move();
        }
    }

    private void Move()
    {
        gameObject.transform.LookAt(_moveDir);
        rbCompo.linearVelocity = _moveDir.normalized * _moveSpeed;
    }
}
