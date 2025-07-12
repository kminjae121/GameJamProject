using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Android;

public class Book : SkillCompo
{
    public override void GetSkill()
    {
        base.GetSkill();
        StartCoroutine(shootTime());
    }

    [SerializeField] private GameObject _bookPrefabs;

     [field: SerializeField] public float coolTime { get; set; }
    

    private IEnumerator shootTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime);
            
            Instantiate(_bookPrefabs, transform.position, Quaternion.identity);
        }
    }
    
}
