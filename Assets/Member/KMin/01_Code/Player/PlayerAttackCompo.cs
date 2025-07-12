using System;
using Code.Player;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private InputReader playerInput;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private GameObject projectilePrefab;
    
    private LineRenderer _attackDirLine;
    private Vector3 _mousePos;
    private float _angle;

    public void Initialize(Entity entity)
    {
    }
    
    private void Awake()
    {
        playerInput.OnPointerEvent += HandlePointer;
        playerInput.OnClickEvent += HandleClick;
        
        _attackDirLine = GetComponent<LineRenderer>();
    }

    private void HandleClick() => SpawnProjectile();

    private void HandlePointer(Vector2 point)
    {
        _mousePos = Camera.main.ScreenToWorldPoint(point);
        Vector2 dir = (_mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        _angle = angle;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        DrawDirectionRay(dir);
    }

    private void DrawDirectionRay(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100f, whatIsEnemy);
        Vector3 endPos = hit ? hit.point : transform.right * 50f;
        
        _attackDirLine.SetPosition(0,  transform.position);
        _attackDirLine.SetPosition(1, endPos);
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, quaternion.identity).GetComponent<Projectile>();
        projectile.InitProjectile(_angle);
    }
}
