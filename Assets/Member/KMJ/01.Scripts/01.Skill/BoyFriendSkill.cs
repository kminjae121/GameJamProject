using System;
using Code.Combat;
using UnityEngine;

public class BoyFriendSkill : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;

    [field: SerializeField] public float speed;

    [SerializeField] private Transform _girlFriendTrans;

    private float angle;
    [SerializeField] private float radius;

    private DamageData _damageData;


    private void Awake()
    {
        _damageData.damage = 20f;
    }

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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _whatIsEnemy) != 0)
        {
            print(other.gameObject.name);
            other.GetComponent<EntityHealth>().ApplyDamage(_damageData,transform.position,null);
        }
    }
}
