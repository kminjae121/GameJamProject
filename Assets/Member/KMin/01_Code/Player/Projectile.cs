 using System;
using Code.Combat;
using UnityEngine;

namespace Code.Player
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileSO projectileSO;

        private Rigidbody2D _rigidCompo;

        [SerializeField] private LayerMask _whatIsEnemy;

        private void Awake()
        {
            _rigidCompo = GetComponent<Rigidbody2D>();
            
            Destroy(gameObject, 10);
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
            if (((1 << collision.gameObject.layer) & _whatIsEnemy) != 0)
            {
                if (collision.collider.TryGetComponent(out IDamageable damageable))
                {
                    DamageData data = new DamageData();
                    data.damage = projectileSO.attackDamage;
                    data.hitPoint = collision.contacts[0].point;
                    data.hitNormal = collision.contacts[0].normal;
                    damageable.ApplyDamage(data, data.hitNormal);
                
                    Destroy(gameObject);
                }   
            }
        }
    }
}
