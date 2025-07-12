using System;
using Code.Combat;
using UnityEngine;

namespace Code.Player
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

        public void InitProjectile(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out IDamageable damageable))
            {
                DamageData data = new DamageData();
                Vector3 direction = (transform.position - Vector3.zero).normalized;
                data.damage = projectileSO.attackDamage;
                data.hitPoint = collision.contacts[0].point;
                data.hitNormal = collision.contacts[0].normal;
                
                damageable.ApplyDamage(data, direction);
                Destroy(gameObject);
            }
        }
    }
}
