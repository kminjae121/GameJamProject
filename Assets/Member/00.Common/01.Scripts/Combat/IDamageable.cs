using UnityEngine;

namespace Code.Combat
{
    public interface IDamageable
    {
        public void ApplyDamage(DamageData damageData, Vector3 direction, Entity dealer = null);
    }
}