using System;
using UnityEngine;

public class BoyFriendSkill : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;

    [field: SerializeField] public float speed;

    [SerializeField] private Transform _girlFriendTrans;

    private float angle;
    [SerializeField] private float radius;
    private void Update()
    {
        if (_girlFriendTrans != null)
        {
            angle += speed * Time.deltaTime;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            transform.position = _girlFriendTrans.position + new Vector3(x, y, 0f);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
