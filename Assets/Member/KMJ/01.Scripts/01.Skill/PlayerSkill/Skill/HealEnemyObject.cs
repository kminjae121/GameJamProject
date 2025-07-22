using Code.Combat;
using UnityEngine;

public class HealEnemyObject : Enemy
{
    public override void OnDead()
    {
        base.OnDead();
        GameObject player = GameObject.FindWithTag("Player");

        if(player.gameObject.TryGetComponent(out IDamageable damageable))
        {
            DamageData damageData = new DamageData();
            damageData.damage = _statCompo.GetStat(attackDamageStat).Value;
            Debug.Log(damageData.hitNormal);
            damageable.ApplyDamage(damageData, transform.position);
            Destroy(gameObject);
        }

    }
}
