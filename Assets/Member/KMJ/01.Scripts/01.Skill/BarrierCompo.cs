using System;
using UnityEngine;

public class BarrierCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;

    public float modifierValue { get; set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _whatIsEnemy) != 0)
        {
            other.transform.GetComponentInChildren<EnemyMovement>()._moveSpeed -= modifierValue;
        }
    }
}
