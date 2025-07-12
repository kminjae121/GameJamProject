using System.Collections;
using UnityEngine;

public class SlangWord : SkillCompo
{
    public override void GetSkill()
    {
        base.GetSkill();
        StartCoroutine(shootTime());
    }

    [SerializeField] private GameObject _slangPrefab;

    [field: SerializeField] public float coolTime { get; set; }
    

    private IEnumerator shootTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime);
            
            Instantiate(_slangPrefab, transform.position, Quaternion.identity);
        }
    }
}
