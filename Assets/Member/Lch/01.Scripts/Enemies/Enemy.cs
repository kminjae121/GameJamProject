using Code.Combat;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private StatSO attackDamageStat;
    protected EnemyMovement movement;
    private EntityStat _statCompo;

    protected override void Awake()
    {
        base.Awake();
        movement = GetCompo<EnemyMovement>();
        _statCompo = GetCompo<EntityStat>();
    }

    public override async void OnDead()
    {
        IsDead = true;
        GameManager.Instance.AddKillCount(1);
        await Awaitable.WaitForSecondsAsync(2f);
        Destroy(gameObject);
    }
       

    public override void OnHit()
    {
        if (IsDead)
            return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                DamageData damageData = new DamageData();
                damageData.damage = _statCompo.GetStat(attackDamageStat).Value;
                damageData.isCritical = false;
                damageData.hitPoint = collision.contacts[0].point;
                damageData.hitNormal = collision.contacts[0].normal;
                Debug.Log(damageData.hitNormal);
                damageable.ApplyDamage(damageData, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
