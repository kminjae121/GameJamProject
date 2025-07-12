using System;
using Code.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent, IAfterInitialize
{
    [SerializeField] private InputReader playerInput;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private GameObject arrowObject;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;

    [SerializeField] private StatSO atkDamage;
    [SerializeField] private StatSO atkcoolTime;

    private EntityStat _statCompo;

    [SerializeField] private float _atkDamage;
    [field: SerializeField] public int shootCnt { get; set; } = 1;
    private Vector3 _mousePos;
    private Vector2 _direction;
    private float _angle;

    public void Initialize(Entity entity)
    {
        _statCompo = entity.GetCompo<EntityStat>();
    }
    
    private void Awake()
    {
        playerInput.OnPointerEvent += HandlePointer;
        playerInput.OnClickEvent += HandleClick;
    }
    
    public void AfterInitialize()
    {
        _atkDamage = _statCompo.SubscribeStat(atkDamage, HandleAttackDamageChange, atkDamage.Value);
    }

    private void HandleAttackDamageChange(StatSO stat, float currentvalue, float prevvalue)
    {
        float changed = currentvalue - prevvalue;
        _atkDamage += changed;
    }

    private void HandleClick() => SpawnProjectile();

    private void HandlePointer(Vector2 point)
    {
        if (this == null) return;
        
        _mousePos = Camera.main.ScreenToWorldPoint(point);
        Vector2 dir = (_mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        _angle = angle;

        _direction = dir;
        arrowObject.transform.position = (Vector2)transform.position + dir.normalized * 2f;
        arrowObject.transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    

    private void SpawnProjectile()
    {
        Vector3 firePos = (Vector2)transform.position + _direction.normalized * 2f;
        if (shootCnt == 1)
        {
            Projectile projectile = Instantiate(projectilePrefab, firePos, quaternion.identity).GetComponent<Projectile>();
            projectile.InitProjectile(_angle);
        }
        else if(shootCnt == 2)
        {
            for (int i = 1; i <= 3; i++)
            {
                Projectile projectile = Instantiate(projectilePrefab, firePos, quaternion.identity).GetComponent<Projectile>();
                if (i == 2)
                {
                    projectile.InitProjectile(_angle + 15);
                }
                else if (i == 3)
                {
                    projectile.InitProjectile(_angle - 15);
                }
                else
                    projectile.InitProjectile(_angle);
                
            }
        }
        else if (shootCnt == 3)
        {
            for (int i = 1; i <= 5; i++)
            {
                Projectile projectile = Instantiate(projectilePrefab, firePos, quaternion.identity).GetComponent<Projectile>();
                if (i == 2)
                {
                    projectile.InitProjectile(_angle + 15);
                }
                else if (i == 3)
                {
                    projectile.InitProjectile(_angle - 15);
                }
                else if (i == 4)
                {
                    projectile.InitProjectile(_angle + 25);
                }
                else if (i == 5)
                {
                    projectile.InitProjectile(_angle - 25);
                }
                else
                    projectile.InitProjectile(_angle);
                
            }
        }
    }
}
