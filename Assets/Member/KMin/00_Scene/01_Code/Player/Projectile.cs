using System;
using Code.Combat;
using Code.Entities;
using UnityEngine;

namespace Code.Entities
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileSO projectileSO;

        private Rigidbody2D _rigidCompo;

        private void Awake()
        {
            _rigidCompo = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveProjectile();
        }

        private void MoveProjectile()
            => _rigidCompo.linearVelocity = transform.right * projectileSO.speed;

        public async void InitProjectile(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            await Awaitable.WaitForSecondsAsync(5f);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 direction = other.transform.position - transform.position;
                Vector3 normal = direction.normalized;
                
                DamageData data = new DamageData();
                data.damage = projectileSO.attackDamage;
                data.hitPoint = hitPoint;
                data.hitNormal = normal;
                
                damageable.ApplyDamage(data, direction);
                Destroy(gameObject);
            }
        }
    }
}
