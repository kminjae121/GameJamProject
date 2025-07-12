using System;
using Code.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private InputReader playerInput;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private GameObject arrowObject;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;

    [field: SerializeField] public int shootCnt { get; set; } = 2;
    private Vector3 _mousePos;
    private float _angle;

    public void Initialize(Entity entity)
    {
    }
    
    private void Awake()
    {
        playerInput.OnPointerEvent += HandlePointer;
        playerInput.OnClickEvent += HandleClick;
    }

    private void HandleClick() => SpawnProjectile();

    private void HandlePointer(Vector2 point)
    {
        _mousePos = Camera.main.ScreenToWorldPoint(point);
        Vector2 dir = (_mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        _angle = angle;

        arrowObject.transform.position = (Vector2)transform.position + dir.normalized * 2f;
        arrowObject.transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    

    private void SpawnProjectile()
    {
        if (shootCnt == 1)
        {
            Projectile projectile = Instantiate(projectilePrefab, transform.position, quaternion.identity).GetComponent<Projectile>();
            projectile.InitProjectile(_angle);
        }
        else if(shootCnt == 2)
        {
            for (int i = 1; i <= 3; i++)
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, quaternion.identity).GetComponent<Projectile>();
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
                Projectile projectile = Instantiate(projectilePrefab, transform.position, quaternion.identity).GetComponent<Projectile>();
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
