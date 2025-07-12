using System;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private InputReader playerInput;

    private LineRenderer _attackDirLine;

    public void Initialize(Entity entity)
    {
    }
    
    private void Awake()
    {
        playerInput.OnPointerEvent += HandlePointer;
        
        _attackDirLine = GetComponent<LineRenderer>();
    }

    private void HandlePointer(Vector2 point)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(point);
        pos.z = 0;
        
        Vector2 dir = (pos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        DrawDirectionRay();
    }

    private void DrawDirectionRay()
    {
        _attackDirLine.SetPosition(0,  transform.position);
        _attackDirLine.SetPosition(1, transform.right * 50f);
    }
}
