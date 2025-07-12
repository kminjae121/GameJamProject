using System;
using UnityEngine;

public class BarrierCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;

    public float modifierValue { get; set; } = 0.6f;
    public Vector3 nextRange { get; set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _whatIsEnemy) != 0)
        {
           if(other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.gameObject.GetComponentInChildren<EnemyMovement>()._moveSpeed -= modifierValue;
            }

           if(other.gameObject.TryGetComponent(out MinBoss minBoss))
            {
                minBoss.gameObject.GetComponentInChildren<MinBossMovement>()._moveSpeed -= modifierValue;
            }

           if(other.gameObject.TryGetComponent(out Boss boss))
            {
                boss.gameObject.GetComponentInChildren<BossMovemen>()._moveSpeed -= modifierValue;
            }
        }
    }
}
