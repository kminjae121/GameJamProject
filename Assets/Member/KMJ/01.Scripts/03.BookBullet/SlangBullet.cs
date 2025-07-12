using System;
using Code.Combat;
using UnityEngine;

public class SlangBullet : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private Vector2 boxSize = new Vector2(5f, 5f);
    [SerializeField] private float speed = 5f;

    private Transform target;
    [SerializeField] private Vector3 _bombSize;
    private DamageData _damage;
    [SerializeField] private float damage;

    private void Awake()
    {
        _damage.damage = damage;
    }

    private void Update()
    {
        if (target == null)
        {
            target = FindClosestEnemy();

            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
        }

        FlyTowardsTarget();
    }

    Transform FindClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, _whatIsEnemy);
        if (hits.Length == 0)
            return null;

        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (var col in hits)
        {
            float dist = ((Vector2)transform.position - (Vector2)col.transform.position).sqrMagnitude;
            if (dist < minDist)
            {
                minDist = dist;
                closest = col.transform;
            }
        }

        return closest;
    }

    void FlyTowardsTarget()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _whatIsEnemy) != 0)
        {
            other.GetComponentInChildren<EntityHealth>().ApplyDamage(_damage,transform.position,null);
            Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, _bombSize, 0, _whatIsEnemy);

            foreach (var hittable in hit)
            {
                hittable.GetComponentInChildren<EntityHealth>().ApplyDamage(_damage,transform.position,null);
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, _bombSize);
    }
}
