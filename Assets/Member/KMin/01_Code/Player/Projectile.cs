using System;
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
    }
}
