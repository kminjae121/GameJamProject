using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Code.Entities;

namespace Code.Combat
{
    public class EntityHealth : MonoBehaviour, IEntityComponent, IAfterInitialize, IDamageable
    {
        private Entity _entity;
        private EntityStat _entityStat;
        private ActionData _actionData;

        //[SerializeField] private GameEventChannelSO eventChannel;
        [SerializeField] private GameObject damageText;
        [SerializeField] private StatSO hpStat;
        [field:SerializeField] public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        public void Initialize(Entity entity)
        {
            _entity = entity;
            _entityStat = entity.GetCompo<EntityStat>();
            _actionData = entity.GetCompo<ActionData>();
        }
        
        public void AfterInitialize()
        {
            CurrentHealth = MaxHealth = _entityStat.SubscribeStat(hpStat, HandleMaxHpChange, hpStat.Value);
        }

        private void HandleMaxHpChange(StatSO stat, float currentvalue, float prevvalue)
        {
            float changed = currentvalue - prevvalue;
            MaxHealth = currentvalue;

            if (changed > 0)
            {
                CurrentHealth = Mathf.Clamp(CurrentHealth + changed, 0, MaxHealth);
            }
            else
            {
                CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
            }
        }

        public async void ApplyDamage(DamageData damageData, Vector3 direction, Entity dealer)
        {
            Vector2 position = _entity.transform.position;
            position += Random.insideUnitCircle * 0.3f;
           _actionData.HitNormal = damageData.hitNormal;
            _actionData.HitPoint = damageData.hitPoint;

            CurrentHealth = Mathf.Clamp(CurrentHealth - damageData.damage, 0f, MaxHealth);

            if (CurrentHealth <= 0)
            {
                _entity.OnDeadEvent?.Invoke();
                CurrentHealth = MaxHealth;
            }

            _entity.OnHitEvent?.Invoke();

            if (dealer is Enemy)
                return; 
            
            TextMeshProUGUI text = Instantiate(damageText, position, Quaternion.identity).GetComponent<TextMeshProUGUI>();
            
            if (damageData.isCritical)
            {
                text.transform.localScale *= 1.2f;
                text.color = Color.red;
            }

            await Awaitable.WaitForSecondsAsync(1f);
            Destroy(text);
        }
    }
}