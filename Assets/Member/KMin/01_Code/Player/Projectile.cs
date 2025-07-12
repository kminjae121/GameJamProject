using System;
using UnityEngine;

namespace Code.Player
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileSO projectileSO;

        private void Update()
        {
            MoveProjectile();
        }

        private void MoveProjectile() => transform.right *= projectileSO.speed;

        public void SetTarget(Transform target)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
